using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Temp.GUI.Dto
{
    public class TollBoothDto
    {
        int tollStationId;
        int number;
        TollBoothType tollBoothType;
        bool malfunctioning;
        List<int> devices;

        public TollBoothDto()
        {
            devices = new List<int>();
        }

        public TollBoothDto(int tollStationId, int number, TollBoothType tollBoothType, bool malfunctioning,
            List<int> devices)
        {
            this.tollStationId = tollStationId;
            this.number = number;
            this.tollBoothType = tollBoothType;
            this.malfunctioning = malfunctioning;
            this.devices = devices;
        }
        
        public int TollStationId { get => tollStationId; set => tollStationId = value; }
        
        public int Number { get => number; set => number = value; }
        
        public TollBoothType TollBoothType { get => tollBoothType; set => tollBoothType = value; }

        public bool Malfunctioning { get => malfunctioning; set => malfunctioning = value; }
        
        public List<int> Devices { get => devices; set => devices = value; }
    }
}
