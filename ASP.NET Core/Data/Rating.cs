using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NashSneaker.Data
{
    public class Rating
    {
        public int Id { get; set; }
        public int Level { get; set; }
        public virtual User User { get; set; }
        public virtual Product Product { get; set; }
    }
}
