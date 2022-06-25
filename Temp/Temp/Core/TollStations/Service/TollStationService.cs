using System;
using System.Collections.Generic;
using System.Linq;
using Temp.Core.TollBooths.Model;
using Temp.Core.TollStations.Model;
using Temp.Core.TollStations.Repository;
using Temp.Core.Users.Model;
using Temp.Core.Users.Service;

namespace Temp.Core.TollStations.Service
{
    public class TollStationService : ITollStationService
    {
        ITollStationRepo tollStationRepo;
        IBossService bossService;

        public TollStationService(ITollStationRepo tollStationRepo, IBossService bossService)
        {
            this.tollStationRepo = tollStationRepo;
            this.bossService = bossService;
        }

        public List<TollStation> TollStations { get => tollStationRepo.TollStations; }

        public void Add(TollStation tollStation)
        {
            tollStationRepo.Add(tollStation);
        }

        public TollStation FindById(int id)
        {
            return tollStationRepo.FindById(id);
        }

        public int GenerateId()
        {
            return tollStationRepo.GenerateId();
        }

        public void Load()
        {
            tollStationRepo.Load();
        }

        public void Serialize()
        {
            tollStationRepo.Serialize();
        }

        public TollStation FindByWorkerId(string id)
        {
            foreach( TollStation station in TollStations)
                foreach(string workerId in station.Users)
                    if (workerId == id)
                        return station;
            return null;
        }

        public List<Boss> AvailableBosses()
        {
            List<Boss> availableBosses = new();
            foreach (Boss boss in bossService.Bosses)
            {
                if (!TollStations.Any(x => x.BossJmbg == boss.Jmbg))
                {
                    availableBosses.Add(boss);
                }
            }

            return availableBosses;
        }

        public void AddUser(User user, TollStation tollStation)
        {
            tollStation.Users.Add(user.Jmbg);
            Serialize();
        }

        public void AddTollBooth(TollBooth tollBooth, TollStation tollStation)
        {
            tollStation.TollBooths.Add(tollBooth.Number);
            Serialize();
        }

        public void Update(String name, TollStation tollStation)
        {
            tollStation.Name = name;
            Serialize();
        }

        public void RemoveTollBooth(TollBooth tollBooth, TollStation tollStation)
        {
            tollStation.TollBooths.Remove(tollBooth.Number);
            Serialize();
        }

        public void RemoveUser(User user, TollStation tollStation)
        {
            tollStation.Users.Remove(user.Jmbg);
            Serialize();
        }

        public void Delete(TollStation tollStation)
        {
            TollStations.Remove(tollStation);
            Serialize();
            // pozvati metodu za brisanje naplatnih mesta
        }

    }
}
