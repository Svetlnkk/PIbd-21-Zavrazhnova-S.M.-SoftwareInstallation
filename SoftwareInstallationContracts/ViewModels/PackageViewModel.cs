using SoftwareInstallationContracts.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftwareInstallationContracts.ViewModels
{
    public class PackageViewModel
    {
        [Column(title: "Номер", width: 80)]
        public int Id { get; set; }
        [Column(title: "Название пакета", width: 180)]
        public string PackageName { get; set; }
        [Column(title: "Цена", width: 60)]
        public decimal Price { get; set; }
        [Column(title: "Компоненты", gridViewAutoSize: GridViewAutoSize.Fill)]
        public Dictionary<int, (string, int)> PackageComponents { get; set; }
    }
}
