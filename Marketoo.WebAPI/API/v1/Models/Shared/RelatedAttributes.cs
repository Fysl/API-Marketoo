namespace Marketoo.WebAPI.API.v1.Models.Shared
{
    public class RelatedAttributes
    {
        public long type { get; set; }
        public string Brand { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public bool IsMultiple { get; set; }
        public Address Address { get; set; }
    }
}
