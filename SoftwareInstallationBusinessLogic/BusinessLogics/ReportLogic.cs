using SoftwareInstallationBusinessLogic.OfficePackage;
using SoftwareInstallationBusinessLogic.OfficePackage.HelperModels;
using SoftwareInstallationContracts.BindingModels;
using SoftwareInstallationContracts.BusinessLogicsContracts;
using SoftwareInstallationContracts.Enums;
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
        private readonly IWarehouseStorage _warehouseStorage;
        private readonly AbstractSaveToExcel _saveToExcel;
        private readonly AbstractSaveToWord _saveToWord;
        private readonly AbstractSaveToPdf _saveToPdf;
        public ReportLogic(IPackageStorage packageStorage, IComponentStorage componentStorage, IOrderStorage orderStorage,
            IWarehouseStorage warehouseStorage, AbstractSaveToExcel saveToExcel, AbstractSaveToWord saveToWord, AbstractSaveToPdf saveToPdf)
        {
            _packageStorage = packageStorage;
            _componentStorage = componentStorage;
            _orderStorage = orderStorage;
            _saveToExcel = saveToExcel;
            _saveToWord = saveToWord;
            _saveToPdf = saveToPdf;
            _warehouseStorage = warehouseStorage;
        }
        /// Получение списка компонент с указанием, в каких изделиях используются
        public List<ReportPackageComponentViewModel> GetPackageComponent()
        {
            var packages = _packageStorage.GetFullList();
            var list = new List<ReportPackageComponentViewModel>();
            foreach (var pc in packages)
            {
                var record = new ReportPackageComponentViewModel
                {
                    PackageName = pc.PackageName,
                    Components = new List<Tuple<string, int>>(),
                    TotalCount = 0
                };
                foreach (var package in pc.PackageComponents)
                {                    
                        record.Components.Add(new Tuple<string, int>(package.Value.Item1,package.Value.Item2));
                        record.TotalCount += package.Value.Item2;                  
                }
                list.Add(record);
            }
            return list;
        }
        public List<ReportWarehouseComponentViewModel> GetWarehouseComponent()
        {
            var warehouses = _warehouseStorage.GetFullList();
            var list = new List<ReportWarehouseComponentViewModel>();
            foreach (var warehouse in warehouses)
            {
                var record = new ReportWarehouseComponentViewModel
                {
                    WarehouseName = warehouse.WarehouseName,
                    Components = new List<Tuple<string, int>>(),
                    TotalCount = 0
                };
                foreach (var component in warehouse.WarehouseComponents)
                {
                    record.Components.Add(new Tuple<string, int>(component.Value.Item1, component.Value.Item2));
                    record.TotalCount += component.Value.Item2;
                }
                list.Add(record);
            }
            return list;
        }
        public List<ReportOrdersDateViewModel> GetOrdersDate()
        {
            return _orderStorage.GetFullList()
            .GroupBy(rec => rec.DateCreate.ToShortDateString())
            .Select(x => new ReportOrdersDateViewModel
            {
                DateCreate = Convert.ToDateTime(x.Key),
                Count = x.Count(),
                Sum = x.Sum(rec => rec.Sum)
            })
           .ToList();
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
                Status = Enum.GetName(typeof(OrderStatus),x.Status),
                ClientFIO = x.ClientFIO
            })
           .ToList();
        }
        /// Сохранение компонент в файл-Word
        public void SaveComponentsToWordFile(ReportBindingModel model)
        {
            _saveToWord.CreateDoc(new WordInfo
            {
                FileName = model.FileName,
                Title = "Список изделий",
                Packages = _packageStorage.GetFullList()
            });
        }
        public void SaveWarehousesToWordFile(ReportBindingModel model)
        {
            _saveToWord.CreateDocWarehouse(new WordInfo
            {
                FileName = model.FileName,
                Title = "Список складов",
                Warehouses = _warehouseStorage.GetFullList()
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
        public void SaveWarehouseComponentToExcelFile(ReportBindingModel model)
        {
            _saveToExcel.CreateReportWarehouse(new ExcelInfo
            {
                FileName = model.FileName,
                Title = "Список компонент",
                WarehouseComponents = GetWarehouseComponent()
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
        public void SaveOrdersDateToPdfFile(ReportBindingModel model)
        {
            _saveToPdf.CreateDocOrdersDate(new PdfInfo
            {
                FileName = model.FileName,
                Title = "Список заказов по датам",
                OrdersDate = GetOrdersDate()
            });
        }

    }
}
