using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NashSneaker.Data
{
    public class Cart
    {
        public int Id { get; set; }
        public int TotalAmount { get; set; }
        public virtual User User{ get; set; }
        public virtual List<CartDetail> CartDetails { get; set; }
    }
}
