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
   public class PackageStorage : IPackageStorage
    {
        public List<PackageViewModel> GetFullList()
        {
            using var context = new SoftwareInstallationDatabase();
            return context.Packages.Include(rec => rec.PackageComponents).ThenInclude(rec => rec.Component).ToList().Select(CreateModel).ToList();
        }
        public List<PackageViewModel> GetFilteredList(PackageBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            using var context = new SoftwareInstallationDatabase();
            return context.Packages.Include(rec => rec.PackageComponents).ThenInclude(rec => rec.Component).Where(rec => rec.PackageName.Contains(model.PackageName)).ToList().Select(CreateModel).ToList();
        }
        public PackageViewModel GetElement(PackageBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            using var context = new SoftwareInstallationDatabase();
            var package = context.Packages.Include(rec => rec.PackageComponents).ThenInclude(rec => rec.Component).FirstOrDefault(rec => rec.PackageName == model.PackageName || rec.Id == model.Id);
            return package != null ? CreateModel(package) : null;
        }
        public void Insert(PackageBindingModel model)
        {
            using var context = new SoftwareInstallationDatabase();
            using var transaction = context.Database.BeginTransaction();
            try
            {
                Package package = new Package()
                {
                    PackageName = model.PackageName,
                    Price = model.Price
                };
                context.Packages.Add(package);
                context.SaveChanges();
                CreateModel(model, package, context);
                transaction.Commit();
            }
            catch
            {
                transaction.Rollback();
                throw;
            }
        }
        public void Update(PackageBindingModel model)
        {
            using var context = new SoftwareInstallationDatabase();
            using var transaction = context.Database.BeginTransaction();
            try
            {
                var element = context.Packages.FirstOrDefault(rec => rec.Id == model.Id);
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
        public void Delete(PackageBindingModel model)
        {
            using var context = new SoftwareInstallationDatabase();
            Package element = context.Packages.FirstOrDefault(rec => rec.Id == model.Id);
            if (element != null)
            {
                context.Packages.Remove(element);
                context.SaveChanges();
            }
            else
            {
                throw new Exception("Элемент не найден");
            }
        }
        private static Package CreateModel(PackageBindingModel model, Package package, SoftwareInstallationDatabase context)
        {
            package.PackageName = model.PackageName;
            package.Price = model.Price;
            if (model.Id.HasValue)
            {
                var packageComponents = context.PackageComponents.Where(rec => rec.PackageId == model.Id.Value).ToList();
                context.PackageComponents.RemoveRange(packageComponents.Where(rec => !model.PackageComponents.ContainsKey(rec.ComponentId)).ToList());
                context.SaveChanges();
                foreach (var updateComponent in packageComponents)
                {
                    updateComponent.Count = model.PackageComponents[updateComponent.ComponentId].Item2;
                    model.PackageComponents.Remove(updateComponent.ComponentId);
                }
                context.SaveChanges();
            }
            foreach (var pc in model.PackageComponents)
            {
                context.PackageComponents.Add(new PackageComponent
                {
                    PackageId = package.Id,
                    ComponentId = pc.Key,
                    Count = pc.Value.Item2
                });
                context.SaveChanges();
            }
            return package;
        }
        private static PackageViewModel CreateModel(Package package)
        {
            return new PackageViewModel
            {
                Id = package.Id,
                PackageName = package.PackageName,
                Price = package.Price,
                PackageComponents = package.PackageComponents.ToDictionary(recPC => recPC.ComponentId, recPC => (recPC.Component?.ComponentName, recPC.Count))
            };
        }
    }
}
