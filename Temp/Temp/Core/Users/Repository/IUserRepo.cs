using System.Collections.Generic;
using Temp.Core.Users.Model;

namespace Temp.Core.Users.Repository
{
    public interface IUserRepo
    {
        List<User> Users { get; }

        void Add(User user);

        User FindByJmbg(string jmbg);

        void Load();

        void Serialize();
    }
}