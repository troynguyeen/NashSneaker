using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NashSneaker.Data
{
    public class OrderDetail
    {
        public int Id { get; set; }
        public int Quantity { get; set; }
        public int Size { get; set; }
        public virtual Product Product { get; set; }
        public virtual Order Order { get; set; }
    }
}
