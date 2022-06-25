using System;
using System.Collections.Generic;
using Temp.Core.TollBooths.Model;
using Temp.Core.TollStations.Model;
using Temp.Core.Users.Model;

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

        TollStation FindByWorkerId(string id);

        List<Boss> AvailableBosses();

        public void AddUser(User user, TollStation tollStation);

        public void AddTollBooth(TollBooth tollBooth, TollStation tollStation);

        public void Update(String name, TollStation tollStation);

        public void RemoveTollBooth(TollBooth tollBooth, TollStation tollStation);

        public void RemoveUser(User user, TollStation tollStation);

        public void Delete(TollStation tollStation);

        public TollStation FindByBoss(string jmbg);
    }
}