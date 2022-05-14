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
   public class MessageInfoStorage : IMessageInfoStorage
    {
        private readonly FileDataListSingleton source;
        public MessageInfoStorage()
        {
            source = FileDataListSingleton.GetInstance();
        }
        public List<MessageInfoViewModel> GetFullList()
        {
            return source.Messages.Select(CreateModel).ToList();
        }
        public List<MessageInfoViewModel> GetFilteredList(MessageInfoBindingModel model)
        {
            if (model == null)
            {
                return null;
            }            
            return source.Messages.Where(rec => (model.ClientId.HasValue && rec.ClientId == model.ClientId) ||
                (!model.ClientId.HasValue && rec.DateDelivery.Date == model.DateDelivery.Date))                
                .Select(CreateModel).ToList();
        }        
        public void Insert(MessageInfoBindingModel model)
        {
            MessageInfo element = source.Messages.FirstOrDefault(rec => rec.MessageId == model.MessageId);
            if (element != null)
            {
                throw new Exception("Уже есть письмо с таким идентификатором");
            }
            source.Messages.Add(CreateModel(model, element));
        }
        public void Update(MessageInfoBindingModel model)
        {
            var element = source.Messages.FirstOrDefault(rec => rec.MessageId == model.MessageId);
            if (element == null)
            {
                throw new Exception("Элемент не найден");
            }
            CreateModel(model, element);
        }
        private MessageInfoViewModel CreateModel(MessageInfo model)
        {
            return new MessageInfoViewModel
            {
                MessageId = model.MessageId,
                SenderName = model.SenderName,
                DateDelivery = model.DateDelivery,
                Subject = model.Subject,
                Body = model.Body,
                Reply = model.Reply,
                IsRead = model.IsRead
            };
        }
        private static MessageInfo CreateModel(MessageInfoBindingModel model, MessageInfo message)
        {
            message.MessageId = model.MessageId;
            message.Body = model.Body;
            message.ClientId = model.ClientId;
            message.DateDelivery = model.DateDelivery;
            message.Subject = model.Subject;
            message.IsRead = model.IsRead;
            message.Reply = model.Reply;
            return message;
        }
    }
}
