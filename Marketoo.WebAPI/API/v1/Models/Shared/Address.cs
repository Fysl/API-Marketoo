namespace Marketoo.WebAPI.API.v1.Models.Shared
{
    public class Address
    {
        public int StreetNumber { get; set; }
        public string StreetName { get; set; }
        public string VillageName { get; set; }
        public string DistrictName { get; set; }
        public int Pin { get; set; }
        public string State { get; set; }
    }
}
