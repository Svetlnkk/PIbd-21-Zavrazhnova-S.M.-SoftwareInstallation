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
        /// Получение списка заказов за определенный период
        List<ReportOrdersViewModel> GetOrders(ReportBindingModel model);
        /// Сохранение компонент в файл-Word
        void SaveComponentsToWordFile(ReportBindingModel model);
        /// Сохранение компонент с указаеним продуктов в файл-Excel
        void SavePackageComponentToExcelFile(ReportBindingModel model);
        /// Сохранение заказов в файл-Pdf
        void SaveOrdersToPdfFile(ReportBindingModel model);
    }
}
