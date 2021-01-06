using Marketoo.Entities.ProductEntities;
using System.Collections.Generic;

namespace Marketoo.Repository.Mapper
{
    public class ProductEntityMapper
    {
        public static ProductEntity MapToProductEntity(dynamic data)
        {
            return data != null
                ? new ProductEntity
                {
                    Id = data.id,
                    ProductName = data.productname,
                    ProductFor = data.productfor,
                    ProductIMG = data.productimg,
                    Description = data.description,
                    ActualPrice = data.actualprice,
                    MarketPrice = data.marketprice,
                    LabelId = data.labelid,
                    SizeId = data.sizeid,
                    Custom = data.custom,
                    CategoryId = data.categoryid,
                    CreateDate = data.createdate,
                    UpdateDate = data.updatedate,
                    CreatedBy=data.createdby,
                    UpdatedBy=data.updatedby,
                    IsActive=data.isactive,
                    IsDeleted=data.isdeleted
                }
                : null;
        }

        public static List<ProductEntity> MapToProductEntities(dynamic data)
        {
            List<ProductEntity> Product = new List<ProductEntity>();
            foreach (var dapperRow in data)
            {
                Product.Add(MapToProductEntity(dapperRow));
            }
            return Product;
        }
    }
}
