using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FightClub_v2._1
{
    public partial class PlayerForm : Form
    {
        public PlayerForm()
        {
            InitializeComponent();
        }

        public event EventHandler AtackHeadClick;
        public event EventHandler AtackBodyClick;
        public event EventHandler AtackLegsClick;
        public event EventHandler BlockHeadClick;
        public event EventHandler BlockBodyClick;
        public event EventHandler BlockLegsClick;
        public event EventHandler SetFirstPlayer;

        private void head_Click(object sender, EventArgs e)
        {
            if(atack.Text=="нападает")
            {
                AtackHeadClick?.Invoke(this, EventArgs.Empty);
            }
            else
            {
                BlockHeadClick?.Invoke(this, EventArgs.Empty);
            }

        }

        private void body_Click(object sender, EventArgs e)
        {
            if (atack.Text == "нападает")
            {
                AtackBodyClick?.Invoke(this, EventArgs.Empty);
            }
            else
            {
                BlockBodyClick?.Invoke(this, EventArgs.Empty);
            }
        }

        private void legs_Click(object sender, EventArgs e)
        {
            if (atack.Text == "нападает")
            {
                AtackLegsClick?.Invoke(this, EventArgs.Empty);
            }
            else
            {
                BlockLegsClick?.Invoke(this, EventArgs.Empty);
            }
        }

        private void PlayerForm_Load(object sender, EventArgs e)
        {
            SetFirstPlayer?.Invoke(this, EventArgs.Empty);
        }

        private void PlayerForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
