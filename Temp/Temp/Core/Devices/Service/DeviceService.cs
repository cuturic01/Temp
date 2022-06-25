using System.Collections.Generic;
using Temp.Core.Devices.Model;
using Temp.Core.Devices.Repository;

namespace Temp.Core.Devices.Service
{
    public class DeviceService : IDeviceService
    {
        IDeviceRepo deviceRepo;

        public DeviceService(IDeviceRepo deviceRepo)
        {
            this.deviceRepo = deviceRepo;
        }

        public List<Device> Devices { get => deviceRepo.Devices; }

        public void Add(Device device)
        {
            deviceRepo.Add(device);
        }

        public Device FindById(int id)
        {
            return deviceRepo.FindById(id);
        }

        public int GenerateId()
        {
            return deviceRepo.GenerateId();
        }

        public void Load()
        {
            deviceRepo.Load();
        }

        public void Serialize()
        {
            deviceRepo.Serialize();
        }
    }
}
