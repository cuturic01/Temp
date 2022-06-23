using System.Collections.Generic;
using Temp.Core.DeploymentHistory.Model;

namespace Temp.Core.DeploymentHistory.Repository
{
    public interface IDeploymentHistoryRepo
    {
        List<DeploymentHistoryRecord> DeploymentHistoryRecords { get; }

        void Add(DeploymentHistoryRecord deploymentHistoryRecord);

        List<DeploymentHistoryRecord> FilterByBossJmbg(string jmbg);

        List<DeploymentHistoryRecord> FilterByStationId(int id);

        void Load();

        void Serialize();
    }
}