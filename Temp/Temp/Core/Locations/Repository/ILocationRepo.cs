using System.Collections.Generic;
using Temp.Core.Locations.Model;

namespace Temp.Core.Locations.Repository
{
    public interface ILocationRepo
    {
        List<Location> Locations { get; }

        Location FindByZip(string zip);
        
        void Load();
        
        void Serialize();

        void Add(Location location);
    }
}