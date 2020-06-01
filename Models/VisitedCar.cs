using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EgeAlpProject.Models
{
    public class VisitedCar
    {
        public int Id { get; set; }
        public int CarId { get; set; }
        public string SessionId { get; set; }

        public DateTime VisitedDate { get; set; }
    }
}
