using System.Collections.Generic;
using Temp.Core.Sections.Model;
using Temp.Core.Sections.Repository;

namespace Temp.Core.Sections.Service
{
    public class SectionService : ISectionService
    {
        ISectionRepo sectionRepo;

        public SectionService(ISectionRepo sectionRepo)
        {
            this.sectionRepo = sectionRepo;
        }

        public List<Section> Sections { get => sectionRepo.Sections; }

        public void Add(Section section)
        {
            sectionRepo.Add(section);
        }

        public Section FindById(int id)
        {
            return sectionRepo.FindById(id);
        }

        public int GenerateId()
        {
            return sectionRepo.GenerateId();
        }

        public void Load()
        {
            sectionRepo.Load();
        }


        public void Serialize()
        {
            sectionRepo.Serialize();
        }
        public Section GetSectionByStations(int entranceId, int exitId)
        {
            foreach(Section section in Sections)
            {
                if (section.EntranceStation == entranceId && section.ExitStation == exitId)
                    return section;
            }

            return null;
        }

    }
}
