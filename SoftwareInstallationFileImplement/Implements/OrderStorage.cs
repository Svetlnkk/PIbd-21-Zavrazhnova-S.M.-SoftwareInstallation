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
    public class OrderStorage : IOrderStorage
    {
        private readonly FileDataListSingleton source;
        public OrderStorage()
        {
            source = FileDataListSingleton.GetInstance();
        }
        public List<OrderViewModel> GetFullList()
        {
            return source.Orders.Select(CreateModel).ToList();
        }
        public List<OrderViewModel> GetFilteredList(OrderBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            return source.Orders.Where(rec => rec.PackageId == model.PackageId || (rec.DateCreate >= model.DateFrom && rec.DateCreate <= model.DateTo) ||
            model.ClientId.HasValue && rec.ClientId == model.ClientId.Value || (model.SearchStatus.HasValue && model.SearchStatus.Value == rec.Status)
                    || (model.ImplementerId.HasValue && rec.ImplementerId == model.ImplementerId && model.Status == rec.Status))
                .Select(CreateModel).ToList();
        }
        public OrderViewModel GetElement(OrderBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            var order = source.Orders.FirstOrDefault(rec => rec.Id == model.Id);
            return order != null ? CreateModel(order) : null;
        }
        public void Insert(OrderBindingModel model)
        {
            int maxId = source.Orders.Count > 0 ? source.Orders.Max(rec => rec.Id) : 0;
            var element = new Order { Id = maxId + 1 };
            source.Orders.Add(CreateModel(model, element));
        }
        public void Update(OrderBindingModel model)
        {
            var element = source.Orders.FirstOrDefault(rec => rec.Id == model.Id);
            if (element == null)
            {
                throw new Exception("Элемент не найден");
            }
            CreateModel(model, element);
        }
        public void Delete(OrderBindingModel model)
        {
            Order element = source.Orders.FirstOrDefault(rec => rec.Id == model.Id);
            if (element != null)
            {
                source.Orders.Remove(element);
            }
            else
            {
                throw new Exception("Элемент не найден");
            }
        }
        public static Order CreateModel(OrderBindingModel model,
            Order order)
        {
            order.PackageId = model.PackageId;
            order.ImplementerId = model.ImplementerId;
            order.Count = model.Count;
            order.Sum = model.Sum;
            order.Status = model.Status;
            order.DateCreate = model.DateCreate;
            order.DateImplement = model.DateImplement;
            order.ClientId = model.ClientId.Value;
            return order;
        }
        public OrderViewModel CreateModel(Order order)
        {
            return new OrderViewModel
            {
                Id = order.Id,
                PackageId = order.PackageId,
                ClientId = order.ClientId,
                ClientFIO = source.Clients.FirstOrDefault(rec => rec.Id == order.ClientId)?.FIO,
                PackageName = source.Packages.FirstOrDefault(rec => rec.Id == order.PackageId)?.PackageName,
                ImplementerId = order.ImplementerId,
                ImplementerFIO = source.Implementers.FirstOrDefault(implementerFIO => implementerFIO.Id == order.ImplementerId)?.ImplementerFIO,
                Count = order.Count,
                Sum = order.Sum,
                Status = order.Status,
                DateCreate = order.DateCreate,
                DateImplement = order.DateImplement
            };
        }
    }
}
