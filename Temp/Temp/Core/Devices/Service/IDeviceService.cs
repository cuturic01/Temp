using System.Collections.Generic;
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

        void Fix(Device device);

        public List<Device> GetAllFromTollBooth(List<int> deviceIds);

        List<Device> GenerateDevices();
    }
}