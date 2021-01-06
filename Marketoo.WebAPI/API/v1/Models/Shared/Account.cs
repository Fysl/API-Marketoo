using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Marketoo.WebAPI.API.v1.Models.Shared
{
    public class Account
    {
        public string AccountNumber { get; set; }
        public string IfscCode { get; set; }
        public string BankName { get; set; }
        public string BeneficiaryName { get; set; }
        public bool IsActive { get; set; }
    }
}
