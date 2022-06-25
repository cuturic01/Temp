using System.Collections.Generic;
using Temp.Core.Devices.Model;
using Temp.Core.Devices.Service;
using Temp.Core.TollBooths.Model;
using Temp.Core.TollBooths.Repository;
using Temp.Core.TollStations.Model;

namespace Temp.Core.TollBooths.Service
{
    public class TollBoothService : ITollBoothService
    {
        ITollBoothRepo tollBoothRepo;
        IDeviceService deviceService;

        public TollBoothService(ITollBoothRepo tollBoothRepo, IDeviceService deviceService)
        {
            this.tollBoothRepo = tollBoothRepo;
            this.deviceService = deviceService;
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

        public void CheckForFixing(TollBooth tollBooth)
        {
            bool malfunctioning = false;
            foreach (int deviceId in tollBooth.Devices)
            {
                Device device = deviceService.FindById(deviceId);
                if (device.Malfunctioning == true)
                {
                    malfunctioning = true;
                    break;
                }
            }
            if (!malfunctioning) Fix(tollBooth);
        }

        public List<TollBooth> GetAllFromStation(TollStation tollStation)
        {
            List<TollBooth> tollBooths = new();
            foreach (int tollBoothNumber in tollStation.TollBooths)
            {
                tollBooths.Add(FindById(tollStation.Id, tollBoothNumber));
            }
            return tollBooths;
        }
    }
}
