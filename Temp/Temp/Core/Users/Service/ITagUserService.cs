using System.Collections.Generic;
using Temp.Core.Users.Model;

namespace Temp.Core.Users.Service
{
    public interface ITagUserService
    {
        List<TagUser> TagUsers { get; }

        void Add(TagUser tagUser);

        TagUser FindByJmbg(string jmbg);

        void Load();

        void Serialize();
    }
}