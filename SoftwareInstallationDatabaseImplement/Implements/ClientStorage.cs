using SoftwareInstallationDatabaseImplement.Models;
using SoftwareInstallationContracts.BindingModels;
using SoftwareInstallationContracts.StoragesContracts;
using SoftwareInstallationContracts.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftwareInstallationDatabaseImplement.Implements
{
    public class ClientStorage : IClientStorage
    {
        public List<ClientViewModel> GetFullList()
        {
            using var context = new SoftwareInstallationDatabase();
            return context.Clients.Select(CreateModel).ToList();
        }
        public List<ClientViewModel> GetFilteredList(ClientBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            using var context = new SoftwareInstallationDatabase();
            return context.Clients.Where(rec => rec.Login == model.Login && rec.Password == model.Password).Select(CreateModel).ToList();
        }
        public ClientViewModel GetElement(ClientBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            using var context = new SoftwareInstallationDatabase();
            var client = context.Clients.FirstOrDefault(rec => rec.Login == model.Login || rec.Id == model.Id);
            return client != null ? CreateModel(client) : null;
        }
        public void Insert(ClientBindingModel model)
        {
            using var context = new SoftwareInstallationDatabase();
            context.Clients.Add(CreateModel(model, new Client()));
            context.SaveChanges();
        }
        public void Update(ClientBindingModel model)
        {
            using var context = new SoftwareInstallationDatabase();
            var client = context.Clients.FirstOrDefault(rec => rec.Id == model.Id);
            if (client == null)
            {
                throw new Exception("Клиент не найден");
            }
            CreateModel(model, client);
            context.SaveChanges();
        }
        public void Delete(ClientBindingModel model)
        {
            using var context = new SoftwareInstallationDatabase();
            Client client = context.Clients.FirstOrDefault(rec => rec.Id == model.Id);
            if (client != null)
            {
                context.Clients.Remove(client);
                context.SaveChanges();
            }
            else
            {
                throw new Exception("Клиент не найден");
            }
        }
        private static Client CreateModel(ClientBindingModel model, Client client)
        {
            client.ClientFIO = model.FIO;
            client.Login = model.Login;
            client.Password = model.Password;
            return client;
        }
        private static ClientViewModel CreateModel(Client client)
        {
            return new ClientViewModel
            {
                Id = client.Id,
                FIO = client.ClientFIO,
                Login = client.Login,
                Password = client.Password
            };
        }
    }
}
