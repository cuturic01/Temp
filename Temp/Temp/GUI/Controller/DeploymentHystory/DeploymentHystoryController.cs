using System.Collections.Generic;
using Temp.Core.DeploymentHistory.Model;
using Temp.Core.DeploymentHistory.Service;

namespace Temp.GUI.Controller.DeploymentHystory
{
    class DeploymentHystoryController
    {
        IDeploymentHisyoryService deploymentHisyoryService;

        public DeploymentHystoryController(IDeploymentHisyoryService deploymentHisyoryService)
        {
            this.deploymentHisyoryService = deploymentHisyoryService;
        }

        public List<DeploymentHistoryRecord> DeploymentHistoryRecords 
            { get => deploymentHisyoryService.DeploymentHistoryRecords; }

        public void Add(DeploymentHistoryRecord deploymentHistoryRecord)
        {
            deploymentHisyoryService.Add(deploymentHistoryRecord);
        }

        public List<DeploymentHistoryRecord> FilterByBossJmbg(string jmbg)
        {
            return deploymentHisyoryService.FilterByBossJmbg(jmbg);
        }

        public List<DeploymentHistoryRecord> FilterByStationId(int id)
        {
            return deploymentHisyoryService.FilterByStationId(id);
        }

        public void Load()
        {
            deploymentHisyoryService.Load();
        }

        public void Serialize()
        {
            deploymentHisyoryService.Serialize();
        }
    }
}
