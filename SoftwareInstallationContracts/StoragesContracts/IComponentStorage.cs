using System;
using SoftwareInstallationContracts.BindingModels;
using SoftwareInstallationContracts.ViewModels;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftwareInstallationContracts.StoragesContracts
{
    public interface IComponentStorage
    {
        List<ComponentViewModel> GetFullList();

        List<ComponentViewModel> GetFilteredList(ComponentBindingModel model);

        ComponentViewModel GetElement(ComponentBindingModel model);

        void Insert(ComponentBindingModel model);

        void Update(ComponentBindingModel model);

        void Delete(ComponentBindingModel model);
    }
}
