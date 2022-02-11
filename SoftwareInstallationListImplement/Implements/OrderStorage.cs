﻿using SoftwareInstallationContracts.BindingModels;
using SoftwareInstallationContracts.Enums;
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
                if (Order.PackageId == model.PackageId)
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
            order.Count = model.Count;
            order.Status = model.Status;
            order.Sum = model.Sum;
            order.DateCreate = model.DateCreate;
            order.DateImplement = model.DateImplement;
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
            return new OrderViewModel
            {
                Id = order.Id,
                PackageId = order.PackageId,
                PackageName = packageName,
                Count = order.Count,
                Status = Enum.GetName(typeof(OrderStatus), order.Status),
                Sum = order.Sum,
                DateCreate = order.DateCreate,
                DateImplement = order.DateImplement,
            };
        }
    }
}
