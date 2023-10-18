using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TurismoReal.Negocio;
using TurismoReal.Presentacion.WSportafolio;

namespace TurismoReal.Presentacion
{
    public partial class FrmFuncionario : MetroFramework.Forms.MetroForm
    {
        public FrmFuncionario()
        {
            InitializeComponent();
        }
        private void Listar()
        {
            try
            {
                DataTable dataTable = NFuncionario.Listar();

                if (dataTable != null)
                {
                    DGVListar.DataSource = dataTable;
                    this.Formato();
                    this.Limpiar();
                    LblTotal.Text = "Total de registros: " + Convert.ToString(DGVListar.Rows.Count);
                }
                else
                {
                    DGVListar.DataSource = null; // Limpiar el control DataGridView
                    LblTotal.Text = "No hay registros para mostrar";
                }
            }
            catch (Exception ex)
            {
                MetroFramework.MetroMessageBox.Show(this, ex.Message + ex.StackTrace);
            }
        }

        private void FrmFuncionario_Load(object sender, EventArgs e)
        {
            this.Listar();
        }

        private void Limpiar()
        {
            TxtBuscar.Clear();
            TxtRut.Clear();
            TxtDv.Clear();
            TxtNombre.Clear();
            TxtApellidoP.Clear();
            TxtApellidoM.Clear();
            TxtTelefono.Clear();
            TxtCorreo.Clear();
            TxtUsuario.Clear();
            TxtContrasena.Clear();
            BtnAgregar.Visible = true;
            BtnModificar.Visible = false;

            DGVListar.Columns[0].Visible = false;
            BtnEliminar.Visible = false;
        }

        private void Formato()
        {
            // Verifica si hay suficientes columnas antes de intentar configurarlas
            if (DGVListar.Columns.Count > 9)
            {
                DGVListar.Columns[0].Visible = false;
                DGVListar.Columns[1].Visible = true;
                DGVListar.Columns[2].Width = 100;
                DGVListar.Columns[3].Width = 100;
                DGVListar.Columns[4].Width = 100;
                DGVListar.Columns[5].Width = 100;
                DGVListar.Columns[6].Width = 100;
                DGVListar.Columns[7].Width = 100;
                DGVListar.Columns[8].Width = 100;
                DGVListar.Columns[9].Width = 100;
            }
        }

