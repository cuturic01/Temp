using System.Text.Json.Serialization;

namespace Temp.Core.TollBooths.Model
{
    public class TollBooth
    {
        int tollStationId;
        int number;
        TollBoothType tollBoothType;

        public TollBooth() { }

        public TollBooth(int tollStationId, int number, TollBoothType tollBoothType)
        {
            this.tollStationId = tollStationId;
            this.number = number;
            this.tollBoothType = tollBoothType;
        }

        [JsonPropertyName("tollStationId")]
        public int TollStationId { get => tollStationId; set => tollStationId = value; }

        [JsonPropertyName("number")]
        public int Number { get => number; set => number = value; }

        [JsonPropertyName("tollBoothType")]
        public TollBoothType TollBoothType { get => tollBoothType; set => tollBoothType = value; }

        public override string ToString()
        {
            return "TollBooth[tollStationId: " + tollStationId + ", number: " + number 
                + ", tollBoothType: " + tollBoothType + "]";
        }
    }
}
