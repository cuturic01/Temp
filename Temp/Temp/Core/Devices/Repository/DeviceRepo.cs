using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using Temp.Core.Devices.Model;

namespace Temp.Core.Devices.Repository
{
    public class DeviceRepo : IDeviceRepo
    {
        List<Device> devices;
        string path;

        public List<Device> Devices { get => devices; }

        public DeviceRepo()
        {
            path = "../../../Data/Devices.json";
            Load();
        }

        public void Load()
        {
            devices = JsonSerializer.Deserialize<List<Device>>(File.ReadAllText(path));
        }

        public int GenerateId()
        {
            return devices[^1].Id + 1;
        }

        public void Serialize()
        {
            string devicesJson = JsonSerializer.Serialize(devices,
                new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(path, devicesJson);
        }

        public Device FindById(int id)
        {
            foreach (Device device in devices)
                if (device.Id == id)
                    return device;

            return null;
        }

        public void Add(Device device)
        {
            devices.Add(device);
            Serialize();
        }
    }
}
