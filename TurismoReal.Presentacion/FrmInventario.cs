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
using TurismoReal.Entidades;

namespace TurismoReal.Presentacion
{
    public partial class FrmInventario : MetroFramework.Forms.MetroForm
    {
        public FrmInventario()
        {
            InitializeComponent();
        }

        private void ListarInventario()
        {
            try
            {
                DataTable dataTable = NInventario.Listar();

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


        private void FrmInventario_Load(object sender, EventArgs e)
        {
            ListarInventario();
        }

        private void Formato()
        {
            // Verifica si hay suficientes columnas antes de intentar configurarlas
            if (DGVListar.Columns.Count > 4)
            {
                DGVListar.Columns[0].Visible = false;
                DGVListar.Columns[1].Visible = true;
                DGVListar.Columns[2].Width = 200;
                DGVListar.Columns[3].Width = 200;
                DGVListar.Columns[4].Width = 200;
            }
        }

        private void Limpiar()
        {
            TxtBuscar.Clear();
            TxtIdArticulo.Clear();
            TxtIdDepto.Clear();
            TxtCantidad.Clear();
            BtnAgregar.Visible = true;
            BtnModificar.Visible = false;

            DGVListar.Columns[0].Visible = false;
            BtnEliminar.Visible = false;
            CbSeleccionar.Checked = false;
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
                // Obtener los valores ingresados por el usuario desde los TextBox
                if (int.TryParse(TxtIdArticulo.Text, out int idArticulo) &&
                    int.TryParse(TxtIdDepto.Text, out int idDepartamento) &&
                    int.TryParse(TxtCantidad.Text, out int cantidad))
                {
                    // Llamar al método de negocio para agregar inventario
                    bool resultado = NInventario.AgregarInventario(idArticulo, idDepartamento, cantidad);

                    // Verificar el resultado y mostrar el cuadro de mensaje correspondiente
                    if (resultado)
                    {
                        // Operación exitosa
                        MetroFramework.MetroMessageBox.Show(this, "Inventario agregado correctamente", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        // Limpiar los TextBox después de agregar inventario
                        TxtIdArticulo.Clear();
                        TxtIdDepto.Clear();
                        TxtCantidad.Clear();
                    }
                    else
                    {
                        // Error
                        MetroFramework.MetroMessageBox.Show(this, "Error al agregar inventario", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    // Mostrar un mensaje de error si los valores ingresados no son válidos
                    MetroFramework.MetroMessageBox.Show(this, "Por favor, ingrese valores válidos para ID de artículo, ID de departamento y cantidad", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                // Manejo de excepciones
                MetroFramework.MetroMessageBox.Show(this, "Ocurrió un error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LblStock_Click(object sender, EventArgs e)
        {

        }

        private void BtnModificar_Click(object sender, EventArgs e)
        {
            try
            {
                if (!int.TryParse(TxtIdArticulo.Text, out int idArticulo))
                {
                    MetroFramework.MetroMessageBox.Show(this, "El valor del ID de artículo no es válido", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (!int.TryParse(TxtIdDepto.Text, out int idDepartamento))
                {
                    MetroFramework.MetroMessageBox.Show(this, "El valor del ID de departamento no es válido", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (!int.TryParse(TxtCantidad.Text, out int cantidad))
                {
                    MetroFramework.MetroMessageBox.Show(this, "El valor de cantidad no es válido", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Crear un objeto Inventario con los datos del formulario
                Inventario inv = new Inventario
                {
                    id_articulo = idArticulo,
                    id_departamento = idDepartamento,
                    cantidad = cantidad
                };

                // Llamar al método de negocio para modificar el inventario
                bool resultado = NInventario.ModificarInventario(inv);

                if (resultado)
                {
                    MetroFramework.MetroMessageBox.Show(this, "Inventario modificado correctamente", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MetroFramework.MetroMessageBox.Show(this, "Error al modificar inventario", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
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
                TxtIdArticulo.Text = Convert.ToString(DGVListar.CurrentRow.Cells["Id Articulo"].Value);
                TxtIdDepto.Text = Convert.ToString(DGVListar.CurrentRow.Cells["Id Departamento"].Value);
                TxtCantidad.Text = Convert.ToString(DGVListar.CurrentRow.Cells["Cantidad"].Value);
                TabGeneral.SelectedIndex = 1;
            }
            catch (Exception)
            {
                MetroFramework.MetroMessageBox.Show(this, "Seleccione desde la celda nombre");
            }
        }

        private void BtnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult opcion;
                opcion = MetroFramework.MetroMessageBox.Show(this, "¿Desea eliminar el inventario?", "Confirmar Eliminación", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

                if (opcion == DialogResult.OK)
                {
                    int id_depa, id_art;

                    foreach (DataGridViewRow row in DGVListar.Rows)
                    {
                        if (Convert.ToBoolean(row.Cells[0].Value))
                        {
                            // Obtén el ID de departamento e ID de artículo de la fila seleccionada
                            id_depa = Convert.ToInt32(row.Cells["Id Departamento"].Value);
                            id_art = Convert.ToInt32(row.Cells["Id Articulo"].Value);

                            // Llama al método de negocio para eliminar el inventario
                            bool resultado = NInventario.EliminarInventario(id_depa, id_art);

                            if (resultado)
                            {
                                this.MensajeOk("Inventario eliminado correctamente.");
                            }
                            else
                            {
                                this.MensajeError("Error al eliminar inventario.");
                            }
                        }
                    }

                    // Actualiza la lista después de la eliminación
                    this.ListarInventario();
                }
            }
            catch (Exception ex)
            {
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

        private void DGVListar_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == DGVListar.Columns["Seleccionar"].Index)
            {
                DataGridViewCheckBoxCell CbEliminar = (DataGridViewCheckBoxCell)DGVListar.Rows[e.RowIndex].Cells["Seleccionar"];
                CbEliminar.Value = !Convert.ToBoolean(CbEliminar.Value);
            }
        }

        private void DGVListar_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Verifica si se hizo clic en una celda válida
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                // Obtiene el valor de la celda de la columna que muestra el ID
                int id_art = Convert.ToInt32(DGVListar.Rows[e.RowIndex].Cells["Id Articulo"].Value);
                // Asigna el valor a un campo oculto o bloqueado en tu formulario (por ejemplo, TxtId)
                TxtIdArticulo.Text = id_art.ToString();
            }
        }
    }
}
