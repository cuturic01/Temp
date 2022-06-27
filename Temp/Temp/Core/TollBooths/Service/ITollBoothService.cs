﻿using System.Collections.Generic;
using Temp.Core.Devices.Model;
using Temp.Core.Devices.Service;
using Temp.Core.TollBooths.Model;
using Temp.Core.TollStations.Model;

namespace Temp.Core.TollBooths.Service
{
    public interface ITollBoothService
    {
        List<TollBooth> TollBooths { get; }

        void Add(TollBooth tollBooth);

        TollBooth FindById(int stationId, int boothNumber);

        int GenerateNum(TollStation tollStation);

        void Load();

        void Serialize();

        Device FindBoothRamp(int stationId, int boothNumber);

        List<Device> DevicesByBooth(int stationId, int boothNumber);
    }
}