using System.Text.Json.Serialization;

namespace Temp.Core.Locations.Model
{
    public class Location
    {
        string zip;
        string name;
        string country;
        string municipality;

        public Location() { }

        public Location(string zip, string name, string country, string municipality)
        {
            this.zip = zip;
            this.name = name;
            this.country = country;
            this.municipality = municipality;
        }

        [JsonPropertyName("zip")]
        public string Zip { get => zip; set => zip = value; }

        [JsonPropertyName("name")]
        public string Name { get => name; set => name = value; }

        [JsonPropertyName("country")]
        public string Country { get => country; set => country = value; }

        [JsonPropertyName("municipality")]
        public string Municipality { get => municipality; set => municipality = value; }

        public override string ToString()
        {
            return "Location[zip: " + zip + ", name: " + name +
                ", country: " + country + ", municipality: " + municipality + "]";
        }
    }
}
