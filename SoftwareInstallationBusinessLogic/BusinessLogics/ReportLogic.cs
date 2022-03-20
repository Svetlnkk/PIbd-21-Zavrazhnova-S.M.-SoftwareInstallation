using SoftwareInstallationBusinessLogic.OfficePackage;
using SoftwareInstallationBusinessLogic.OfficePackage.HelperModels;
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
    public class ReportLogic : IReportLogic
    {
        private readonly IComponentStorage _componentStorage;
        private readonly IPackageStorage _packageStorage;
        private readonly IOrderStorage _orderStorage;
        private readonly AbstractSaveToExcel _saveToExcel;
        private readonly AbstractSaveToWord _saveToWord;
        private readonly AbstractSaveToPdf _saveToPdf;
        public ReportLogic(IPackageStorage packageStorage, IComponentStorage componentStorage, IOrderStorage orderStorage,
        AbstractSaveToExcel saveToExcel, AbstractSaveToWord saveToWord, AbstractSaveToPdf saveToPdf)
        {
            _packageStorage = packageStorage;
            _componentStorage = componentStorage;
            _orderStorage = orderStorage;
            _saveToExcel = saveToExcel;
            _saveToWord = saveToWord;
            _saveToPdf = saveToPdf;
        }
        /// Получение списка компонент с указанием, в каких изделиях используются
        public List<ReportPackageComponentViewModel> GetPackageComponent()
        {
            var components = _componentStorage.GetFullList();
            var packages = _packageStorage.GetFullList();
            var list = new List<ReportPackageComponentViewModel>();
            foreach (var component in components)
            {
                var record = new ReportPackageComponentViewModel
                {
                    ComponentName = component.ComponentName,
                    Packages = new List<Tuple<string, int>>(),
                    TotalCount = 0
                };
                foreach (var package in packages)
                {
                    if (package.PackageComponents.ContainsKey(component.Id))
                    {
                        record.Packages.Add(new Tuple<string, int>(package.PackageName,
                       package.PackageComponents[component.Id].Item2));
                        record.TotalCount += package.PackageComponents[component.Id].Item2;
                    }
                }
                list.Add(record);
            }
            return list;
        }
        /// Получение списка заказов за определенный период
        public List<ReportOrdersViewModel> GetOrders(ReportBindingModel model)
        {
            return _orderStorage.GetFilteredList(new OrderBindingModel
            {
                DateFrom = model.DateFrom,
                DateTo = model.DateTo
            })
            .Select(x => new ReportOrdersViewModel
            {
                DateCreate = x.DateCreate,
                PackageName = x.PackageName,
                Count = x.Count,
                Sum = x.Sum,
                Status = x.Status
            })
           .ToList();
        }
        /// Сохранение компонент в файл-Word
        public void SaveComponentsToWordFile(ReportBindingModel model)
        {
            _saveToWord.CreateDoc(new WordInfo
            {
                FileName = model.FileName,
                Title = "Список компонент",
                Components = _componentStorage.GetFullList()
            });
        }
        /// Сохранение компонент с указаеним продуктов в файл-Excel
        public void SavePackageComponentToExcelFile(ReportBindingModel model)
        {
            _saveToExcel.CreateReport(new ExcelInfo
            {
                FileName = model.FileName,
                Title = "Список компонент",
                PackageComponents = GetPackageComponent()
            });
        }
        /// Сохранение заказов в файл-Pdf
        public void SaveOrdersToPdfFile(ReportBindingModel model)
        {
            _saveToPdf.CreateDoc(new PdfInfo
            {
                FileName = model.FileName,
                Title = "Список заказов",
                DateFrom = model.DateFrom.Value,
                DateTo = model.DateTo.Value,
                Orders = GetOrders(model)
            });
        }

    }
}
