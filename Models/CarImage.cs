using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EgeAlpProject.Models
{
    public class CarImage
    {

        public int Id { get; set; }
        public int CarId { get; set; }
        public string FileName { get; set; }
        public bool IsDefaultImage { get; set; }
        public virtual Car Car { get; set; }

    }
}
