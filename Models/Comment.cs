using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EgeAlpProject.Models
{
    public class Comment
    {

        public int Id { get; set; }
        [Required (ErrorMessage = "You have write a Title.")]
        public string Title { get; set; }
        [Required(ErrorMessage = "Details of your Comment.")]
        public string Detail { get; set; }
        [Required(ErrorMessage = "You have to Rate renter.")]
        public int? Rating { get; set; }
        public DateTime CreatedDate { get; set; }

        public int CarId { get; set; }
        public Car Car { get; set; }


    }
}
