using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Marketoo.WebAPI.API.v1.Models.Shared
{
    public class AdditionalParam
    {
        public int ActiveBatteries { get; set; }
        public int TotalDIUBatteriesConfig { get; set; }
        public string InputMessage { get; set; }
        public int AvgSoc { get; set; }
    }
}
