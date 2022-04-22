using SoftwareInstallationContracts.BindingModels;
using SoftwareInstallationContracts.StoragesContracts;
using SoftwareInstallationContracts.ViewModels;
using SoftwareInstallationListImplement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftwareInstallationListImplement.Implements
{
    public class OrderStorage : IOrderStorage
    {
        private readonly DataListSingleton _source;

        public OrderStorage()
        {
            _source = DataListSingleton.GetInstance();
        }

        public List<OrderViewModel> GetFullList()
        {
            List<OrderViewModel> result = new List<OrderViewModel>();
            foreach (var component in _source.Orders)
            {
                result.Add(CreateModel(component));
            }
            return result;
        }

        public List<OrderViewModel> GetFilteredList(OrderBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            List<OrderViewModel> result = new List<OrderViewModel>();
            foreach (var Order in _source.Orders)
            {
                if (Order.PackageId == model.PackageId || (Order.DateCreate >= model.DateFrom && Order.DateCreate <= model.DateTo) || 
                    model.ClientId.HasValue && Order.ClientId == model.ClientId.Value || (model.SearchStatus.HasValue && model.SearchStatus.Value == order.Status)
                    || (model.ImplementerId.HasValue && Order.ImplementerId == model.ImplementerId && model.Status == Order.Status))
                {
                    result.Add(CreateModel(Order));
                }
            }
            return result;
        }

        public OrderViewModel GetElement(OrderBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            foreach (var Order in _source.Orders)
            {
                if (Order.Id == model.Id)
                {
                    return CreateModel(Order);
                }
            }
            return null;
        }

        public void Insert(OrderBindingModel model)
        {
            Order tempOrder = new Order { Id = 1 };
            foreach (var Order in _source.Orders)
            {
                if (Order.Id >= tempOrder.Id)
                {
                    tempOrder.Id = Order.Id + 1;
                }
            }
            _source.Orders.Add(CreateModel(model, tempOrder));
        }

        public void Update(OrderBindingModel model)
        {
            Order tmpOrder = null;
            foreach (var Order in _source.Orders)
            {
                if (Order.Id == model.Id)
                {
                    tmpOrder = Order;
                }
            }
            if (tmpOrder == null)
            {
                throw new Exception("Элемент не найден");
            }
            CreateModel(model, tmpOrder);
        }

        public void Delete(OrderBindingModel model)
        {
            for (int i = 0; i < _source.Orders.Count; ++i)
            {
                if (_source.Orders[i].Id == model.Id)
                {
                    _source.Orders.RemoveAt(i);
                    return;
                }
            }
            throw new Exception("Элемент не найден");
        }

        private Order CreateModel(OrderBindingModel model, Order order)
        {
            order.PackageId = model.PackageId;
            order.ImplementerId = (int)model.ImplementerId;
            order.Count = model.Count;
            order.Status = model.Status;
            order.Sum = model.Sum;
            order.DateCreate = model.DateCreate;
            order.DateImplement = model.DateImplement;
            order.ClientId = model.ClientId.Value;
            return order;
        }

        private OrderViewModel CreateModel(Order order)
        {
            string packageName = "";
            foreach (var package in _source.Packages)
            {
                if (order.PackageId == package.Id)
                {
                    packageName = package.PackageName;
                    break;
                }
            }
            string clientFIO = "";
            foreach (var client in _source.Clients)
            {
                if (client.Id == order.ClientId)
                {
                    clientFIO = client.FIO;
                    break;
                }
            }
            string implementerFIO = null;
            foreach (Implementer implementer in _source.Implementers)
            {
                if (order.ImplementerId == implementer.Id)
                {
                    implementerFIO = implementer.ImplementerFIO;
                    break;
                }
            }
                return new OrderViewModel
            {
                Id = order.Id,
                PackageId = order.PackageId,
                ImplementerId = order.ImplementerId,
                PackageName = packageName,
                ImplementerFIO = implementerFIO,
                Count = order.Count,
                Status = order.Status,
                Sum = order.Sum,
                DateCreate = order.DateCreate,
                DateImplement = order.DateImplement,
                ClientId = order.ClientId,
                ClientFIO = clientFIO
            };
        }
    }
}
