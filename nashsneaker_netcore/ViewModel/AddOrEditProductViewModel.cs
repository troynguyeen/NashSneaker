using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace NashSneaker.ViewModel
{
    public class AddOrEditProductViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Price { get; set; }
        public string Description { get; set; }
        public int CategoryId { get; set; }
        public List<string> Sizes { get; set; }
        public List<string> imagesName { get; set; }
        public List<IFormFile> imagesFile { get; set; }
        public List<string> imagesDelete { get; set; }
    }
}
