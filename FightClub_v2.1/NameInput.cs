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
    public partial class InputName : Form
    {
        public string playerName;
        public InputName()
        {
            InitializeComponent();
        }

        public event EventHandler NameIsOK;

        private void OK_Click(object sender, EventArgs e)
        {
            this.Hide();
            NameIsOK?.Invoke(this, EventArgs.Empty);
        }
    }
}
