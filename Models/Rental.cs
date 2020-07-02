using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EgeAlpProject.Models
{
    public class Rental
    {

        public int Id { get; set; }

        public int CarId { get; set; }

        public Car Car { get; set; }

        public DateTime DateRented { get; set; }

        public DateTime? DateReturned { get; set; }

        public DateTime CreatedDate { get; set; }
        public decimal TotalPrice { get; set; }

        public Rental()
        {
            CreatedDate = DateTime.Now;
        }
    }
}
