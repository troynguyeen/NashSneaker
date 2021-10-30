using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NashSneaker.Data
{
    public class Size
    {
        public int Id { get; set; }
        public int Name { get; set; }
        public virtual Product Product { get; set; }
    }
}
