using AutoMapper;
using Marketoo.Entities.ProductEntities;
using Marketoo.Entities.SellerEntities;
using Marketoo.WebAPI.API.v1.Models.ProductRequests;
using Marketoo.WebAPI.API.v1.Models.ProductResponse;
using Marketoo.WebAPI.API.v1.Models.SellerRequests;
using Marketoo.WebAPI.API.v1.Models.SellerResponse;
using Marketoo.WebAPI.API.v1.Models.Shared;

namespace Marketoo.WebAPI.Helpers
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<ProductRequest, ProductEntity>();
            CreateMap<ProductEntity, ProductResponse>();

            CreateMap<SellerRequest, SellerEntity>();
            CreateMap<SellerEntity, SellerResponse>();

        }
    }
}
