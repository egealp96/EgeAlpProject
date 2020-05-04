using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EgeAlpProject.Models
{
    public class Comment
    {

        public int Id { get; set; }
        public string Title { get; set; }
        public string Detail { get; set; }

        public int? Rating { get; set; }
        public DateTime CreatedDate { get; set; }

        public int RentalId { get; set; }
        public Rental Rental { get; set; }


    }
}
