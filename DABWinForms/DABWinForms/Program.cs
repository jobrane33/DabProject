using DABWinForms.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DABWinForms
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            var crud = new Crud();
            //crud.LogIn(123456789, 1234);
            //crud.setValueAfterWithdrawl(123456789, 100);
            //crud.setValueForcheque(1, 1.2m, "bna");
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Login());
        }
    }
}
