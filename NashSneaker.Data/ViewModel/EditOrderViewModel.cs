using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NashSneaker.Data.ViewModel
{
    public class EditOrderViewModel
    {
        public int Id { get; set; }
        public string RecipientName { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public string PaymentMethod { get; set; }
        public string Status { get; set; }
    }
}
