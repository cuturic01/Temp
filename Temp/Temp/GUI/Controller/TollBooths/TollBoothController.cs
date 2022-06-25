using System.Collections.Generic;
using Temp.Core.TollBooths.Model;
using Temp.Core.TollBooths.Service;
using Temp.Core.TollStations.Model;

namespace Temp.GUI.Controller.TollBooths
{
    public class TollBoothController
    {
        ITollBoothService tollBoothService;

        public TollBoothController(ITollBoothService tollBoothService)
        {
            this.tollBoothService = tollBoothService;
        }

        public List<TollBooth> TollBooths { get => tollBoothService.TollBooths; }

        public void Add(TollBooth tollBooth)
        {
            tollBoothService.Add(tollBooth);
        }

        public TollBooth FindById(int stationId, int boothNumber)
        {
            return tollBoothService.FindById(stationId, boothNumber);
        }

        public int GenerateNum(TollStation tollStation)
        {
            return tollBoothService.GenerateNum(tollStation);
        }

        public void Load()
        {
            tollBoothService.Load();
        }

        public void Serialize()
        {
            tollBoothService.Serialize();
        }

        public void CheckForFixing(TollBooth tollBooth)
        {
           tollBoothService.CheckForFixing(tollBooth);
        }

        public List<TollBooth> GetAllFromStation(TollStation tollStation)
        {
            return tollBoothService.GetAllFromStation(tollStation);
        }
    }
}
