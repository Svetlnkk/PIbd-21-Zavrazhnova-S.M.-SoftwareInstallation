using SoftwareInstallationBusinessLogic.OfficePackage.HelperEnums;
using SoftwareInstallationBusinessLogic.OfficePackage.HelperModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftwareInstallationBusinessLogic.OfficePackage
{
    public abstract class AbstractSaveToPdf
    {
        public void CreateDoc(PdfInfo info)
        {
            CreatePdf(info);
            CreateParagraph(new PdfParagraph
            {
                Text = info.Title,
                Style = "NormalTitle"
            });
            CreateParagraph(new PdfParagraph
            {
                Text = $"с { info.DateFrom.ToShortDateString() } по { info.DateTo.ToShortDateString() }", Style = "Normal"});
            CreateTable(new List<string> { "3cm", "6cm", "3cm", "2cm", "3cm" });
            CreateRow(new PdfRowParameters
            {
                Texts = new List<string> { "Дата заказа", "Изделие", "Количество","Сумма", "Статус" },
                Style = "NormalTitle",
                ParagraphAlignment = PdfParagraphAlignmentType.Center
            });
            foreach (var order in info.Orders)
            {
                CreateRow(new PdfRowParameters
                {
                    Texts = new List<string> { order.DateCreate.ToShortDateString(),order.PackageName, order.Count.ToString(), order.Sum.ToString(), order.Status.ToString()},  
                    Style = "Normal",
                    ParagraphAlignment = PdfParagraphAlignmentType.Left
                });
            }
            decimal sum = info.Orders.Sum(rec => rec.Sum);
            CreateParagraph(new PdfParagraph
            {
                Text = $"Итого: {sum}",
                Style = "NormalTitle",
            });
            SavePdf(info);
        }
        /// Создание doc-файла
        protected abstract void CreatePdf(PdfInfo info);
        /// Создание параграфа с текстом        
        protected abstract void CreateParagraph(PdfParagraph paragraph);
        /// Создание таблицы        
        protected abstract void CreateTable(List<string> columns);
        /// Создание и заполнение строки
        protected abstract void CreateRow(PdfRowParameters rowParameters);
        /// Сохранение файла        
        protected abstract void SavePdf(PdfInfo info);
    }
}
