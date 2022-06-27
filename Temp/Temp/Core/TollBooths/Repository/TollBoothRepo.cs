using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using Temp.Core.TollBooths.Model;
using Temp.Core.TollStations.Model;

namespace Temp.Core.TollBooths.Repository
{
    public class TollBoothRepo : ITollBoothRepo
    {
        List<TollBooth> tollBooths;
        string path;

        public List<TollBooth> TollBooths { get => tollBooths; }

        public TollBoothRepo()
        {
            path = "../../../Data/TollBooths.json";
            Load();
        }

        public void Load()
        {
            tollBooths = JsonSerializer.Deserialize<List<TollBooth>>(File.ReadAllText(path));
        }

        public void Serialize()
        {
            string tollBoothsJson = JsonSerializer.Serialize(tollBooths,
                new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(path, tollBoothsJson);
        }

        public int GenerateNum(TollStation tollStation)
        {
            return tollStation.TollBooths[^1] + 1;
        }

        public TollBooth FindById(int stationId, int boothNumber)
        {
            foreach (TollBooth tollBooth in tollBooths)
                if (tollBooth.TollStationId == stationId && tollBooth.Number == boothNumber)
                    return tollBooth;

            return null;
        }

        public void Add(TollBooth tollBooth)
        {
            tollBooths.Add(tollBooth);
            Serialize();
        }
    }
}
