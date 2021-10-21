using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NashSneaker.Areas.Identity.Data
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public virtual List<Product> Products { get; set; }
    }
}
