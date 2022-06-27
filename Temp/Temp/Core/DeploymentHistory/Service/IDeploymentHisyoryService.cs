using System.Collections.Generic;
using Temp.Core.DeploymentHistory.Model;
using Temp.GUI.Dto;

namespace Temp.Core.DeploymentHistory.Service
{
    public interface IDeploymentHisyoryService
    {
        List<DeploymentHistoryRecord> DeploymentHistoryRecords { get; }

        void Add(DeploymentHistoryRecord deploymentHistoryRecord);

        List<DeploymentHistoryRecord> FilterByBossJmbg(string jmbg);

        List<DeploymentHistoryRecord> FilterByStationId(int id);

        void Load();

        void Serialize();
    }
}