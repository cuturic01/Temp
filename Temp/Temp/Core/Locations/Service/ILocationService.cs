using System.Collections.Generic;
using Temp.Core.Locations.Model;

namespace Temp.Core.Locations.Service
{
    public interface ILocationService
    {
        List<Location> Locations { get; }

        void Add(Location location);

        Location FindByZip(string zip);

        void Load();

        void Serialize();
    }
}