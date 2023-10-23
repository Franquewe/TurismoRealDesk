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
using TurismoReal.Entidades;

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

                loginC login = cliente.metodoLogin(user, pass);
                String tipoUsuario = login.tipo_usuario;
                int rut = login.rut;

                if (tipoUsuario != null)
                {
                    if (tipoUsuario == "admin" || tipoUsuario == "funcionario")
                    {
                        FrmPrincipal frm = new FrmPrincipal(tipoUsuario, rut);
                        this.Hide();
                        frm.ShowDialog();
                        this.Close();
                    }
                    else if (tipoUsuario == "cliente")
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

        private void txtContrasena_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                // Llamar al método de inicio de sesión cuando se presiona Enter
                BtnAcceder_Click(sender, e);
            }
        }

        private void txtUsuario_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                // Llamar al método de inicio de sesión cuando se presiona Enter
                BtnAcceder_Click(sender, e);
            }
        }
    }
}
