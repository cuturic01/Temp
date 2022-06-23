using System;
using System.Text.Json.Serialization;

namespace Temp.Core.Payments.Model
{
    public class Payment
    {
        int id;
        DateTime entranceDate;
        DateTime exitDate;
        string registrationNumber;
        VehicleType vehicleType;
        int stationId;
        int boothNumber;
        int sectionId;

        public Payment() { }

        public Payment(int id, DateTime entranceDate, DateTime exitDate, string registrationNumber, 
            VehicleType vehicleType, int stationId, int boothNumber, int sectionId)
        {
            this.id = id;
            this.entranceDate = entranceDate;
            this.exitDate = exitDate;
            this.registrationNumber = registrationNumber;
            this.vehicleType = vehicleType;
            this.stationId = stationId;
            this.boothNumber = boothNumber;
            this.sectionId = sectionId;
        }

        [JsonPropertyName("id")]
        public int Id { get => id; set => id = value; }

        [JsonPropertyName("entranceDate")]
        public DateTime EntranceDate { get => entranceDate; set => entranceDate = value; }

        [JsonPropertyName("exitDate")]
        public DateTime ExitDate { get => exitDate; set => exitDate = value; }

        [JsonPropertyName("registrationNumber")]
        public string RegistrationNumber { get => registrationNumber; set => registrationNumber = value; }

        [JsonPropertyName("vehicleType")]
        public VehicleType VehicleType { get => vehicleType; set => vehicleType = value; }

        [JsonPropertyName("stationId")]
        public int StationId { get => stationId; set => stationId = value; }

        [JsonPropertyName("boothNumber")]
        public int BoothNumber { get => boothNumber; set => boothNumber = value; }

        [JsonPropertyName("sectionId")]
        public int SectionId { get => sectionId; set => sectionId = value; }

        public override string ToString()
        {
            return "Payment[id: " + id + ", entranceDate: " + entranceDate.ToString("dd-MM-yyyy") +
                ", exitDate: " + exitDate.ToString("dd-MM-yyyy") + ", registrationNumber: " + registrationNumber +
                ", vehicleType: " + vehicleType.ToString() + ", stationId: " + stationId +
                ", boothNumber" + boothNumber + ", sectionId: " + sectionId + "]";
        }
    }
}
