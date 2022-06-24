using System.Collections.Generic;
using Temp.Core.TollStations.Model;

namespace Temp.Core.TollStations.Service
{
    public interface ITollStationService
    {
        List<TollStation> TollStations { get; }

        void Add(TollStation tollStation);

        TollStation FindById(int id);

        int GenerateId();

        void Load();

        void Serialize();
    }
}