using System.Collections.Generic;
using Temp.Core.Sections.Model;
using Temp.Core.Sections.Service;

namespace Temp.GUI.Controller.Sections
{
    public class SectionCotroller
    {
        ISectionService sectionService;

        public SectionCotroller(ISectionService sectionService)
        {
            this.sectionService = sectionService;
        }

        public List<Section> Sections { get => sectionService.Sections; }

        public void Add(Section section)
        {
            sectionService.Add(section);
        }

        public Section FindById(int id)
        {
            return sectionService.FindById(id);
        }

        public int GenerateId()
        {
            return sectionService.GenerateId();
        }

        public void Load()
        {
            sectionService.Load();
        }

        public void Serialize()
        {
            sectionService.Serialize();
        }
    }
}
