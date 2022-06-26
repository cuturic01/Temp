using System.Collections.Generic;
using Temp.Core.TollBooths.Model;
using Temp.Core.TollStations.Model;
using Temp.GUI.Dto;

namespace Temp.Core.TollBooths.Repository
{
    public interface ITollBoothRepo
    {
        List<TollBooth> TollBooths { get; }

        void Add(TollBooth tollBooth);

        void Delete(TollBooth tollBooth);

        TollBooth FindById(int stationId, int boothNumber);

        int GenerateNum(TollStation tollStation);

        void Load();

        void Serialize();
    }
}