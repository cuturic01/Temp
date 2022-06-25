using System.Collections.Generic;
using Temp.Core.TollBooths.Model;
using Temp.Core.TollBooths.Repository;
using Temp.Core.TollStations.Model;

namespace Temp.Core.TollBooths.Service
{
    public class TollBoothService : ITollBoothService
    {
        ITollBoothRepo tollBoothRepo;

        public TollBoothService(ITollBoothRepo tollBoothRepo)
        {
            this.tollBoothRepo = tollBoothRepo;
        }

        public List<TollBooth> TollBooths { get => tollBoothRepo.TollBooths; }

        public void Add(TollBooth tollBooth)
        {
            tollBoothRepo.Add(tollBooth);
        }

        public TollBooth FindById(int stationId, int boothNumber)
        {
            return tollBoothRepo.FindById(stationId, boothNumber);
        }

        public int GenerateNum(TollStation tollStation)
        {
            return tollBoothRepo.GenerateNum(tollStation);
        }

        public void Load()
        {
            tollBoothRepo.Load();
        }

        public void Serialize()
        {
            tollBoothRepo.Serialize();
        }

        public void Fix(TollBooth tollBooth)
        {
            tollBooth.Malfunctioning = false;
            Serialize();
        }
    }
}
