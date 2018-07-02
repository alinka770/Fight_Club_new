using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FightClub_v2._1
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            
            InputName nameInput = new InputName();
            PlayerForm user = new PlayerForm();
            PlayerForm comp = new PlayerForm();
            Lose1 lose = new Lose1();
            Log log = new Log();
           
            // Model
           Player computer = new Player("computer");
           Player player = new Player("player");
        
            // Presenter
            Game new_gme = new Game(player, computer, nameInput, log, user, comp, lose);

            Application.Run(nameInput);
        }
    }
}
