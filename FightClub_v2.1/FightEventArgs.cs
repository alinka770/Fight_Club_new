using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FightClub_v2._1
{
    class FightEventArgs
    {
        public string Name { get; }
        public int Hp { get; }

        public FightEventArgs(string name, int hp)
        {
            Name = name;
            Hp = hp;
        }
    }
}
