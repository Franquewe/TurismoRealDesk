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
    public partial class FrmArticulo : MetroFramework.Forms.MetroForm
    {
        public FrmArticulo()
        {
            InitializeComponent();
        }

        private void Listar()
        {
            try
            {
                DataTable dataTable = NArticulo.Listar();

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
            if (DGVListar.Columns.Count > 4)
            {
                DGVListar.Columns[0].Visible = false;
                DGVListar.Columns[1].Visible = true;

                // Asegúrate de que las columnas 2, 3 y 4 estén dentro del rango válido
                if (DGVListar.Columns.Count > 2)
                {
                    DGVListar.Columns[2].Width = 400;
                }
                if (DGVListar.Columns.Count > 3)
                {
                    DGVListar.Columns[3].Width = 100;
                }
                if (DGVListar.Columns.Count > 4)
                {
                    DGVListar.Columns[4].Width = 100;
                }
            }
        }

        private void Limpiar()
        {
            TxtBuscar.Clear();
            TxtDescripcion.Clear();
            TxtPrecio.Clear();
            TxtStock.Clear();
            BtnAgregar.Visible = true;
            BtnModificar.Visible = false;

            DGVListar.Columns[0].Visible = false;
            BtnEliminar.Visible = false;
        }

        private void MensajeOk(string mensaje)
        {
            MetroFramework.MetroMessageBox.Show(this, mensaje, "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void MensajeError(string mensaje)
        {
            MetroFramework.MetroMessageBox.Show(this, mensaje, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void FrmArticulo_Load(object sender, EventArgs e)
        {
            Listar();
        }

        private void BtnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                // Obtener los valores ingresados por el usuario desde las TextBox
                string descripcion = TxtDescripcion.Text;
                int stock = int.Parse(TxtStock.Text);
                int precio = int.Parse(TxtPrecio.Text);


                // Llamar al método de negocio para agregar un administrador
                bool resultado = NArticulo.Insertar(descripcion, stock, precio);

                // Verificar el resultado y mostrar el cuadro de mensaje correspondiente
                if (resultado)
                {
                    // Operación exitosa
                    MetroFramework.MetroMessageBox.Show(this, "Articulo agregado correctamente", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    // Error
                    MetroFramework.MetroMessageBox.Show(this, "Error al agregar articulo", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                // Manejo de excepciones
                MetroFramework.MetroMessageBox.Show(this, "Ocurrió un error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            this.Limpiar();
            TabGeneral.SelectedIndex = 0;
        }

        private void DGVListar_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                this.Limpiar();
                BtnModificar.Visible = true;
                BtnAgregar.Visible = false;
                TxtDescripcion.Text = Convert.ToString(DGVListar.CurrentRow.Cells["descripcion"].Value);
                TxtStock.Text = Convert.ToString(DGVListar.CurrentRow.Cells["stock"].Value);
                TxtPrecio.Text = Convert.ToString(DGVListar.CurrentRow.Cells["precio"].Value);
                TabGeneral.SelectedIndex = 1;
            }
            catch (Exception)
            {
                MetroFramework.MetroMessageBox.Show(this, "Seleccione desde la celda nombre");
            }
        }

        private void BtnModificar_Click(object sender, EventArgs e)
        {
            try
            {
                // Obtén el valor del ID del artículo desde el control TxtId
                if (!int.TryParse(TxtId.Text, out int id_art))
                {
                    MetroFramework.MetroMessageBox.Show(this, "El valor del ID no es válido", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return; // Sal del evento si el ID no es válido
                }

                string descripcion = TxtDescripcion.Text;

                if (string.IsNullOrWhiteSpace(descripcion))
                {
                    MetroFramework.MetroMessageBox.Show(this, "La descripción no puede estar en blanco", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return; // Sal del evento si la descripción está en blanco
                }

                if (!int.TryParse(TxtStock.Text, out int stock))
                {
                    MetroFramework.MetroMessageBox.Show(this, "El valor de stock no es válido", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return; // Sal del evento si el stock no es válido
                }

                if (!int.TryParse(TxtPrecio.Text, out int precio))
                {
                    MetroFramework.MetroMessageBox.Show(this, "El valor de precio no es válido", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return; // Sal del evento si el precio no es válido
                }

                // Llama al método de negocio para actualizar el artículo
                bool resultado = NArticulo.ModificarArticulo(id_art, descripcion, stock, precio);

                // Verifica el resultado y muestra un mensaje correspondiente
                if (resultado)
                {
                    // Operación exitosa
                    MetroFramework.MetroMessageBox.Show(this, "Artículo actualizado correctamente", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    // Error
                    MetroFramework.MetroMessageBox.Show(this, "Error al actualizar artículo", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                // Manejo de excepciones
                MetroFramework.MetroMessageBox.Show(this, "Ocurrió un error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                    TxtId.Text = id_art.ToString();
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

        private void BtnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult opcion;
                opcion = MetroFramework.MetroMessageBox.Show(this, "¿Desea eliminar el articulo?", "Turismo Real", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

                if (opcion == DialogResult.OK)
                {
                    int codigo;


                    foreach (DataGridViewRow row in DGVListar.Rows)
                    {
                        if (Convert.ToBoolean(row.Cells[0].Value))
                        {
                            codigo = Convert.ToInt32(row.Cells[1].Value);

                            // Llamar al método de negocio para eliminar al administrador
                            bool resultado = NArticulo.EliminarArticulo(codigo);

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
    }
    }


