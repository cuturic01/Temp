using System.Text.Json.Serialization;

namespace Temp.Core.Tags.Model
{
    class Tag
    {
        int id;
        VehicleType vehicleType;
        string licenceId;
        float dinAccontBalance;

        public Tag() { }

        public Tag(int id, VehicleType vehicleType, string licenceId, float dinAccontBalance)
        {
            this.id = id;
            this.vehicleType = vehicleType;
            this.licenceId = licenceId;
            this.dinAccontBalance = dinAccontBalance;
        }

        [JsonPropertyName("id")]
        public int Id { get => id; set => id = value; }

        [JsonPropertyName("vehicleType")]
        public VehicleType VehicleType { get => vehicleType; set => vehicleType = value; }

        [JsonPropertyName("licenceNumber")]
        public string LicenceId { get => licenceId; set => licenceId = value; }

        [JsonPropertyName("dinAccontBalance")]
        public float DinAccontBalance { get => dinAccontBalance; set => dinAccontBalance = value; }

        public override string ToString()
        {
            return "Tag[id: " + id + ", vehicleType: " + vehicleType.ToString() +
                ", licenceId: " + licenceId + "dinAccontBalance: " + dinAccontBalance + "]";
        }
    }
}
