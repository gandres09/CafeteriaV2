using CafeteriaV2.Views.Forms;
using System;
using System.Windows.Forms;
using Microsoft.Data.Sqlite;
using CafeteriaV2.Data;

namespace CafeteriaV2
{
    static class Program
    {
        [STAThread]

        static void Main()
        {
            BaseDatos.Inicializar();
            SQLitePCL.Batteries_V2.Init();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            using (var loginForm = new FormLogin())
            {
                if (loginForm.ShowDialog() == DialogResult.OK)
                {
                    Application.Run(new MainForm());
                }
                else
                {
                    // Si el usuario cierra o cancela el login
                    Application.Exit();
                }
            }
        }
    }

}
