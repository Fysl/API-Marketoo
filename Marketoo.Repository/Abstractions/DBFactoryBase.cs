using Dapper;
using Microsoft.Extensions.Configuration;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;

namespace Marketoo.Repository
{
    public abstract class DBFactoryBase
    {
        private readonly IConfiguration _config;
        public DBFactoryBase(IConfiguration config)
        {
            _config = config;
        }

        internal IDbConnection DbConnection
        {
            get
            {
                return new NpgsqlConnection(_config.GetSection("ConnectionStrings:PostgreSqlConnectionString").Value);
            }
        }

        public virtual async Task<IEnumerable<T>> DbQueryAsync<T>(string sql, object parameters = null)
        {
            try
            {
                using (IDbConnection dbCon = DbConnection)
                {
                    dbCon.Open();
                    if (parameters == null)
                        return await dbCon.QueryAsync<T>(sql);

                    return await dbCon.QueryAsync<T>(sql, parameters);
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public virtual async Task<T> DbQuerySingleAsync<T>(string sql, object parameters)
        {
            try
            {
                using (IDbConnection dbCon = DbConnection)
                {
                    dbCon.Open();
                    return await dbCon.QueryFirstOrDefaultAsync<T>(sql, parameters);
                }
            }
            catch (Exception ex)
            {

                throw;
            }
        }
        public virtual async Task<bool> DbExecuteAsync<T>(string sql, object parameters)
        {
            IDbTransaction transaction = null;
            try
            {
                using (IDbConnection dbCon = DbConnection)
                {
                    dbCon.Open();
                    transaction = dbCon.BeginTransaction();
                    var result = await dbCon.ExecuteAsync(sql, parameters) > 0;
                    transaction.Commit();
                    return result;
                }
            }
            catch (Exception ex)
            {
                //transaction.Rollback();
                throw;
            }
        }
        public virtual async Task<bool> DbExecuteWithImplicitTransactionAsync<T>(string sql, object parameters)
        {
            try
            {
                using (IDbConnection dbCon = DbConnection)
                {
                    var result = await dbCon.ExecuteAsync(sql, parameters) > 0;
                    return result;
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public virtual async Task<bool> DbExecuteScalarAsync(string sql, object parameters)
        {
            try
            {
                using (IDbConnection dbCon = DbConnection)
                {
                    dbCon.Open();
                    return await dbCon.ExecuteScalarAsync<bool>(sql, parameters);
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
