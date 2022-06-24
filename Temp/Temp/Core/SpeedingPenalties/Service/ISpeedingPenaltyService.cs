using System.Collections.Generic;
using Temp.Core.SpeedingPenalties.Model;

namespace Temp.Core.SpeedingPenalties.Service
{
    public interface ISpeedingPenaltyService
    {
        List<SpeedingPenalty> SpeedingPenalties { get; }

        void Add(SpeedingPenalty speedingPenalty);

        SpeedingPenalty FindById(int id);

        int GenerateId();

        void Load();

        void Serialize();
    }
}