using Marketoo.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Marketoo.Repository.Abstractions.Interfaces
{
  public interface IOrderRepository
    {
        Task<IEnumerable<OrderEntity>> GetAll();
        public Task<OrderEntity> Add(OrderEntity item);
        public Task<OrderEntity> Update(long id, OrderEntity item);
        public Task<OrderEntity> Remove(long id);
    }
}
