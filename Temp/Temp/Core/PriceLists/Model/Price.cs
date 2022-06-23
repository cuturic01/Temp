using System.Text.Json.Serialization;

namespace Temp.Core.PriceLists.Model
{
    public class Price
    {
        int sectionId;
        float priceDin;
        float priceEur;
        VehicleType vehicleType;

        public Price() { }

        public Price(int sectionId, float priceDin, float priceEur, VehicleType vehicleType)
        {
            this.sectionId = sectionId;
            this.priceDin = priceDin;
            this.priceEur = priceEur;
            this.vehicleType = vehicleType;
        }

        [JsonPropertyName("sectionId")]
        public int SectionId { get => sectionId; set => sectionId = value; }

        [JsonPropertyName("priceDin")]
        public float PriceDin { get => priceDin; set => priceDin = value; }

        [JsonPropertyName("priceEur")]
        public float PriceEur { get => priceEur; set => priceEur = value; }

        [JsonPropertyName("vehicleType")]
        public VehicleType VehicleType1 { get => vehicleType; set => vehicleType = value; }

        public override string ToString()
        {
            return "Price[sectionId: " + sectionId + ", priceDin: " + priceDin
                + ", priceEur: " + priceEur + ", vehicleType: " + vehicleType + "]";
        }
    }
}
