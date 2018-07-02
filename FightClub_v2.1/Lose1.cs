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
    public partial class Lose1 : Form
    {
        public Lose1()
        {
            InitializeComponent();
        }
        public Lose1(string str)
        {
            label1.Text = str;
        }
        private void Lose1_Load(object sender, EventArgs e)
        {

        }
    }
}
