using System.Collections.Generic;
using Temp.Core.Devices.Service;
using Temp.Core.TollBooths.Model;
using Temp.Core.TollBooths.Repository;
using Temp.Core.TollStations.Model;
using Temp.Core.TollStations.Service;
using Temp.GUI.Dto;

namespace Temp.Core.TollBooths.Service
{
    public interface ITollBoothService
    {
        List<TollBooth> TollBooths { get; }
        public ITollBoothRepo TollBoothRepo { get; set; }

        public IDeviceService DeviceService { get; set; }

        public ITollStationService TollStationService { get; set; }

        void Add(TollBoothDto tollBooth);

        void Update(TollBoothDto tollBoothDto);

        void Delete(int stationId, int number);

        TollBooth FindById(int stationId, int boothNumber);

        int GenerateNum(TollStation tollStation);

        void Load();

        void Serialize();

        void Fix(TollBooth tollBooth);

        public void CheckForFixing(TollBooth tollBooth);

        public List<TollBooth> GetAllFromStation(TollStation tollStation);

        bool AlreadyExist(int stationId, int number);
    }
}