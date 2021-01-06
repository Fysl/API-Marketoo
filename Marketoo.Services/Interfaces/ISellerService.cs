
using Marketoo.Entities.SellerEntities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Marketoo.Services.Interfaces
{
    public interface ISellerService
    {
       
        Task<IEnumerable<SellerEntity>> GetAll(int batteryType, string queryType, int? queryStatus = null, int? pageSize = null, int? pageNumber = null);      
        public Task<SellerEntity> Add(SellerEntity item);
        public Task<SellerEntity> Update(long id, SellerEntity item);
        public Task<SellerEntity> Remove(long id);
    }
}
