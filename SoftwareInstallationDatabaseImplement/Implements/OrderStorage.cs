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
                return context.Orders.Include(rec => rec.Package)
                    .Include(rec => rec.Client)
                    .Include(rec => rec.Implementer)
                    .ToList().Select(rec => new OrderViewModel
                {
                    Id = rec.Id,
                    ClientId = rec.ClientId,
                    ClientFIO = rec.Client.ClientFIO,
                    PackageId = rec.PackageId,                    
                    PackageName = rec.Package.PackageName,
                    ImplementerId = rec.ImplementerId,
                    ImplementerFIO = rec.Implementer?.ImplementerFIO,
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
                return context.Orders.Include(rec => rec.Package).Include(rec => rec.Client).Include(rec => rec.Implementer)
                    .Where(rec => (!model.DateFrom.HasValue && !model.DateTo.HasValue && rec.DateCreate.Date == model.DateCreate.Date) ||
            (model.DateFrom.HasValue && model.DateTo.HasValue && rec.DateCreate.Date >= model.DateFrom.Value.Date && rec.DateCreate.Date <= model.DateTo.Value.Date) ||
            (model.ClientId.HasValue && rec.ClientId == model.ClientId) || (model.SearchStatus.HasValue && model.SearchStatus.Value == rec.Status) ||
            (model.ImplementerId.HasValue && rec.ImplementerId == model.ImplementerId && model.Status == rec.Status))
                    .ToList().Select(rec => new OrderViewModel
                {
                    Id = rec.Id,
                    ClientId = rec.ClientId,
                    ClientFIO = rec.Client.ClientFIO,
                    PackageId = rec.PackageId,                   
                    PackageName = rec.Package.PackageName,
                    ImplementerId = rec.ImplementerId,
                    ImplementerFIO = rec.Implementer?.ImplementerFIO,
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
                var order = context.Orders.Include(rec=>rec.Package).Include(rec => rec.Client).Include(rec => rec.Implementer).FirstOrDefault(rec => rec.Id == model.Id);
                return order != null ? CreateModel(order, context) : null;
            }
        }
        public void Insert(OrderBindingModel model)
        {
            using (var context = new SoftwareInstallationDatabase())
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        context.Orders.Add(CreateModel(model, new Order()));
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
        public void Update(OrderBindingModel model)
        {
            using (var context = new SoftwareInstallationDatabase())
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        var element = context.Orders.FirstOrDefault(rec => rec.Id == model.Id);
                        if (element == null)
                        {
                            throw new Exception("Элемент не найден");
                        }
                        CreateModel(model, element);
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
            order.ClientId = model.ClientId.Value;
            order.ImplementerId = model.ImplementerId;
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
                ClientId = order.ClientId,
                ClientFIO = order.Client.ClientFIO,
                PackageId = order.PackageId,
                PackageName = context.Packages.FirstOrDefault(rec => rec.Id == order.PackageId)?.PackageName,                
                ImplementerId = order.ImplementerId,
                ImplementerFIO = order.Implementer?.ImplementerFIO,
                Count = order.Count,
                Sum = order.Sum,
                Status = order.Status,
                DateCreate = order.DateCreate,
                DateImplement = order.DateImplement                
            };
        }
    }
}
