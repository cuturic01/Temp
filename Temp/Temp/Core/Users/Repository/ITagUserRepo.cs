using System.Collections.Generic;
using Temp.Core.Users.Model;

namespace Temp.Core.Users.Repository
{
    public interface ITagUserRepo
    {
        List<TagUser> TagUsers { get; }

        void Add(TagUser tagUser);

        TagUser FindByJmbg(string jmbg);

        void Load();

        void Serialize();
    }
}