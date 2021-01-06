using Marketoo.Entities.ProductEntities;
using Marketoo.Repository.Abstractions.Interfaces;
using Marketoo.Services.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Marketoo.Services.Services.ProductServices
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _ProductRepository;
        public ProductService(IProductRepository ProductRepository)
        {
            _ProductRepository = ProductRepository;
        }

        public async Task<IEnumerable<ProductEntity>> GetAll(int batteryType ,string queryType, int? queryStatus = null, int? pageSize = null, int? pageNumber = null) => await _ProductRepository.GetAll(batteryType,queryType, queryStatus, pageSize, pageNumber);
        public async Task<ProductEntity> Add(ProductEntity item) => await _ProductRepository.Add(item);
        public async Task<ProductEntity> Update(long id, ProductEntity item)
        {
            item.Id = id;
            return await _ProductRepository.Update(id, item);
        }
        public async Task<ProductEntity> Remove(long id) => await _ProductRepository.Remove(id);


    }
}
