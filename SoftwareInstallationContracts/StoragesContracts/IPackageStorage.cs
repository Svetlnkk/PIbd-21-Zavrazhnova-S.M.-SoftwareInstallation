using System;
using SoftwareInstallationContracts.BindingModels;
using SoftwareInstallationContracts.ViewModels;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftwareInstallationContracts.StoragesContracts
{
   public interface IPackageStorage
    {
        List<PackageViewModel> GetFullList();
        List<PackageViewModel> GetFilteredList(PackageBindingModel model);
        PackageViewModel GetElement(PackageBindingModel model);
        void Insert(PackageBindingModel model);
        void Update(PackageBindingModel model);
        void Delete(PackageBindingModel model);
    }
}
