using System;

namespace Marketoo.WebAPI.API.v1.Models.ProductResponse
{
    public class ProductResponse
    {
        public long Id { get; set; }
        public string ProductName { get; set; }
        public byte[] ProductIMG { get; set; }
        public decimal ActualPrice { get; set; }
        public string Description { get; set; }
        public decimal MarketPrice { get; set; }
        public long CategoryId { get; set; }
        public string ProductFor { get; set; }
        public long LabelId { get; set; }
        public long SizeId { get; set; }
        public bool Custom { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }

        public DateTime CreateDate { get; set; }
        public DateTime UpdateDate { get; set; }

        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
    }
}
