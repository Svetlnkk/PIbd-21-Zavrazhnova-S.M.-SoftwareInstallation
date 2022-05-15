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
        public string GetComponents()
        {
            string stringComponents = string.Empty;
            if (PackageComponents != null)
            {
                foreach (var component in PackageComponents)
                {
                    stringComponents += component.Value.Item1 + " = " + component.Value.Item2 + " шт.; ";
                }
            }
            return stringComponents;
        }
    }
}
