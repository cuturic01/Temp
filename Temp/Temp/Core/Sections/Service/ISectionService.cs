using System.Collections.Generic;
using Temp.Core.Sections.Model;

namespace Temp.Core.Sections.Service
{
    public interface ISectionService
    {
        List<Section> Sections { get; }

        void Add(Section section);

        Section FindById(int id);

        int GenerateId();

        void Load();

        void Serialize();

        Section GetSectionByStations(int entranceId, int exitId);

        void Delete(Section section);
    }
}