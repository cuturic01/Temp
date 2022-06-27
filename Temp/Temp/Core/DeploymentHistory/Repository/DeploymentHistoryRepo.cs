using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using Temp.Core.DeploymentHistory.Model;

namespace Temp.Core.DeploymentHistory.Repository
{
    public class DeploymentHistoryRepo : IDeploymentHistoryRepo
    {
        List<DeploymentHistoryRecord> deploymentHistoryRecords;
        string path;

        public DeploymentHistoryRepo()
        {
            path = "../../../Data/DeploymentHistory.json";
            Load();
        }

        public List<DeploymentHistoryRecord> DeploymentHistoryRecords { get => deploymentHistoryRecords; }

        public void Load()
        {
            deploymentHistoryRecords = JsonSerializer.
                Deserialize<List<DeploymentHistoryRecord>>(File.ReadAllText(path));
        }

        public void Serialize()
        {
            string deploymentHistoryJson = JsonSerializer.Serialize(deploymentHistoryRecords,
                new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(path, deploymentHistoryJson);
        }

        public List<DeploymentHistoryRecord> FilterByBossJmbg(string jmbg)
        {
            List<DeploymentHistoryRecord> filteredRecords = new List<DeploymentHistoryRecord>();

            foreach (DeploymentHistoryRecord deploymentHistoryRecord in deploymentHistoryRecords)
                if (deploymentHistoryRecord.BossJmbg == jmbg)
                    filteredRecords.Add(deploymentHistoryRecord);

            return filteredRecords;
        }

        public List<DeploymentHistoryRecord> FilterByStationId(int id)
        {
            List<DeploymentHistoryRecord> filteredRecords = new List<DeploymentHistoryRecord>();

            foreach (DeploymentHistoryRecord deploymentHistoryRecord in deploymentHistoryRecords)
                if (deploymentHistoryRecord.TollStationId == id)
                    filteredRecords.Add(deploymentHistoryRecord);

            return filteredRecords;
        }

        public void Add(DeploymentHistoryRecord deploymentHistoryRecord)
        {
            deploymentHistoryRecords.Add(deploymentHistoryRecord);
            Serialize();
        }

    }
}
