using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EgeAlpProject.ViewModel
{
    public class ImageUploadViewModel2
    {
        public int CarBrandId { get; set; }
        public IFormFile ImageFile { get; set; }
    }
}