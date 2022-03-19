using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SoftwareInstallationDatabaseImplement.Models
{
    public class Package
    {
        public int Id { get; set; }
        [Required]
        public string PackageName { get; set; }
        [Required]
        public decimal Price { get; set; }

        [ForeignKey("PackageId")]
        public virtual List<PackageComponent> PackageComponents { get; set; }
        [ForeignKey("PackageId")]
        public virtual List<Order> Orders { get; set; }
    }
}
