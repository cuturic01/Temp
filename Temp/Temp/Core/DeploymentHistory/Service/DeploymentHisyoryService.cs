using System.Collections.Generic;
using Temp.Core.DeploymentHistory.Model;
using Temp.Core.DeploymentHistory.Repository;

namespace Temp.Core.DeploymentHistory.Service
{
    public class DeploymentHisyoryService : IDeploymentHisyoryService
    {
        IDeploymentHistoryRepo deploymentHistoryRepo;

        public DeploymentHisyoryService(IDeploymentHistoryRepo deploymentHistoryRepo)
        {
            this.deploymentHistoryRepo = deploymentHistoryRepo;
        }

        public List<DeploymentHistoryRecord> DeploymentHistoryRecords
        { get => deploymentHistoryRepo.DeploymentHistoryRecords; }

        public void Add(DeploymentHistoryRecord deploymentHistoryRecord)
        {
            deploymentHistoryRepo.Add(deploymentHistoryRecord);
        }

        public List<DeploymentHistoryRecord> FilterByBossJmbg(string jmbg)
        {
            return deploymentHistoryRepo.FilterByBossJmbg(jmbg);
        }

        public List<DeploymentHistoryRecord> FilterByStationId(int id)
        {
            return deploymentHistoryRepo.FilterByStationId(id);
        }

        public void Load()
        {
            deploymentHistoryRepo.Load();
        }

        public void Serialize()
        {
            deploymentHistoryRepo.Serialize();
        }
    }
}
