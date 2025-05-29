using CafeteriaV2.Models.Entities;
using CafeteriaV2.Views.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CafeteriaV2
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            var loginForm = new FormLogin();
            if (loginForm.ShowDialog() == DialogResult.OK)
            {
                // Usuario autenticado exitosamente  
                var usuario = loginForm.UsuarioAutenticado;
                this.Text = $"CafeteriaV2 - {usuario.NombreUsuario} ({usuario.Rol})";
                // Configurar permisos según el rol  
            }
            else
            {
                // Usuario canceló o falló la autenticación  
                Application.Exit();
            }
        }
    }
}
