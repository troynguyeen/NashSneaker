using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NashSneaker.Data
{
    public class Order
    {
        public int Id { get; set; }
        public string RecipientName { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public string PaymentMethod { get; set; }
        public int TotalAmount { get; set; }
        public int ShippingFee { get; set; }
        public string Status { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime DeliveryDate { get; set; }
        public virtual User User { get; set; }
        public virtual List<OrderDetail> OrderDetails { get; set; }

    }
}
