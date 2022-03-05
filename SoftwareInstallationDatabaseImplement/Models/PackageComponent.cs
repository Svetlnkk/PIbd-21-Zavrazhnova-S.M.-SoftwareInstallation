using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SoftwareInstallationDatabaseImplement.Models
{
    public class PackageComponent
    {
        public int Id { get; set; }
        public int PackageId { get; set; }
        public int ComponentId { get; set; }
        [Required]
        public int Count { get; set; }
        public virtual Component Component { get; set; }
        public virtual Package Package { get; set; }
    }
}
