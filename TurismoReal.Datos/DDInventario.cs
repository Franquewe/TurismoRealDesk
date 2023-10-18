using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using TurismoReal.Datos.WSportafolio;
using TurismoReal.Entidades;

namespace TurismoReal.Datos
{
    public class DDInventario
    {
        public DataTable ListarInventario()
        {
            WSPortafolioClient client = null;
            DataTable dataTable = new DataTable();

            try
            {
                client = new WSPortafolioClient();

                // Llamamos al método del servicio web para obtener una lista de inventario
                inventario[] lista = client.listarInventario();

                // Verificar si hay registros antes de continuar
                if (lista != null && lista.Length > 0)
                {
                    // Configurar las columnas del DataTable
                    dataTable.Columns.Add("Id Articulo", typeof(int));
                    dataTable.Columns.Add("Id Departamento", typeof(int));
                    dataTable.Columns.Add("Cantidad", typeof(int));

                    foreach (var inv in lista)
                    {
                        // Crear una nueva fila en el DataTable
                        DataRow row = dataTable.NewRow();

                        // Asignar los valores del inventario a las columnas correspondientes
                        row["Id Articulo"] = inv.id_articulo;
                        row["Id Departamento"] = inv.id_departamento;
                        row["Cantidad"] = inv.cantidad;

                        // Agregar más propiedades según las columnas que hayas definido.

                        // Agregar la fila al DataTable
                        dataTable.Rows.Add(row);
                    }
                }

                return dataTable;
            }
            catch (Exception ex)
            {
                // Manejo de excepciones o registro de errores
                throw ex;
            }
            finally
            {
                if (client != null)
                {
                    client.Close();
                }
            }
        }

        public bool AgregarInventario(int idArticulo, int idDepartamento, int cantidad)
        {
            try
            {
                WSPortafolioClient client = new WSPortafolioClient(); // Suponiendo que tienes una instancia del cliente proxy

                // Llamar al procedimiento agregarInventario del servicio web, pasando los IDs del artículo y departamento
                return client.agregarInventario(idArticulo, idDepartamento, cantidad);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error en capa de datos al agregar inventario: " + ex.Message);
                return false; // Indica que la operación no se realizó con éxito
            }
        }

        public bool ModificarInventario(Inventario inv)
        {
            WSPortafolioClient client = null;

            try
            {
                client = new WSPortafolioClient();

                // Llama al procedimiento para modificar el inventario
                bool success = client.modificarInventario(inv.id_departamento, inv.id_articulo, inv.cantidad);

                return success;
            }
            catch (Exception ex)
            {
                // Manejo de excepciones o registro de errores
                throw ex;
            }
            finally
            {
                if (client != null)
                {
                    client.Close();
                }
            }
        }

        public bool EliminarInventario(int id_depa, int id_art)
        {
            bool ward = false;
            WSPortafolioClient client = null;

            try
            {
                client = new WSPortafolioClient();

                // Llama al procedimiento eliminarInventario del servicio web
                ward = client.eliminarInventario(id_depa, id_art);

                if (ward)
                {
                    Console.WriteLine("Inventario eliminado correctamente.");
                }
                else
                {
                    Console.WriteLine("Error al eliminar inventario.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al eliminar inventario: " + ex.Message);
            }
            finally
            {
                if (client != null)
                {
                    client.Close();
                }
            }

            return ward;
        }


    }
}
