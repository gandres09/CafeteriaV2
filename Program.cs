using CafeteriaV2.Data;
using CafeteriaV2.Models.Entities;
using CafeteriaV2.Views.Forms;
using System;
using System.Windows.Forms;

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
                    var usuario = loginForm.UsuarioAutenticado;
                    Application.Run(new MainForm(usuario));
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
