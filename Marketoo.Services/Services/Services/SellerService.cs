using Marketoo.Entities.SellerEntities;
using Marketoo.Repository.Abstractions.Interfaces;
using Marketoo.Services.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Marketoo.Services.Services.SellerServices
{
    public class SellerService : ISellerService
    {
        private readonly ISellerRepository _SellerRepository;
        public SellerService(ISellerRepository SellerRepository)
        {
            _SellerRepository = SellerRepository;
        }

        public async Task<IEnumerable<SellerEntity>> GetAll(int batteryType ,string queryType, int? queryStatus = null, int? pageSize = null, int? pageNumber = null) => await _SellerRepository.GetAll(batteryType,queryType, queryStatus, pageSize, pageNumber);
        public async Task<SellerEntity> Add(SellerEntity item) => await _SellerRepository.Add(item);
        public async Task<SellerEntity> Update(long id, SellerEntity item)
        {
            item.Id = id;
            return await _SellerRepository.Update(id, item);
        }
        public async Task<SellerEntity> Remove(long id) => await _SellerRepository.Remove(id);


    }
}
