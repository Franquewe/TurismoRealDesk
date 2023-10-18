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
    public partial class FrmDepartamento : MetroFramework.Forms.MetroForm
    {
        public FrmDepartamento()
        {
            InitializeComponent();
        }

        private void ListarDepartamentos()
        {
            try
            {
                NDepartamento negocioDepartamento = new NDepartamento();
                DataTable dataTable = negocioDepartamento.Listar();

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


        private void Formato()
        {
            // Verifica si hay suficientes columnas antes de intentar configurarlas
            if (DGVListar.Columns.Count > 10)
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
                DGVListar.Columns[10].Width = 100;
            }
        }

        private void Limpiar()
        {
            TxtBuscar.Clear();
            TxtDireccion.Clear();
            TxtDescripcion.Clear();
            TxtPrecio.Clear();
            TxtLatitud.Clear();
            TxtLongitud.Clear();
            TxtCapacidad.Clear();
            TxtCantImagenes.Clear();
            TxtIdComuna.Clear();
            TxtIdEstado.Clear();
            BtnAgregar.Visible = true;
            BtnModificar.Visible = false;

            DGVListar.Columns[0].Visible = false;
            BtnEliminar.Visible = false;
            CbSeleccionar.Checked = false;
        }

        private void FrmDepartamento_Load(object sender, EventArgs e)
        {
            this.ListarDepartamentos();
        }

        private void DGVListar_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == DGVListar.Columns["Seleccionar"].Index)
            {
                DataGridViewCheckBoxCell CbEliminar = (DataGridViewCheckBoxCell)DGVListar.Rows[e.RowIndex].Cells["Seleccionar"];
                CbEliminar.Value = !Convert.ToBoolean(CbEliminar.Value);
            }
        }

        private void BtnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                string direccion = TxtDireccion.Text;
                string descripcion = TxtDescripcion.Text;
                int precio = int.Parse(TxtPrecio.Text);
                float latitud = float.Parse(TxtLatitud.Text);
                float longitud = float.Parse(TxtLongitud.Text);
                int capacidadPersona = int.Parse(TxtCapacidad.Text);
                int cantidadImagenes = int.Parse(TxtCantImagenes.Text);
                int idComuna = int.Parse(TxtIdComuna.Text);
                int idEstado = int.Parse(TxtIdEstado.Text);

                bool resultado = NDepartamento.AgregarDepartamento(direccion, descripcion, precio, latitud, longitud, capacidadPersona, cantidadImagenes, idComuna, idEstado);

                if (resultado)
                {
                    MetroFramework.MetroMessageBox.Show(this, "Departamento agregado correctamente", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MetroFramework.MetroMessageBox.Show(this, "Error al agregar departamento", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MetroFramework.MetroMessageBox.Show(this, "Ocurrió un error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DGVListar_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
                this.Limpiar();
                BtnModificar.Visible = true;
                BtnAgregar.Visible = false;
                TxtIdDepartamento.Text = Convert.ToString(DGVListar.CurrentRow.Cells["ID"].Value);
                TxtDireccion.Text = Convert.ToString(DGVListar.CurrentRow.Cells["Direccion"].Value);
                TxtDescripcion.Text = Convert.ToString(DGVListar.CurrentRow.Cells["Descripcion"].Value);
                TxtPrecio.Text = Convert.ToString(DGVListar.CurrentRow.Cells["Precio"].Value);
                TxtLatitud.Text = Convert.ToString(DGVListar.CurrentRow.Cells["Latitud"].Value);
                TxtLongitud.Text = Convert.ToString(DGVListar.CurrentRow.Cells["Longitud"].Value);
                TxtCapacidad.Text = Convert.ToString(DGVListar.CurrentRow.Cells["Capacidad"].Value);
                TxtIdComuna.Text = Convert.ToString(DGVListar.CurrentRow.Cells["Comuna"].Value);
                TxtIdEstado.Text = Convert.ToString(DGVListar.CurrentRow.Cells["Estado"].Value);
                TabGeneral.SelectedIndex = 1;     
        }

        private void BtnModificar_Click(object sender, EventArgs e)
        {
            try
            {
                // Obtén el valor del ID del departamento desde el control TxtIdDepartamento
                if (!int.TryParse(TxtIdDepartamento.Text, out int id_departamento))
                {
                    MetroFramework.MetroMessageBox.Show(this, "El valor del ID no es válido", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return; // Sal del evento si el ID no es válido
                }

                string direccion = TxtDireccion.Text;
                string descripcion = TxtDescripcion.Text;
                if (!int.TryParse(TxtPrecio.Text, out int precio))
                {
                    MetroFramework.MetroMessageBox.Show(this, "El valor de precio no es válido", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return; // Sal del evento si el precio no es válido
                }

                if (!float.TryParse(TxtLatitud.Text, out float latitud))
                {
                    MetroFramework.MetroMessageBox.Show(this, "El valor de latitud no es válido", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return; // Sal del evento si la latitud no es válida
                }

                if (!float.TryParse(TxtLongitud.Text, out float longitud))
                {
                    MetroFramework.MetroMessageBox.Show(this, "El valor de longitud no es válido", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return; // Sal del evento si la longitud no es válida
                }

                if (!int.TryParse(TxtCapacidad.Text, out int capacidadPersona))
                {
                    MetroFramework.MetroMessageBox.Show(this, "El valor de capacidad de personas no es válido", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return; // Sal del evento si la capacidad de personas no es válida
                }

                if (!int.TryParse(TxtCantImagenes.Text, out int cantidadImagenes))
                {
                    MetroFramework.MetroMessageBox.Show(this, "El valor de cantidad de imágenes no es válido", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return; // Sal del evento si la cantidad de imágenes no es válida
                }

                if (!int.TryParse(TxtIdComuna.Text, out int idComuna))
                {
                    MetroFramework.MetroMessageBox.Show(this, "El valor del ID de la comuna no es válido", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return; // Sal del evento si el ID de la comuna no es válido
                }

                if (!int.TryParse(TxtIdEstado.Text, out int idEstado))
                {
                    MetroFramework.MetroMessageBox.Show(this, "El valor del ID del estado no es válido", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return; // Sal del evento si el ID del estado no es válido
                }

                // Llama al método de negocio para modificar el departamento
                bool resultado = NDepartamento.ModificarDepartamento(id_departamento, direccion, descripcion, precio, latitud, longitud, capacidadPersona, cantidadImagenes, idComuna, idEstado);

                // Verifica el resultado y muestra un mensaje correspondiente
                if (resultado)
                {
                    // Operación exitosa
                    MetroFramework.MetroMessageBox.Show(this, "Departamento modificado correctamente", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    // Error
                    MetroFramework.MetroMessageBox.Show(this, "Error al modificar el departamento", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                // Manejo de excepciones
                MetroFramework.MetroMessageBox.Show(this, "Ocurrió un error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                opcion = MetroFramework.MetroMessageBox.Show(this, "¿Desea eliminar el departamento?", "Confirmación", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

                if (opcion == DialogResult.OK)
                {
                    int id_departamento;

                    foreach (DataGridViewRow row in DGVListar.Rows)
                    {
                        if (Convert.ToBoolean(row.Cells[0].Value))
                        {
                            id_departamento = Convert.ToInt32(row.Cells["ID"].Value);

                            // Llamar al método de negocio para eliminar el departamento
                            bool resultado = NDepartamento.EliminarDepartamento(id_departamento);

                            if (resultado)
                            {
                                this.MensajeOk("Se eliminó el departamento con ID " + id_departamento);
                            }
                            else
                            {
                                this.MensajeError("Error al eliminar el departamento con ID " + id_departamento);
                            }
                        }
                    }

                    // Actualizar la lista después de la eliminación
                    this.ListarDepartamentos();
                }
            }
            catch (Exception ex)
            {
                MetroFramework.MetroMessageBox.Show(this, "Ocurrió un error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            this.Limpiar();
            TabGeneral.SelectedIndex = 0;
        }
    }
}
