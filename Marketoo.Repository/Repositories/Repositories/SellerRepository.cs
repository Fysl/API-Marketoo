using Microsoft.Extensions.Configuration;
using Marketoo.Common.Extentions;
using Marketoo.Entities.SellerEntities;
using Marketoo.Repository.Abstractions.Interfaces;
using Marketoo.Repository.Mapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Marketoo.Repository.Repositories.SellerRepositories
{
    public class SellerRepository : SmartConnectDBFactoryBase, ISellerRepository
    {
        public SellerRepository(IConfiguration config) : base(config)
        {

        }

        public async Task<IEnumerable<SellerEntity>> GetAll(int batteryType, string queryType, int? queryStatus = null, int? pageSize = null, int? pageNumber = null)
        {
            var query = $"SELECT * FROM seller";

            if (pageSize != null)
            {
                query += $"{Environment.NewLine} LIMIT {pageSize}";
                if (pageNumber != null)
                    query += $" OFFSET  {pageSize * pageNumber}";
            }
            var result = await DbQueryAsync<dynamic>(query);
            return SellerEntityMapper.MapToSellerEntities(result);
        }
        public async Task<SellerEntity> GetById(long id)
        {
            var query = "SELECT * FROM seller WHERE id = @id";
            var param = new { @id = id };
            var result = await DbQueryAsync<dynamic>(query, param);
            return SellerEntityMapper.MapToSellerEntities(result).FirstOrDefault();
        }
        public async Task<SellerEntity> Add(SellerEntity item)
        {
            string query = @"INSERT INTO 
                             seller 
                             (
                              
                               firstname
                               ,lastname
                               ,shopname
                               ,shoplocation
                               ,genderid 
                               ,shopdescription
                               ,isactive
                               ,isdeleted
                               ,createdate
                               ,updatedate
                               ,createdby
                               ,updatedby
                               ,sellerimg
                             )
                             VALUES
                             (
                              
                               @firstname
                               ,@lastname
                               ,@shopname
                               ,@shoplocation
                               ,@genderid 
                               ,@shopdescription
                               ,@isactive     
                               ,@isdeleted
                               ,@createdate
                               ,@updatedate
                               ,@createdby
                               ,@updatedby
                               ,@sellerimg
                                );";
            var param = new
            {
                @firstname = item.FirstName,
                @lastname = item.LastName,
                @shopname = item.ShopName,
                @shoplocation = item.ShopLocation,
                @genderid = item.GenderId,
                @shopdescription = item.ShopDescription,
                @isactive = item.IsActive,
                @isdeleted = item.IsDeleted,
                @createdate = item.CreateDate,
                @updatedate = item.UpdateDate,
                @createdby = item.CreatedBy,
                @updatedby = item.UpdatedBy,
                @sellerimg = item.SellerIMG,
            };
            var result = await DbExecuteAsync<SellerEntity>(query, param);
            return result ? await GetById(item.Id) : new SellerEntity();
        }
        public async Task<SellerEntity> Update(long id, SellerEntity item)
        {
            string query = @"UPDATE seller
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
            var result = await DbExecuteAsync<SellerEntity>(query, param);
            return result ? await GetById(item.Id) : new SellerEntity();
        }
        public async Task<SellerEntity> Remove(long id)
        {
            string query = @"DELETE FROM seller
                             WHERE id = @id;";
            var param = new
            {
                @id = id
            };
            var result = await DbExecuteAsync<SellerEntity>(query, param);
            return result ? await GetById(id) : new SellerEntity();
        }

    }
}
