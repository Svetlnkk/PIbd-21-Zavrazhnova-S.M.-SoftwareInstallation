﻿using SoftwareInstallationDatabaseImplement.Models;
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
    public class OrderStorage : IOrderStorage
    {
        public List<OrderViewModel> GetFullList()
        {
            using (var context = new SoftwareInstallationDatabase())
            {
                return context.Orders.Include(rec => rec.Package).Select(rec => new OrderViewModel
                {
                    Id = rec.Id,
                    PackageId = rec.PackageId,
                    PackageName = rec.Package.PackageName,
                    Count = rec.Count,
                    Sum = rec.Sum,
                    Status =rec.Status,
                    DateCreate = rec.DateCreate,
                    DateImplement = rec.DateImplement
                }).ToList();
            }
        }
        public List<OrderViewModel> GetFilteredList(OrderBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            using (var context = new SoftwareInstallationDatabase())
            {
                return context.Orders.Include(rec => rec.Package).Where(rec => rec.PackageId == model.PackageId).Select(rec => new OrderViewModel
                {
                    Id = rec.Id,
                    PackageId = rec.PackageId,
                    PackageName = rec.Package.PackageName,
                    Count = rec.Count,
                    Sum = rec.Sum,
                    Status = rec.Status,
                    DateCreate = rec.DateCreate,
                    DateImplement = rec.DateImplement
                }).ToList();
            }
        }
        public OrderViewModel GetElement(OrderBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            using (var context = new SoftwareInstallationDatabase())
            {
                var order = context.Orders.FirstOrDefault(rec => rec.Id == model.Id);
                return order != null ? CreateModel(order, context) : null;
            }
        }
        public void Insert(OrderBindingModel model)
        {
            using (var context = new SoftwareInstallationDatabase())
            {
                context.Orders.Add(CreateModel(model, new Order()));
                context.SaveChanges();
            }
        }
        public void Update(OrderBindingModel model)
        {
            using (var context = new SoftwareInstallationDatabase())
            {
                var element = context.Orders.FirstOrDefault(rec => rec.Id == model.Id);
                if (element == null)
                {
                    throw new Exception("Элемент не найден");
                }
                CreateModel(model, element);
                context.SaveChanges();
            }
        }
        public void Delete(OrderBindingModel model)
        {
            using (var context = new SoftwareInstallationDatabase())
            {
                Order element = context.Orders.FirstOrDefault(rec => rec.Id == model.Id);
                if (element != null)
                {
                    context.Orders.Remove(element);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("Элемент не найден");
                }
            }
        }
        public static Order CreateModel(OrderBindingModel model, Order order)
        {
            order.PackageId = model.PackageId;
            order.Count = model.Count;
            order.Sum = model.Sum;
            order.Status = model.Status;
            order.DateCreate = model.DateCreate;
            order.DateImplement = model.DateImplement;
            return order;
        }
        public OrderViewModel CreateModel(Order order, SoftwareInstallationDatabase context)
        {
            return new OrderViewModel
            {
                Id = order.Id,
                PackageId = order.PackageId,
                PackageName = context.Packages.FirstOrDefault(rec => rec.Id == order.PackageId)?.PackageName,
                Count = order.Count,
                Sum = order.Sum,
                Status = order.Status,
                DateCreate = order.DateCreate,
                DateImplement = order.DateImplement
            };
        }
    }
}