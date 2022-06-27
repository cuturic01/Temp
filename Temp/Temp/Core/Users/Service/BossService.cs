using System.Collections.Generic;
using Temp.Core.Users.Model;
using Temp.Core.Users.Repository;

namespace Temp.Core.Users.Service
{
    public class BossService : IBossService
    {
        IBossRepo bossRepo;

        public BossService(IBossRepo bossRepo)
        {
            this.bossRepo = bossRepo;
        }

        public List<Boss> Bosses { get => bossRepo.Bosses; }

        public void Add(Boss boss)
        {
            bossRepo.Add(boss);
        }

        public Boss FindByJmbg(string jmbg)
        {
            return bossRepo.FindByJmbg(jmbg);
        }

        public void Load()
        {
            bossRepo.Load();
        }

        public void Serialize()
        {
            bossRepo.Serialize();
        }
    }
}
