using SoftwareInstallationContracts.BindingModels;
using SoftwareInstallationContracts.StoragesContracts;
using SoftwareInstallationContracts.ViewModels;
using SoftwareInstallationFileImplement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftwareInstallationFileImplement.Implements
{
    public class WarehouseStorage : IWarehouseStorage
    {
        private readonly FileDataListSingleton source;
        public WarehouseStorage()
        {
            source = FileDataListSingleton.GetInstance();
        }
        public List<WarehouseViewModel> GetFullList()
        {
            return source.Warehouses.Select(CreateModel).ToList();
        }
        public List<WarehouseViewModel> GetFilteredList(WarehouseBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            return source.Warehouses.Where(rec => rec.WarehouseName.Contains(model.WarehouseName)).Select(CreateModel).ToList();
        }
        public WarehouseViewModel GetElement(WarehouseBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            var warehouse = source.Warehouses.FirstOrDefault(rec => rec.WarehouseName == model.WarehouseName ||
                rec.Id == model.Id);
            return warehouse != null ? CreateModel(warehouse) : null;
        }
        public void Insert(WarehouseBindingModel model)
        {
            int maxId = source.Warehouses.Count > 0 ? source.Warehouses.Max(rec => rec.Id) : 0;
            var element = new Warehouse
            {
                Id = maxId + 1,
                WarehouseComponents = new Dictionary<int, int>()
            };
            source.Warehouses.Add(CreateModel(model, element));
        }
        public void Update(WarehouseBindingModel model)
        {
            var element = source.Warehouses.FirstOrDefault(rec => rec.Id == model.Id);
            if (element == null)
            {
                throw new Exception("Элемент не найден");
            }
            CreateModel(model, element);
        }
        public void Delete(WarehouseBindingModel model)
        {
            Warehouse element = source.Warehouses.FirstOrDefault(rec => rec.Id == model.Id);
            if (element != null)
            {
                source.Warehouses.Remove(element);
            }
            else
            {
                throw new Exception("Элемент не найден");
            }
        }
        private WarehouseViewModel CreateModel(Warehouse warehouse)
        {
            return new WarehouseViewModel
            {
                Id = warehouse.Id,
                WarehouseName = warehouse.WarehouseName,
                Responsible = warehouse.Responsible,
                DateCreate = warehouse.DateCreate,
                WarehouseComponents = warehouse.WarehouseComponents
                    .ToDictionary(recPC => recPC.Key, recPC =>
                    (source.Components.FirstOrDefault(recC => recC.Id ==
                    recPC.Key)?.ComponentName, recPC.Value))
            };
        }
        private static Warehouse CreateModel(WarehouseBindingModel model,
            Warehouse warehouse)
        {
            warehouse.WarehouseName = model.WarehouseName;
            warehouse.Responsible = model.Responsible;
            warehouse.DateCreate = model.DateCreate;
            foreach (var key in warehouse.WarehouseComponents.Keys.ToList())
            {
                if (!model.WarehouseComponents.ContainsKey(key))
                {
                    warehouse.WarehouseComponents.Remove(key);
                }
            }
            foreach (var component in model.WarehouseComponents)
            {
                if (warehouse.WarehouseComponents.ContainsKey(component.Key))
                {
                    warehouse.WarehouseComponents[component.Key] =
                        model.WarehouseComponents[component.Key].Item2;
                }
                else
                {
                    warehouse.WarehouseComponents.Add(component.Key,
                        model.WarehouseComponents[component.Key].Item2);
                }
            }
            return warehouse;
        }
        public bool CheckComponent(int count, Dictionary<int, (string, int)> components)
        {
            foreach (var component in components)
            {
                int compCount = source.Warehouses.Where(warehouse => warehouse.WarehouseComponents.ContainsKey(component.Key))
                    .Sum(warehouse => warehouse.WarehouseComponents[component.Key]);
                if (compCount < (component.Value.Item2 * count))
                {
                    return false;
                }
            }
            foreach (var component in components)
            {
                int requiredCount = component.Value.Item2 * count;
                while (requiredCount > 0)
                {
                    var warehouse = source.Warehouses
                        .FirstOrDefault(warehouse => warehouse.WarehouseComponents.ContainsKey(component.Key)
                        && warehouse.WarehouseComponents[component.Key] > 0);
                    int availableCount = warehouse.WarehouseComponents[component.Key];
                    requiredCount -= availableCount;
                    warehouse.WarehouseComponents[component.Key] = (requiredCount < 0) ? availableCount - (availableCount + requiredCount) : 0;
                }
            }
            return true;
        }
    }
}
