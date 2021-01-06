using Marketoo.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Marketoo.Repository.Mapper
{
  public static  class OrderEntityMapper
    {
        public static OrderEntity MapToOrderEntity(dynamic data)
        {
            return data != null
                ? new OrderEntity
                {

                    Id = data.id,
                    SId = data.sid,
                    OrderDate = data.orderdate,
                    OrderStatus = data.orderstatus,       
                    CreateDate = data.createdate,
                    UpdateDate = data.updatedate,
                    CreatedBy = data.createdby,
                    UpdatedBy = data.updatedby,
                    IsActive = data.isactive,
                    IsDeleted = data.isdeleted,
                    OrderProduct=data.orderproduct
                    
                }
                : null;
        }

        public static List<OrderEntity> MapToOrderEntities(dynamic data)
        {
            List<OrderEntity> order = new List<OrderEntity>();
            foreach (var dapperRow in data)
            {
                order.Add(MapToOrderEntity(dapperRow));
            }
            return order;
        }
    }
}

