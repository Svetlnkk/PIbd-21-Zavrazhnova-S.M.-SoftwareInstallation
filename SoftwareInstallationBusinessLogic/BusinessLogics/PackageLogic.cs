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
    public class PackageLogic : IPackageLogic
    {
        private readonly IPackageStorage _packageStorage;
        public PackageLogic(IPackageStorage packageStorage)
        {
            _packageStorage = packageStorage;
        }
        public List<PackageViewModel> Read(PackageBindingModel model)
        {
            if (model == null)
            {
                return _packageStorage.GetFullList();
            }
            if (model.Id.HasValue)
            {
                return new List<PackageViewModel> { _packageStorage.GetElement(model) };
            }
            return _packageStorage.GetFilteredList(model);
        }
        public void CreateOrUpdate(PackageBindingModel model)
        {
            var element = _packageStorage.GetElement(new PackageBindingModel { PackageName = model.PackageName });
            if (element != null && element.Id != model.Id)
            {
                throw new Exception("Уже есть изделие с таким названием");
            }
            if (model.Id.HasValue)
            {
                _packageStorage.Update(model);
            }
            else
            {
                _packageStorage.Insert(model);
            }
        }

        public void Delete(PackageBindingModel model)
        {
            var element = _packageStorage.GetElement(new PackageBindingModel { Id = model.Id });
            if (element == null)
            {
                throw new Exception("Элемент не найден");
            }
            _packageStorage.Delete(model);
        }
    }
}
