using System.Collections.Generic;
using Temp.Core.Devices.Model;
using Temp.Core.Devices.Service;

namespace Temp.GUI.Controller.Devices
{
    public class DeviceController
    {
        IDeviceService deviceService;

        public DeviceController(IDeviceService deviceService)
        {
            this.deviceService = deviceService;
        }

        public List<Device> Devices { get => deviceService.Devices; }

        public void Add(Device device)
        {
            deviceService.Add(device);
        }

        public Device FindById(int id)
        {
            return deviceService.FindById(id);
        }

        public int GenerateId()
        {
            return deviceService.GenerateId();
        }

        public void Load()
        {
            deviceService.Load();
        }

        public void Serialize()
        {
            deviceService.Serialize();
        }
    }
}
