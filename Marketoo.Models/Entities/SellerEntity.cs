using System;

namespace Marketoo.Entities.SellerEntities
{
    public class SellerEntity
    {
        public long Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public byte[] SellerIMG { get; set; }
        public string ShopName { get; set; }
        public string ShopLocation { get; set; }
        public long GenderId { get; set; }
        public string ShopDescription { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime UpdateDate { get; set; }
        public string CreatedBy { get; set; }

        public string UpdatedBy { get; set; }
    }
}
