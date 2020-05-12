using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EgeAlpProject.ViewModel
{
    public class SearchViewModel
    {
        [Display(Name = "Search Text")]
        public string SearchText { get; set; }
        [Display(Name = "Search In Description")]
        public bool SearchInDescription { get; set; }
        [Display(Name = "Choose Car Brand")]
        public int? CarBrandId { get; set; }

        [Display(Name = "Min Price")]
        public int? MinimumPrice { get; set; }
        [Display(Name = "Max Price")]
        public int? MaximumPrice { get; set; }
        public List<Models.Car> Results { get; set; }
    }
}
