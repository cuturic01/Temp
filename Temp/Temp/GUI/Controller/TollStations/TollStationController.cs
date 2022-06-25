using System.Collections.Generic;
using Temp.Core.TollStations.Model;
using Temp.Core.TollStations.Service;
using Temp.Core.Users.Model;

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
    }
}
