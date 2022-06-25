using System.Text.Json.Serialization;

namespace Temp.Core.TollBooths.Model
{
    public class TollBooth
    {
        int tollStationId;
        int number;
        TollBoothType tollBoothType;
        bool malfunctioning;

        public TollBooth() { }

        public TollBooth(int tollStationId, int number, TollBoothType tollBoothType, bool malfunctioning)
        {
            this.tollStationId = tollStationId;
            this.number = number;
            this.tollBoothType = tollBoothType;
            this.malfunctioning = malfunctioning;
        }

        [JsonPropertyName("tollStationId")]
        public int TollStationId { get => tollStationId; set => tollStationId = value; }

        [JsonPropertyName("number")]
        public int Number { get => number; set => number = value; }

        [JsonPropertyName("tollBoothType")]
        public TollBoothType TollBoothType { get => tollBoothType; set => tollBoothType = value; }

        [JsonPropertyName("malfunctioning")]
        public bool Malfunctioning { get => malfunctioning; set => malfunctioning = value; }

        public override string ToString()
        {
            return "TollBooth[tollStationId: " + tollStationId + ", number: " + number
                + ", tollBoothType: " + tollBoothType + ", malfunctioning: " + malfunctioning.ToString() + "]";
        }
    }
}
