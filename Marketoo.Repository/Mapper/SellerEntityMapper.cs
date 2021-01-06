using Marketoo.Entities.SellerEntities;
using System.Collections.Generic;

namespace Marketoo.Repository.Mapper
{
    public class SellerEntityMapper
    {
        public static SellerEntity MapToSellerEntity(dynamic data)
        {
            return data != null
                ? new SellerEntity
                {
                    Id = data.id,                 
                    FirstName = data.firstname,
                    LastName = data.lastname,
                    SellerIMG=data.sellerimg,
                    ShopName=data.shopname,
                    ShopLocation=data.shoplocation,
                    GenderId=data.genderid,
                    IsActive = data.isactive,
                    IsDeleted=data.isdeleted,
                    CreateDate = data.createdate,
                    UpdateDate = data.updatedate,
                    UpdatedBy=data.updatedby,
                    CreatedBy=data.createdby
                }
                : null;
        }

        public static List<SellerEntity> MapToSellerEntities(dynamic data)
        {
            List<SellerEntity> Seller = new List<SellerEntity>();
            foreach (var dapperRow in data)
            {
                Seller.Add(MapToSellerEntity(dapperRow));
            }
            return Seller;
        }
    }
}
