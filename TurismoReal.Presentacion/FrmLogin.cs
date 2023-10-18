using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TurismoReal.Presentacion.WSportafolio;

namespace TurismoReal.Presentacion
{
    public partial class FrmLogin : MetroFramework.Forms.MetroForm
    {
        public FrmLogin()
        {
            InitializeComponent();
        }

        private void FrmLogin_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void BtnAcceder_Click(object sender, EventArgs e)
        {
            try
            {
                String user = txtUsuario.Text;
                String pass = txtContrasena.Text;

                WSPortafolioClient cliente = new WSPortafolioClient();

                if (cliente.login(user, pass) != null)
                {
                    if (cliente.login(user, pass).Equals("admin") || cliente.login(user, pass).Equals("funcionario"))
                    {
                        FrmPrincipal frm = new FrmPrincipal();
                        this.Hide();
                        frm.ShowDialog();
                        this.Close();
                    }
                    else if (cliente.login(user, pass).Equals("cliente"))
                    {
                        MetroFramework.MetroMessageBox.Show(this, "Usuario Cliente no tiene los permisos suficientes", "Notificación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        MetroFramework.MetroMessageBox.Show(this, "Credenciales incorrectas", "Notificación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MetroFramework.MetroMessageBox.Show(this, "Credenciales incorrectas", "Notificación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MetroFramework.MetroMessageBox.Show(this, ex.Message, "Notificación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

            private void Cancelar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
