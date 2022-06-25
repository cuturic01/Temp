using System.Collections.Generic;
using Temp.Core.Devices.Model;

namespace Temp.Core.Devices.Repository
{
    public interface IDeviceRepo
    {
        List<Device> Devices { get; }

        void Add(Device device);

        Device FindById(int id);

        int GenerateId();

        void Load();

        void Serialize();
    }
}