using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using Temp.Core.Users.Model;

namespace Temp.Core.Users.Repository
{
    public class BossRepo : IBossRepo
    {
        List<Boss> bosses;
        string path;

        public List<Boss> Bosses { get => bosses; }

        public BossRepo()
        {
            path = "../../../Data/Bosses.json";
            Load();
        }

        public void Load()
        {
            bosses = JsonSerializer.Deserialize<List<Boss>>(File.ReadAllText(path));
        }

        public void Serialize()
        {
            string bossesJson = JsonSerializer.Serialize(bosses,
                new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(path, bossesJson);
        }

        public Boss FindByJmbg(string jmbg)
        {
            foreach (Boss boss in bosses)
                if (boss.Jmbg == jmbg)
                    return boss;

            return null;
        }

        public void Add(Boss boss)
        {
            bosses.Add(boss);
            Serialize();
        }
    }
}
