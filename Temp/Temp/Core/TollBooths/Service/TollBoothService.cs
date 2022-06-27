using System.Collections.Generic;
using Temp.Core.Devices.Model;
using Temp.Core.Devices.Service;
using Temp.Core.TollBooths.Model;
using Temp.Core.TollBooths.Repository;
using Temp.Core.TollStations.Model;
using Temp.Core.TollStations.Repository;
using Temp.Core.TollStations.Service;
using Temp.GUI.Dto;

namespace Temp.Core.TollBooths.Service
{
    public class TollBoothService : ITollBoothService
    {
        private ITollBoothRepo tollBoothRepo;
        private IDeviceService deviceService;
        private ITollStationService tollStationService;

        public TollBoothService(ITollBoothRepo tollBoothRepo, IDeviceService deviceService, ITollStationService tollStationService)
        {
            this.tollBoothRepo = tollBoothRepo;
            this.deviceService = deviceService;
            this.tollStationService = tollStationService;
        }

        public List<TollBooth> TollBooths { get => tollBoothRepo.TollBooths; }

        public ITollBoothRepo TollBoothRepo
        {
            get => tollBoothRepo;
            set => tollBoothRepo = value;
        }

        public IDeviceService DeviceService
        {
            get => deviceService;
            set => deviceService = value;
        }

        public ITollStationService TollStationService
        {
            get => tollStationService;
            set => tollStationService = value;
        }

        public void Add(TollBoothDto tollBoothDto)
        {
            TollBooth tollBooth = new TollBooth(tollBoothDto);

            tollBoothRepo.Add(tollBooth);
        }

        public void Update(TollBoothDto tollBoothDto)
        {
            TollBooth tollBooth = FindById(tollBoothDto.TollStationId, tollBoothDto.Number);
            tollBooth.TollBoothType = tollBoothDto.TollBoothType;
            tollBooth.Malfunctioning = tollBoothDto.Malfunctioning;
            tollBooth.Devices = tollBoothDto.Devices;
            Serialize();
        }

        public void Delete(int stationId, int number)
        {
            TollBooth tollBooth = FindById(stationId, number);
            tollBoothRepo.Delete(tollBooth);
            tollStationService.RemoveTollBooth(tollBooth,tollStationService.FindById(stationId));
        }

        public TollBooth FindById(int stationId, int boothNumber)
        {
            return tollBoothRepo.FindById(stationId, boothNumber);
        }

        public int GenerateNum(TollStation tollStation)
        {
            return tollBoothRepo.GenerateNum(tollStation);
        }

        public bool AlreadyExist(int stationId, int number)
        {
            return tollBoothRepo.AlreadyExist(stationId, number);
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
        
        public Device FindBoothRamp(int stationId, int boothNumber)
        {
            TollBooth tollBooth = FindById(stationId, boothNumber);
            foreach (int deviceId in tollBooth.Devices)
            {
                Device device = deviceService.FindById(deviceId);
                if (device.DeviceType == DeviceType.RAMP)
                    return device;
            }

            return null;
        }

        public List<Device> DevicesByBooth(int stationId, int boothNumber)
        {
            List<Device> filtered = new();

            TollBooth tollBooth = FindById(stationId, boothNumber);
            foreach (int deviceId in tollBooth.Devices)
                filtered.Add(deviceService.FindById(deviceId));

            return filtered;
        }
    }
}
