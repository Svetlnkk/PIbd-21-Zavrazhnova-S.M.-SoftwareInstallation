using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftwareInstallationContracts.BindingModels
{
    public class PackageBindingModel
    {
        public int? Id { get; set; }

        public string PackageName { get; set; }

        public decimal Price { get; set; }

        public Dictionary<int, (string, int)> PackageComponents { get; set; }
    }
}
