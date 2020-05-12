﻿using System;
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
        [Display(Name = "Title")]
        public string Name { get; set; }

        [Display(Name = "Car Brand")]
        public int CarBrandId { get; set; }
        public CarBrand CarBrand { get; set; }
        [Display(Name = "Car Model")]
        public string CarModel { get; set; }

        [Display(Name = "Model Year")]
        [Required]
        public int year { get; set; }
        [Display(Name = "Odometer")]
        public int VehicleKm { get; set; }

        [Display(Name = "Fuel")]
        public Fueltype FuelType { get; set; }
        [Display(Name = "Avg Consumption")]
        public int AvgCons { get; set; }
        [Display(Name = "Transmission")]
        public Transmission Tansmission { get; set; }

        [Display(Name = "Daily Price")]
        public Decimal Price { get; set; }
        [Display(Name = "Details")]
        public string Description { get; set; }
        [Display(Name = "City")]
        public City city { get; set; }
        [Display(Name = "Location Details")]
        public string Location { get; set; }

        public DateTime CreatedDate { get; set; }
        public Car()
        {
            CreatedDate = DateTime.Now;
        }

        public enum Fueltype
        {
            Gas,
            Diesel
        }

        public enum City
        {
            Istanbul,
            Ankara,
            Izmir
        }

        public enum Transmission{
            Automatic, Manual
            }
            
            public virtual List<CarImage> CarImages { get; set; }

        }
    }



