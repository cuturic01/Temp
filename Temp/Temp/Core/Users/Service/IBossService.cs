using System.Collections.Generic;
using Temp.Core.Users.Model;

namespace Temp.Core.Users.Service
{
    public interface IBossService
    {
        List<Boss> Bosses { get; }

        void Add(Boss boss);

        Boss FindByJmbg(string jmbg);

        void Load();

        void Serialize();
    }
}