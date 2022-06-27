using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Temp.Core.TollStations.Model
{
    public class TollStation
    {
        int id;
        string name;
        string bossJmbg;
        string locationZip;
        List<string> users;
        List<int> tollBooths;

        public TollStation()
        {
            users = new List<string>();
            tollBooths = new List<int>();
        }

        public TollStation(int id, string name, string bossJmbg, string locationZip, List<string> users, 
            List<int> tollBooths)
        {
            this.id = id;
            this.name = name;
            this.bossJmbg = bossJmbg;
            this.locationZip = locationZip;
            this.users = users;
            this.tollBooths = tollBooths;
        }

        [JsonPropertyName("id")]
        public int Id { get => id; set => id = value; }

        [JsonPropertyName("name")]
        public string Name { get => name; set => name = value; }

        [JsonPropertyName("bossJmbg")]
        public string BossJmbg { get => bossJmbg; set => bossJmbg = value; }

        [JsonPropertyName("locationZip")]
        public string LocationZip { get => locationZip; set => locationZip = value; }

        [JsonPropertyName("users")]
        public List<string> Users { get => users; set => users = value; }

        [JsonPropertyName("tollBooths")]
        public List<int> TollBooths { get => tollBooths; set => tollBooths = value; }

        public override string ToString()
        {
            return "TollStation[id: " + id + ", name: " + name +
                ", bossJmbg: " + bossJmbg + ", locationZip: " + locationZip +
                ", users: " + users + ", tollBooths: " + tollBooths + "]";
        }
    }
}
