using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using Temp.Core.SpeedingPenalties.Model;

namespace Temp.Core.SpeedingPenalties.Repository
{
    public class SpeedingPenaltiesRepo : ISpeedingPenaltiesRepo
    {
        List<SpeedingPenalty> speedingPenalties;
        string path;

        public List<SpeedingPenalty> SpeedingPenalties { get => speedingPenalties; }

        public SpeedingPenaltiesRepo()
        {
            path = "../../../Data/SpeedingPenalties.json";
            Load();
        }

        public void Load()
        {
            speedingPenalties = JsonSerializer.Deserialize<List<SpeedingPenalty>>(File.ReadAllText(path));
        }

        public void Serialize()
        {
            string speedingPenaltiesJson = JsonSerializer.Serialize(speedingPenalties,
                new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(path, speedingPenaltiesJson);
        }

        public int GenerateId()
        {
            return speedingPenalties[^1].Id + 1;
        }

        public SpeedingPenalty FindById(int id)
        {
            foreach (SpeedingPenalty speedingPenalty in speedingPenalties)
                if (speedingPenalty.Id == id)
                    return speedingPenalty;

            return null;
        }

        public void Add(SpeedingPenalty speedingPenalty)
        {
            speedingPenalties.Add(speedingPenalty);
            Serialize();
        }
    }
}
