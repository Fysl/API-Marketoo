namespace Marketoo.WebAPI.API.v1.Models.AssetResponses
{
    public class BaseAssetResponse
    {
        public long? CreatedDate { get; set; }
        public long? ModifiedDate { get; set; }
        public string CreatedBy { get; set; }
        public string ModifiedBy { get; set; }
    }
}
