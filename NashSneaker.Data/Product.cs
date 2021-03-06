using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NashSneaker.Data
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public float Price { get; set; }
        public string Description { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public virtual Category Category { get; set; }
        public virtual List<Image> Images { get; set; }
        public virtual List<Rating> Ratings { get; set; }
        public virtual List<CartDetail> CartDetails { get; set; }
        public virtual List<Size> Sizes { get; set; }
    }
}
