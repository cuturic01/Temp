using System.Collections.Generic;
using Temp.Core.TollBooths.Model;
using Temp.Core.TollStations.Model;

namespace Temp.Core.TollBooths.Repository
{
    interface ITollBoothRepo
    {
        List<TollBooth> TollBooths { get; }

        void Add(TollBooth tollBooth);

        TollBooth FindById(int stationId, int boothNumber);

        int GenerateNum(TollStation tollStation);

        void Load();

        void Serialize();
    }
}