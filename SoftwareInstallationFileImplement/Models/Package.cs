using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftwareInstallationFileImplement.Models
{
    public class Package
    {
        public int Id { get; set; }
        public string PackageName { get; set; }
        public decimal Price { get; set; }
        public Dictionary<int, int> PackageComponents { get; set; }
    }
}
