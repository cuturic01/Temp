using System.Collections.Generic;
using Temp.Core.Locations.Model;
using Temp.Core.Locations.Repository;

namespace Temp.Core.Locations.Service
{
    public class LocationService : ILocationService
    {
        ILocationRepo locationRepo;

        public LocationService(ILocationRepo locationRepo)
        {
            this.locationRepo = locationRepo;
        }

        public List<Location> Locations { get => locationRepo.Locations; }

        public Location FindByZip(string zip)
        {
            return locationRepo.FindByZip(zip);
        }

        public void Load()
        {
            locationRepo.Load();
        }


        public void Serialize()
        {
            locationRepo.Serialize();
        }

        public void Add(Location location)
        {
            locationRepo.Add(location);
        }
    }
}
