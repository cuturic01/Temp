using System;
using System.Collections.Generic;
using Temp.Core.TollBooths.Model;
using Temp.Core.TollStations.Model;
using Temp.Core.TollStations.Service;
using Temp.Core.Users.Model;
using Temp.GUI.Dto;

namespace Temp.GUI.Controller.TollStations
{
    public class TollStationController
    {
        ITollStationService tollStationService;

        public TollStationController(ITollStationService tollStationService)
        {
            this.tollStationService = tollStationService;
        }

        public List<TollStation> TollStations { get => tollStationService.TollStations; }

        public void Add(TollStation tollStation)
        {
            tollStationService.Add(tollStation);
        }

        public void Add(TollStationDto tollStationDto)
        {
            tollStationService.Add(tollStationDto);
        }

        public TollStation FindById(int id)
        {
            return tollStationService.FindById(id);
        }

        public int GenerateId()
        {
            return tollStationService.GenerateId();
        }

        public void Load()
        {
            tollStationService.Load();
        }

        public void Serialize()
        {
            tollStationService.Serialize();
        }

        public TollStation FindByWorkerId(string id)
        {
            return tollStationService.FindByWorkerId(id);
        }

        public List<Boss> AvailableBosses()
        {
            return tollStationService.AvailableBosses();
        }

        public TollStation FindByBoss(string jmbg)
        {
            return tollStationService.FindByBoss(jmbg);
        }

        public void AddUser(User user, TollStation tollStation)
        {
            tollStationService.AddUser(user, tollStation);
        }

        public void AddTollBooth(TollBooth tollBooth, TollStation tollStation)
        {
            tollStationService.AddTollBooth(tollBooth, tollStation);
        }

        public void Update(String name, TollStation tollStation)
        {
            tollStationService.Update(name, tollStation);
        }

        public void RemoveTollBooth(TollBooth tollBooth, TollStation tollStation)
        {
            tollStationService.RemoveTollBooth(tollBooth, tollStation);
        }

        public void RemoveUser(User user, TollStation tollStation)
        {
            tollStationService.RemoveUser(user, tollStation);
        }

        public void Delete(TollStation tollStation)
        {
            tollStationService.Delete(tollStation);
        }
    }
}
