using Marketoo.Entities.Entities;
using Marketoo.Repository.Abstractions.Interfaces;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace Marketoo.Repository.Repositories.Repositories
{
   public class OrderRepository: SmartConnectDBFactoryBase,IOrderRepository
    {
        public OrderRepository(IConfiguration config) : base(config)
        {

        }
        public async Task<IEnumerable<OrderEntity>> GetAll()
        {
            var query = $"SELECT * FROM product";

            if (pageSize != null)
            {
                query += $"{Environment.NewLine} LIMIT {pageSize}";
                if (pageNumber != null)
                    query += $" OFFSET  {pageSize * pageNumber}";
            }
            var result = await DbQueryAsync<dynamic>(query);
            return OrderEntityMapper.MapToProductEntities(result);
        }
        public async Task<OrderEntity> GetById(long id)
        {
            var query = "SELECT * FROM product WHERE id = @id";
            var param = new { @id = id };
            var result = await DbQueryAsync<dynamic>(query, param);
            return OrderEntityMapper.MapToProductEntities(result).FirstOrDefault();
        }

        public async Task<OrderEntity> Add(OrderEntity item)
        {
            string query = @"INSERT INTO 
                             product 
                             (
                                 productname
                                ,productimg
                                ,actualprice
                                ,marketprice
                                ,categoryid
                                ,productfor
                                ,labelid
                                ,sizeid
                                ,custom
                                ,description
                                ,createdate
                                ,updatedate
                                ,createdby
                                ,updatedby
                                ,isactive
                                ,isdeleted


                             )
                             VALUES
                             (
                                @productName
                                ,@productIMG
                                ,@actualPrice
                                ,@marketPrice
                                ,@categoryId
                                ,@productFor
                                ,@labelId
                                ,@sizeId
                                ,@custom
                                ,@description
                                ,@createDate
                                ,@updateDate
                                ,@createdBy
                                ,@updatedBy
                                ,@isactive
                                ,@isdeleted 
                             );";
            var param = new
            {
                @productname = item.ProductName,
                @productimg = item.ProductIMG,
                @actualprice = item.ActualPrice,
                @marketprice = item.MarketPrice,
                @categoryid = item.CategoryId,
                @productfor = item.ProductFor,
                @labelid = item.LabelId,
                @sizeid = item.SizeId,
                @custom = item.Custom,
                @description = item.Description,
                @createdate = item.CreateDate,
                @updatedate = item.UpdateDate,
                @createdby = item.CreatedBy,
                @updatedby = item.UpdatedBy,
                @isactive = item.IsActive,
                @isdeleted = item.IsDeleted
            };
            var result = await DbExecuteAsync<OrderEntity>(query, param);
            return result ? await GetById(item.Id) : new OrderEntity();
        }
        public async Task<OrderEntity> Update(long id, OrderEntity item)
        {
            string query = @"UPDATE product 
                             SET   
                                   query_status = @query_status
                                 , modified_date = @modified_date
                                 , start_time = @start_time
                                 , end_time = @end_time
                                 , modified_by = @modified_by
                             WHERE id = @id;";
            var param = new
            {
                @id = id,
                @modified_date = DateTime.Now.ToEpoch(),
            };
            var result = await DbExecuteAsync<OrderEntity>(query, param);
            return result ? await GetById(item.Id) : new OrderEntity();
        }
        public async Task<OrderEntity> Remove(long id)
        {
            string query = @"DELETE FROM product 
                             WHERE id = @id;";
            var param = new
            {
                @id = id
            };
            var result = await DbExecuteAsync<OrderEntity>(query, param);
            return result ? await GetById(id) : new OrderEntity();
        }

    }


}

