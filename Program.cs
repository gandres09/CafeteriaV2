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
            Application.Run(new FormLogin());
        }
    }

}