        private void MensajeOk(string mensaje)
        {
            MetroFramework.MetroMessageBox.Show(this, mensaje, "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void MensajeError(string mensaje)
        {
            MetroFramework.MetroMessageBox.Show(this, mensaje, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }


        private void BtnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                // Obtener los valores ingresados por el usuario desde las TextBox
                int rut = int.Parse(TxtRut.Text);
                string dv = TxtDv.Text;
                string nombre = TxtNombre.Text;
                string apellidoPaterno = TxtApellidoP.Text;
                string apellidoMaterno = TxtApellidoM.Text;
                string correo = TxtCorreo.Text;
                string usuario = TxtUsuario.Text;
                string contrasena = TxtContrasena.Text;
                string telefono = TxtTelefono.Text;

                // Llamar al método de negocio para agregar un funcionario
                bool resultado = NFuncionario.Insertar(rut, dv, nombre, apellidoPaterno, apellidoMaterno, correo, usuario, contrasena, telefono);

                // Verificar el resultado y mostrar el cuadro de mensaje correspondiente
                if (resultado)
                {
                    // Operación exitosa
                    MetroFramework.MetroMessageBox.Show(this, "Funcionario agregado correctamente", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    // Error
                    MetroFramework.MetroMessageBox.Show(this, "Error al agregar funcionario", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                // Manejo de excepciones
                MetroFramework.MetroMessageBox.Show(this, "Ocurrió un error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnModificar_Click(object sender, EventArgs e)
        {
            try
            {
                // Obtén el valor del rut desde el control TxtRut
                int rut = int.Parse(TxtRut.Text);
                string dv = TxtDv.Text;
                string nombre = TxtNombre.Text;
                string apellidoPaterno = TxtApellidoP.Text;
                string apellidoMaterno = TxtApellidoM.Text;
                string correo = TxtCorreo.Text;
                string usuario = TxtUsuario.Text;
                string contrasena = TxtContrasena.Text;
                string telefono = TxtTelefono.Text;

                // Llama al método de negocio para actualizar el cliente
                bool resultado = NFuncionario.ModificarFuncionario(rut, dv, nombre, apellidoPaterno, apellidoMaterno, correo, usuario, contrasena, telefono);

                // Verifica el resultado y muestra un mensaje correspondiente
                if (resultado)
                {
                    // Operación exitosa
                    MetroFramework.MetroMessageBox.Show(this, "Cliente actualizado correctamente", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    // Error
                    MetroFramework.MetroMessageBox.Show(this, "Error al actualizar cliente", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                // Manejo de excepciones
                MetroFramework.MetroMessageBox.Show(this, "Ocurrió un error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DGVListar_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                this.Limpiar();
                BtnModificar.Visible = true;
                BtnAgregar.Visible = false;
                TxtRut.Text = Convert.ToString(DGVListar.CurrentRow.Cells["RUT"].Value);
                TxtDv.Text = Convert.ToString(DGVListar.CurrentRow.Cells["DV"].Value);
                TxtNombre.Text = Convert.ToString(DGVListar.CurrentRow.Cells["Nombre"].Value);
                TxtApellidoP.Text = Convert.ToString(DGVListar.CurrentRow.Cells["ApellidoPaterno"].Value);
                TxtApellidoM.Text = Convert.ToString(DGVListar.CurrentRow.Cells["ApellidoMaterno"].Value);
                TxtTelefono.Text = Convert.ToString(DGVListar.CurrentRow.Cells["Telefono"].Value);
                TxtCorreo.Text = Convert.ToString(DGVListar.CurrentRow.Cells["Correo"].Value);
                TxtUsuario.Text = Convert.ToString(DGVListar.CurrentRow.Cells["Usuario"].Value);
                TxtContrasena.Text = Convert.ToString(DGVListar.CurrentRow.Cells["Contraseña"].Value);
                TabGeneral.SelectedIndex = 1;
            }
            catch (Exception)
            {
                MetroFramework.MetroMessageBox.Show(this, "Seleccione desde la celda nombre");
            }
        }

        private void CbSeleccionar_CheckedChanged(object sender, EventArgs e)
        {
            if (CbSeleccionar.Checked)
            {
                DGVListar.Columns[0].Visible = true;
                BtnEliminar.Visible = true;
            }
            else
            {
                DGVListar.Columns[0].Visible = false;
                BtnEliminar.Visible = false;
            }
        }

        private void BtnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult opcion;
                opcion = MetroFramework.MetroMessageBox.Show(this, "¿Desea eliminar el funcionario?", "Turismo Real", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

                if (opcion == DialogResult.OK)
                {
                    int codigo;
                    

                    foreach (DataGridViewRow row in DGVListar.Rows)
                    {
                        if (Convert.ToBoolean(row.Cells[0].Value))
                        {
                            codigo = Convert.ToInt32(row.Cells[1].Value);

                            // Llamar al método de negocio para eliminar al administrador
                            bool resultado = NFuncionario.EliminarFuncionario(codigo);

                            if (resultado)
                            {
                                this.MensajeOk("Se eliminó el registro " + Convert.ToString(row.Cells[2].Value));
                            }
                            else
                            {
                                this.MensajeError("Error al eliminar el registro " + Convert.ToString(row.Cells[2].Value));
                            }
                        }
                    }

                    // Actualizar la lista después de la eliminación
                    this.Listar();
                }
            }
            catch (Exception ex)
            {
                MetroFramework.MetroMessageBox.Show(this, "Ocurrió un error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void DGVListar_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == DGVListar.Columns["Seleccionar"].Index)
            {
                DataGridViewCheckBoxCell CbEliminar = (DataGridViewCheckBoxCell)DGVListar.Rows[e.RowIndex].Cells["Seleccionar"];
                CbEliminar.Value = !Convert.ToBoolean(CbEliminar.Value);
            }
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            this.Limpiar();
            TabGeneral.SelectedIndex = 0;
        }
    }

}

