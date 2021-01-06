using System;
using System.Collections.Generic;
using System.Text;

namespace Marketoo.Entities.Entities
{
    public class OrderEntity
    {
        public long Id { get; set; }
        public long SId { get; set; }
        public long PaymentId { get; set; }
        public DateTime OrderDate { get; set; }
        public string OrderStatus { get; set; }
        public string PaymentStatus { get; set; }
        public decimal TotalAmount { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime UpdateDate { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }

        public List<OrderProductEntity> OrderProduct { get; set; }

        
    }

    public class OrderProductEntity
    {
        public long Id { get; set; }

        public long OId { get; set; }

        public long PId { get; set; }

        public int Quantity { get; set; }

        public decimal UnitPrice { get; set; }

        public DateTime CreateDate { get; set; }
        public DateTime UpdateDate { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }

    }
}
