using System.Collections.Generic;
using Temp.Core.Locations.Model;
using Temp.Core.Locations.Service;

namespace Temp.GUI.Controller.Locations
{
    public class LocationController
    {
        ILocationService locationService;

        public LocationController(ILocationService locationService)
        {
            this.locationService = locationService;
        }

        public List<Location> Locations { get => locationService.Locations; }

        public void Add(Location location)
        {
            locationService.Add(location);
        }

        public Location FindByZip(string zip)
        {
            return locationService.FindByZip(zip);
        }

        public void Load()
        {
            locationService.Load();
        }

        public void Serialize()
        {
            locationService.Serialize();
        }
    }
}
