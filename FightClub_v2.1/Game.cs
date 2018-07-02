using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FightClub_v2._1
{
    class Game
    {
        public Player comp= new Player("Компьютер");
        public Player user= new Player("");
        public PlayerForm playerform = new PlayerForm();
        public PlayerForm compform = new PlayerForm();
        public InputName input = new InputName();
        public Log log = new Log();

        void Round(Player player, Player defender, BodyParts part)
        {
            BodyParts comp = (BodyParts)(new Random().Next(0, 2));
           
            if (defender.Name == "computer")
            {
                defender.SetBlock(comp);
                defender.GetHit(part);
                compform.progressBar1.Value = defender.HP;
                

                playerform.atack.Text = "нападает";
                compform.atack.Text = "защищается";
            }
            else
            {
                defender.SetBlock(part);
                defender.GetHit(comp);
                playerform.progressBar1.Value = defender.HP;
                playerform.atack.Text = "защищается";
                compform.atack.Text = "нападает";
            }
            SetHpValues();
        }

        void SetHpValues()
        {
            playerform.progressBar1.Value = comp.HP;
            compform.progressBar1.Value = user.HP;
            playerform.label1.Text = comp.HP.ToString();
            compform.label1.Text = user.HP.ToString();
           
        }

        private void playerBlock(object sender, FightEventArgs args)
        {
            SetHpValues();
            log.label1.Text+="Удар заблокирован! ";
            log.label1.Text += args.Name + " HP: " + args.Hp + ".";
        }

        private void playerWound(object sender, FightEventArgs args)
        {
            SetHpValues();
            log.label1.Text += "\nОй, похоже вас ударили. ";
            log.label1.Text += args.Name + " HP: " + args.Hp + ".";
        }

        private void Death(object sender, FightEventArgs args)
        {
            if (args.Name == "computer")
            {
                log.label1.Text+= "Ты проиграл!";
            }
            else
            {
                log.label1.Text += "Ты победил!";
            }
            MessageBox.Show("Выиграл: " + args.Name);

        }


        private void ComputerBlock(object sender, FightEventArgs args)
        {
            SetHpValues();
            log.label1.Text += "\nОтлично! Ты молодчина!";

        }

        private void ComputerWound(object sender, FightEventArgs args)
        {
            SetHpValues();
            if (args.Hp > 40)
            {
                log.label1.Text += "\nОго какой удар!";
                
            }
            else
            {
                log.label1.Text += "\nНеплохо бьешься!";
            }
        }

        private void SetFirstPlayer(object sender, EventArgs e)
        {
            log.label1.Text+="Надери ему задницу, сынок!";
            comp.Death += Death;
            user.Death += Death;
            int a = new Random().Next(0, 1);
            if (a == 0)
            {
                log.label1.Text += "Вы ходите первым.";
                compform.head.Enabled = false;
                compform.body.Enabled = false;
                compform.legs.Enabled = false;
                playerform.atack.Text = "нападает";
                compform.atack.Text = "защищается";

            }
            if (a == 1)
            {
                log.label1.Text += "Компьютер ходит первым.";
                playerform.head.Enabled = false;
                playerform.body.Enabled = false;
                playerform.legs.Enabled = false;
                playerform.atack.Text = "защищается";
                compform.atack.Text = "нападает";
            }
            SetHpValues();
        }

        private void AtackHeadClick(object sender, EventArgs e)
        {
            Round(comp, user, BodyParts.head);

        }
        private void AtackBodyClick(object sender, EventArgs e)
        {
            Round(comp, user, BodyParts.body);
        }
        private void AtackLegsClick(object sender, EventArgs e)
        {
            Round(comp, user, BodyParts.legs);
        }
        private void BlockHeadClick(object sender, EventArgs e)
        {
            Round(user, comp, BodyParts.head);
        }
        private void BlockBodyClick(object sender, EventArgs e)
        {
            Round(user, comp, BodyParts.body);
        }
        private void BlockLegsClick(object sender, EventArgs e)
        {
            Round(user, comp, BodyParts.legs);
        }


        public Game(Player user_, Player comp_, InputName input_, Log log_,
            PlayerForm playerform_, PlayerForm computer)
        {

            compform.head.Enabled = false;
            compform.body.Enabled = false;
            compform.legs.Enabled = false;
            user.Block += playerBlock;
            user.Wound += playerWound;
            user.Death += Death;
            user = user_;
            comp = comp_;
            log = log_;
            input = input_;
            playerform = playerform_;
            compform = computer;
            input.NameIsOK += NameSubmitClick;
            playerform.AtackHeadClick += AtackHeadClick;
            playerform.AtackBodyClick += AtackBodyClick;
            playerform.AtackLegsClick += AtackLegsClick;
            playerform.BlockHeadClick += BlockHeadClick;
            playerform.BlockBodyClick += BlockBodyClick;
            playerform.BlockLegsClick += BlockLegsClick;
            playerform.SetFirstPlayer += SetFirstPlayer;
            comp.Block += ComputerBlock;
            comp.Wound += ComputerWound;
            comp.Death += Death;
        }
        private void NameSubmitClick(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(input.name.Text) && !string.IsNullOrWhiteSpace(input.name.Text))
            {
                user.Name = input.name.Text;
                playerform.label2.Text = input.name.Text;
            }
            else
            {
                playerform.label2.Text = "Игрок";
            }
            playerform.label1.Text = "100";
            compform.label1.Text = "100";
            log.Show();
            playerform.Show();
            compform.Show();

        }

    }
}
