using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using Temp.Core.TollStations.Model;

namespace Temp.Core.TollStations.Repository
{
    public class TollStationRepo : ITollStationRepo
    {
        List<TollStation> tollStations;
        string path;

        public List<TollStation> TollStations { get => tollStations; }

        public TollStationRepo()
        {
            path = "../../../Data/TollStations.json";
            Load();
        }

        public void Load()
        {
            tollStations = JsonSerializer.Deserialize<List<TollStation>>(File.ReadAllText(path));
        }

        public void Serialize()
        {
            string tollStationsJson = JsonSerializer.Serialize(tollStations,
                new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(path, tollStationsJson);
        }

        public int GenerateId()
        {
            return tollStations[^1].Id + 1;
        }

        public TollStation FindById(int id)
        {
            foreach (TollStation tollStation in tollStations)
                if (tollStation.Id == id)
                    return tollStation;

            return null;
        }

        public void Add(TollStation tollStation)
        {
            tollStations.Add(tollStation);
            Serialize();
        }

    }
}
