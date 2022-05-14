using SoftwareInstallationContracts.BindingModels;
using SoftwareInstallationContracts.BusinessLogicsContracts;
using SoftwareInstallationContracts.StoragesContracts;
using SoftwareInstallationContracts.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftwareInstallationBusinessLogic.BusinessLogics
{
   public class MessageInfoLogic : IMessageInfoLogic
    {
        private readonly IMessageInfoStorage messageInfoStorage;
        public MessageInfoLogic(IMessageInfoStorage messageInfoStorage)
        {
            this.messageInfoStorage = messageInfoStorage;
        }
        public List<MessageInfoViewModel> Read(MessageInfoBindingModel model)
        {
            if (model == null)
            {
                return messageInfoStorage.GetFullList();
            }            
            return messageInfoStorage.GetFilteredList(model);
        }
        public void CreateOrUpdate(MessageInfoBindingModel model)
        {            
            if (model.IsRead == false || !string.IsNullOrEmpty(model.Reply))
            {
                messageInfoStorage.Update(model);
            }
            else
            {
                messageInfoStorage.Insert(model);
            }
        }
    }
}
