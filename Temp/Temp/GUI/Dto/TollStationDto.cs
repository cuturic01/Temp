using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Temp.GUI.Dto
{
    public class TollStationDto
    {
        int id;
        string name;
        string bossJmbg;
        string locationZip;

        public TollStationDto(int id, string name, string bossJmbg, string locationZip)
        {
            this.id = id;
            this.name = name;
            this.bossJmbg = bossJmbg;
            this.locationZip = locationZip;
        }

        public int Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public string BossJmbg { get => bossJmbg; set => bossJmbg = value; }
        public string LocationZip { get => locationZip; set => locationZip = value; }
    }
}
