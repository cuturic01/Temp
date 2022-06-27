using System.Collections.Generic;
using System.Text.Json.Serialization;
using Temp.GUI.Dto;

namespace Temp.Core.TollBooths.Model
{
    public class TollBooth
    {
        int tollStationId;
        int number;
        TollBoothType tollBoothType;
        bool malfunctioning;
        List<int> devices;

        public TollBooth() 
        {
            devices = new List<int>();
        }

        public TollBooth(int tollStationId, int number, TollBoothType tollBoothType, bool malfunctioning, 
            List<int> devices)
        {
            this.tollStationId = tollStationId;
            this.number = number;
            this.tollBoothType = tollBoothType;
            this.malfunctioning = malfunctioning;
            this.devices = devices;
        }

        public TollBooth(TollBoothDto tollBoothDto)
        {
            this.tollStationId = tollBoothDto.TollStationId;
            this.number = tollBoothDto.Number;
            this.tollBoothType = tollBoothDto.TollBoothType;
            this.malfunctioning = tollBoothDto.Malfunctioning;
            this.devices = tollBoothDto.Devices;
        }

        [JsonPropertyName("tollStationId")]
        public int TollStationId { get => tollStationId; set => tollStationId = value; }

        [JsonPropertyName("number")]
        public int Number { get => number; set => number = value; }

        [JsonPropertyName("tollBoothType")]
        public TollBoothType TollBoothType { get => tollBoothType; set => tollBoothType = value; }

        [JsonPropertyName("malfunctioning")]
        public bool Malfunctioning { get => malfunctioning; set => malfunctioning = value; }

        [JsonPropertyName("devices")]
        public List<int> Devices { get => devices; set => devices = value; }

        public override string ToString()
        {
            return "TollBooth[tollStationId: " + tollStationId + ", number: " + number
                + ", tollBoothType: " + tollBoothType + ", malfunctioning: " + malfunctioning.ToString() 
                + ", devices:" + devices.Count + "]";
        }
    }
}
