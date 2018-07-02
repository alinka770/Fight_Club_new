using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FightClub_v2._1
{
    class Player
    {
        private int hp;

        public string Name { get; set; }
        public int HP
        {
            get { return hp; }
            set
            {
                if (value < 0) hp = 0;
                else hp = value;
            }

        }
        public BodyParts Blocked { get; set; }
        public Player(string name)
        {
            Name = name;
            HP = 100;
        }
        public void SetBlock(BodyParts bodyPart)
        {
            Blocked = bodyPart;
        }
        public void GetHit(BodyParts bodyPart)
        {
            if (bodyPart == Blocked)
            {
                OnBlock(new FightEventArgs(this.Name, this.HP));
            }
            else
            {

                HP -= (new Random()).Next(0, 20);
                if (HP > 0)
                {
                    OnWound(new FightEventArgs(this.Name, this.HP));
                }
                else
                {
                    HP = 0;
                    OnDeath(new FightEventArgs(this.Name, this.HP));
                }
            }

        }

        public delegate void FightHandler(object sender, FightEventArgs args);

        public event FightHandler Block;
        public event FightHandler Wound;
        public event FightHandler Death;

        public void OnBlock(FightEventArgs args)
        {
            Block?.Invoke(this, args);
        }

        public void OnWound(FightEventArgs args)
        {
            Wound?.Invoke(this, args);
        }

        public void OnDeath(FightEventArgs args)
        {
            Death?.Invoke(this, args);
        }
    }
}
