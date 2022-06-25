﻿using System.Collections.Generic;
using Temp.Core.Devices.Model;

namespace Temp.Core.Devices.Service
{
    public interface IDeviceService
    {
        List<Device> Devices { get; }

        void Add(Device device);

        Device FindById(int id);

        int GenerateId();

        void Load();

        void Serialize();
    }
}