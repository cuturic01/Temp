using System.Collections.Generic;
using Temp.Core.DeploymentHistory.Model;
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

        DeploymentHistoryRecord PutToStation(int stationId, Boss boss);

        void RemoveFromStation(string bossJmbg);
    }
}