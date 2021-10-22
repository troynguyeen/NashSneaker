using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NashSneaker.Areas.Identity.Data
{
    public class Image
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }
        public virtual Product Product { get; set; }
    }
}
