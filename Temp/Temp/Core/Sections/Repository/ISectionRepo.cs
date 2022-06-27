using System.Collections.Generic;
using Temp.Core.Sections.Model;

namespace Temp.Core.Sections.Repository
{
    public interface ISectionRepo
    {
        List<Section> Sections { get; }

        void Add(Section section);

        Section FindById(int id);

        int GenerateId();

        void Load();

        void Serialize();

        void Delete(Section section);
    }
}