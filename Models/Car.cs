using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EgeAlpProject.Models
{

        public class Car
        {

            public int Id { get; set; }

            [Required]
            [StringLength(255)]
            [Display(Name = "Baslik")]
            public string Name { get; set; }

            [Display(Name = "Aracin Markasi")]
            public int CarBrandId { get; set; }
            public CarBrand CarBrand { get; set; }
            [Display(Name = "Aracin modeli")]
            public string CarModel { get; set; }

            [Display(Name = "Model Senesi")]
            [Required]
            public int year { get; set; }
            [Display(Name = "KMsi")]
            public int VehicleKm { get; set; }
           
            [Display(Name = "Yakit Tipi")]
            public Fueltype FuelType { get; set; }
            [Display(Name = "Ortalama Yakit Tuketimi")]
            public int AvgCons { get; set; }
            [Display(Name = "Gunluk Fiyat")]
            public Decimal Price { get; set; }
            [Display(Name = "Aciklama")]
            public string Description { get; set; }
            [Display(Name = "Konum Bilgisi")]
            public string Location { get; set; }

            public DateTime CreatedDate { get; set; }
            public Car()
            {
                CreatedDate = DateTime.Now;
            }

            public enum Fueltype
        {
            Benzinli,
            Dizel
        }
            
            public virtual List<CarImage> CarImages { get; set; }

        }
    }



