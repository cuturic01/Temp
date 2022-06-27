using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using Temp.Core.Sections.Model;

namespace Temp.Core.Sections.Repository
{
    class SectionRepo : ISectionRepo
    {
        List<Section> sections;
        string path;

        public List<Section> Sections { get => sections; }

        public SectionRepo()
        {
            path = "../../../Data/Sections.json";
            Load();
        }

        public void Load()
        {
            sections = JsonSerializer.Deserialize<List<Section>>(File.ReadAllText(path));
        }

        public void Serialize()
        {
            string priceListsJson = JsonSerializer.Serialize(sections,
                new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(path, priceListsJson);
        }

        public int GenerateId()
        {
            return sections[^1].Id + 1;
        }

        public Section FindById(int id)
        {
            foreach (Section section in sections)
                if (section.Id == id)
                    return section;

            return null;
        }

        public void Add(Section section)
        {
            sections.Add(section);
            Serialize();
        }

        public void Delete(Section section)
        {
            sections.Remove(section);
            Serialize();
        }
    }
}
