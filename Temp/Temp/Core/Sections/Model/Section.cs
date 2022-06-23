using System.Text.Json.Serialization;

namespace Temp.Core.Sections.Model
{
    public class Section
    {
        int id;
        int entranceStation;
        int exitStation;
        float distance;

        public Section() { }

        public Section(int id, int entranceStation, int exitStation, float distance)
        {
            this.id = id;
            this.entranceStation = entranceStation;
            this.exitStation = exitStation;
            this.distance = distance;
        }

        [JsonPropertyName("id")]
        public int Id { get => id; set => id = value; }

        [JsonPropertyName("entranceStation")]
        public int EntranceStation { get => entranceStation; set => entranceStation = value; }

        [JsonPropertyName("exitStation")]
        public int ExitStation { get => exitStation; set => exitStation = value; }

        [JsonPropertyName("distance")]
        public float Distance { get => distance; set => distance = value; }

        public override string ToString()
        {
            return "Section[id: " + id + ", entranceStation: " + entranceStation
                + ", exitStation: " + exitStation + ", distance: " + distance + "]";
        }
    }
}
