using Marketoo.Entities.ProductEntities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Marketoo.Repository.Abstractions.Interfaces
{
    public interface IProductRepository
    {
        
        Task<IEnumerable<ProductEntity>> GetAll(int batteryType,string queryType, int? queryStatus = null, int? pageSize = null, int? pageNumber = null);
        public Task<ProductEntity> Add(ProductEntity item);
        public Task<ProductEntity> Update(long id, ProductEntity item);
        public Task<ProductEntity> Remove(long id);
    }
}
