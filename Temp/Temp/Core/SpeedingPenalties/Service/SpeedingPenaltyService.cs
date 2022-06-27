using System.Collections.Generic;
using Temp.Core.SpeedingPenalties.Model;
using Temp.Core.SpeedingPenalties.Repository;

namespace Temp.Core.SpeedingPenalties.Service
{
    public class SpeedingPenaltyService : ISpeedingPenaltyService
    {
        ISpeedingPenaltyRepo speedingPenaltyRepo;

        public SpeedingPenaltyService(ISpeedingPenaltyRepo speedingPenaltyRepo)
        {
            this.speedingPenaltyRepo = speedingPenaltyRepo;
        }

        public List<SpeedingPenalty> SpeedingPenalties { get => speedingPenaltyRepo.SpeedingPenalties; }

        public void Add(SpeedingPenalty speedingPenalty)
        {
            speedingPenaltyRepo.Add(speedingPenalty);
        }

        public SpeedingPenalty FindById(int id)
        {
            return speedingPenaltyRepo.FindById(id);
        }

        public int GenerateId()
        {
            return speedingPenaltyRepo.GenerateId();
        }

        public void Load()
        {
            speedingPenaltyRepo.Load();
        }

        public void Serialize()
        {
            speedingPenaltyRepo.Serialize();
        }
    }
}
