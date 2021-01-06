using Marketoo.WebAPI.API.v1.Models.AssetRequests;
using static Marketoo.Common.Constants.CommonConstants;

namespace Marketoo.WebAPI.API.v1.Models.Shared
{
    public class StationComponent: BaseAssetRequest
    {
        public int? Id { get; set; }
        public long TypeId { get; set; }
        public string SerialNumber { get; set; }
        public long? MakeId { get; set; }
        public long? ModelId { get; set; }
        public EntityStatus Status { get; set; }
    }
}
