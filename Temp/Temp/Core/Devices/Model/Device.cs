using System.Text.Json.Serialization;

namespace Temp.Core.Devices.Model
{
    public class Device
    {
        int id;
        string name;
        bool malfunctioning;
        DeviceType deviceType;

        public Device(int id, string name, bool malfunctioning, DeviceType deviceType)
        {
            this.id = id;
            this.name = name;
            this.malfunctioning = malfunctioning;
            this.deviceType = deviceType;
        }

        [JsonPropertyName("id")]
        public int Id { get => id; set => id = value; }

        [JsonPropertyName("name")]
        public string Name { get => name; set => name = value; }

        [JsonPropertyName("malfunctioning")]
        public bool Malfunctioning { get => malfunctioning; set => malfunctioning = value; }

        [JsonPropertyName("deviceType")]
        public DeviceType DeviceType { get => deviceType; set => deviceType = value; }

        public override string ToString()
        {
            return "Device[id: " + id + ", name: " + name
                + ", malfunctioning: " + malfunctioning.ToString() + ", deviceType: " + deviceType + "]";
        }
    }
}
