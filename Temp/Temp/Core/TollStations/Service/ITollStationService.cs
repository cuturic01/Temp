using System;
using System.Collections.Generic;
using Temp.Core.TollBooths.Model;
using Temp.Core.TollStations.Model;
using Temp.Core.Users.Model;
using Temp.GUI.Dto;

namespace Temp.Core.TollStations.Service
{
    public interface ITollStationService
    {
        List<TollStation> TollStations { get; }

        void Add(TollStation tollStation);

        void Add(TollStationDto tollStationDto);

        TollStation FindById(int id);

        int GenerateId();

        void Load();

        void Serialize();

        TollStation FindByWorkerId(string id);

        List<Boss> AvailableBosses();

        void AddUser(User user, TollStation tollStation);

        void AddTollBooth(TollBooth tollBooth, TollStation tollStation);

        void Update(String name, TollStation tollStation);

        void RemoveTollBooth(TollBooth tollBooth, TollStation tollStation);

        void RemoveUser(User user, TollStation tollStation);

        void Delete(TollStation tollStation);

        TollStation FindByBoss(string jmbg);
    }
}