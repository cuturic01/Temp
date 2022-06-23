using System.Text.Json.Serialization;

namespace Temp.Core.Locations.Model
{
    public class Adress
    {
        string street;
        int streetNumber;
        string locationZip;

        public Adress() { }

        public Adress(string street, int streetNumber, string locationZip)
        {
            this.street = street;
            this.streetNumber = streetNumber;
            this.locationZip = locationZip;
        }

        [JsonPropertyName("street")]
        public string Street { get => street; set => street = value; }

        [JsonPropertyName("streetNumber")]
        public int StreetNumber { get => streetNumber; set => streetNumber = value; }

        [JsonPropertyName("locationZip")]
        public string LocationZip { get => locationZip; set => locationZip = value; }

        public override string ToString()
        {
            return "Adress[street: " + street + ", streetNumber: " + streetNumber +
                ", locationZip: " + locationZip + "]";
        }
    }
}
