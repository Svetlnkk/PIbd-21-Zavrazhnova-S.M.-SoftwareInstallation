using SoftwareInstallationContracts.BindingModels;
using SoftwareInstallationContracts.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftwareInstallationContracts.BusinessLogicsContracts
{
    public interface IReportLogic
    {
        /// Получение списка компонент с указанием, в каких изделиях используются
        List<ReportPackageComponentViewModel> GetPackageComponent();
        List<ReportWarehouseComponentViewModel> GetWarehouseComponent();
        /// Получение списка заказов за определенный период
        List<ReportOrdersViewModel> GetOrders(ReportBindingModel model);
        List<ReportOrdersDateViewModel> GetOrdersDate();
        /// Сохранение компонент в файл-Word
        void SaveComponentsToWordFile(ReportBindingModel model);
        void SaveWarehousesToWordFile(ReportBindingModel model);
        /// Сохранение компонент с указаеним продуктов в файл-Excel
        void SavePackageComponentToExcelFile(ReportBindingModel model);
        void SaveWarehouseComponentToExcelFile(ReportBindingModel model);
        /// Сохранение заказов в файл-Pdf
        void SaveOrdersToPdfFile(ReportBindingModel model);
        void SaveOrdersDateToPdfFile(ReportBindingModel model);
    }
}
