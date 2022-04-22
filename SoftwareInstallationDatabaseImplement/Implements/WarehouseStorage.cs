using SoftwareInstallationDatabaseImplement.Models;
using SoftwareInstallationContracts.BindingModels;
using SoftwareInstallationContracts.StoragesContracts;
using SoftwareInstallationContracts.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace SoftwareInstallationDatabaseImplement.Implements
{
    public class WarehouseStorage : IWarehouseStorage
    {
        public List<WarehouseViewModel> GetFullList()
        {
            using (var context = new SoftwareInstallationDatabase())
            {
                return context.Warehouses.Include(rec => rec.WarehouseComponents).ThenInclude(rec => rec.Component).ToList().Select(CreateModel).ToList();
            }
        }
        public List<WarehouseViewModel> GetFilteredList(WarehouseBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            using (var context = new SoftwareInstallationDatabase())
            {
                return context.Warehouses.Include(rec => rec.WarehouseComponents).ThenInclude(rec => rec.Component).Where(rec => rec.WarehouseName.Contains(model.WarehouseName)).ToList().Select(CreateModel).ToList();
            }
        }
        public WarehouseViewModel GetElement(WarehouseBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            using (var context = new SoftwareInstallationDatabase())
            {
                var warehouse = context.Warehouses.Include(rec => rec.WarehouseComponents).ThenInclude(rec => rec.Component).FirstOrDefault(rec => rec.WarehouseName == model.WarehouseName || rec.Id == model.Id);
                return warehouse != null ? CreateModel(warehouse) : null;
            }
        }
        public void Insert(WarehouseBindingModel model)
        {
            using (var context = new SoftwareInstallationDatabase())
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        Warehouse warehouse = new Warehouse()
                        {
                            WarehouseName = model.WarehouseName,
                            Responsible = model.Responsible,
                            DateCreate = model.DateCreate
                        };
                        context.Warehouses.Add(warehouse);
                        context.SaveChanges();
                        CreateModel(model, warehouse, context);
                        transaction.Commit();
                    }
                    catch
                    {
                        transaction.Rollback();
                        throw;
                    }
                }
            }
        }
        public void Update(WarehouseBindingModel model)
        {
            using (var context = new SoftwareInstallationDatabase())
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        var element = context.Warehouses.FirstOrDefault(rec => rec.Id == model.Id);
                        if (element == null)
                        {
                            throw new Exception("Элемент не найден");
                        }
                        CreateModel(model, element, context);
                        context.SaveChanges();
                        transaction.Commit();
                    }
                    catch
                    {
                        transaction.Rollback();
                        throw;
                    }
                }
            }
        }
        public void Delete(WarehouseBindingModel model)
        {
            using (var context = new SoftwareInstallationDatabase())
            {
                Warehouse element = context.Warehouses.FirstOrDefault(rec => rec.Id == model.Id);
                if (element != null)
                {
                    context.Warehouses.Remove(element);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("Элемент не найден");
                }
            }
        }
        private static Warehouse CreateModel(WarehouseBindingModel model, Warehouse warehouse, SoftwareInstallationDatabase context)
        {
            warehouse.WarehouseName = model.WarehouseName;
            warehouse.Responsible = model.Responsible;
            warehouse.DateCreate = model.DateCreate;
            if (model.Id.HasValue)
            {
                var warehouseComponents = context.WarehouseComponents.Where(rec => rec.WarehouseId == model.Id.Value).ToList();
                context.WarehouseComponents.RemoveRange(warehouseComponents.Where(rec => !model.WarehouseComponents.ContainsKey(rec.ComponentId)).ToList());
                context.SaveChanges();
                foreach (var updateComponent in warehouseComponents)
                {
                    updateComponent.Count = model.WarehouseComponents[updateComponent.ComponentId].Item2;
                    model.WarehouseComponents.Remove(updateComponent.ComponentId);
                }
                context.SaveChanges();
            }
            foreach (var pc in model.WarehouseComponents)
            {
                context.WarehouseComponents.Add(new WarehouseComponent
                {
                    WarehouseId = warehouse.Id,
                    ComponentId = pc.Key,
                    Count = pc.Value.Item2
                });
                context.SaveChanges();
            }
            return warehouse;
        }
        private static WarehouseViewModel CreateModel(Warehouse warehouse)
        {
            return new WarehouseViewModel
            {
                Id = warehouse.Id,
                WarehouseName = warehouse.WarehouseName,
                Responsible = warehouse.Responsible,
                DateCreate = warehouse.DateCreate,
                WarehouseComponents = warehouse.WarehouseComponents.ToDictionary(recPC => recPC.ComponentId, recPC => (recPC.Component?.ComponentName, recPC.Count))
            };
        }
        public bool CheckComponent(int count, Dictionary<int, (string, int)> components)
        {
            using (var context = new SoftwareInstallationDatabase())
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        foreach (var component in components)
                        {
                            int requiredCount = component.Value.Item2 * count;
                            foreach (var warehouse in context.Warehouses.Include(rec => rec.WarehouseComponents))
                            {
                                int? availableCount = warehouse.WarehouseComponents.FirstOrDefault(rec => rec.ComponentId == component.Key)?.Count;
                                if (availableCount == null) { continue; }
                                requiredCount -= (int)availableCount;
                                warehouse.WarehouseComponents.FirstOrDefault(rec => rec.ComponentId == component.Key).Count = (requiredCount < 0) ? (int)availableCount - ((int)availableCount + requiredCount) : 0;
                            }
                            if (requiredCount > 0)
                            {
                                return false;
                            }
                        }
                        context.SaveChanges();
                        transaction.Commit();
                    }
                    catch (Exception)
                    {
                        transaction.Rollback();
                        throw;
                    }
                }
            }
            return true;
        }
    }
}
