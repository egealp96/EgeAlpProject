using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EgeAlpProject.Models
{
    public class CarBrandImage
    {
        public int Id { get; set; }
        public int CarBrandId { get; set; }
        public string FileName { get; set; }
        public bool IsDefaultImage { get; set; }
        public virtual CarBrand CarBrand { get; set; }
    }
}
