using Dapper;
using Microsoft.Extensions.Configuration;
using Npgsql;
using Marketoo.Common.Extentions;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;
using static Marketoo.Common.Constants.CommonConstants;

namespace Marketoo.Repository
{
    public abstract class SmartConnectDBFactoryBase : DBFactoryBase
    {
        private readonly IConfiguration _config;
        public SmartConnectDBFactoryBase(IConfiguration config) : base(config)
        {
            _config = config;
        }
        public async Task LogTransaction(string serialNumber, string entityType, string message, int status, string transactedBy)
        {

            string query = @"INSERT INTO public.sm_transaction_logs (entity_type,log_type,transaction_date,transacted_by, serial_number,message)
                             VALUES                                (@entity_type,@log_type,@transaction_date,@transacted_by,@serial_number,@message)";

            var param = new
            {
                @entity_type = entityType,
                @log_type = status,
                @transaction_date = DateTime.Now.ToEpoch(),
                @transacted_by = transactedBy,
                @serial_number = serialNumber,
                @message = message,

            };
            var result = await DbQuerySingleAsync<int>(query, param);
        }


    }
}
