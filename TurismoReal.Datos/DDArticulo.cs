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
    public class DDArticulo
    {
        public DataTable ListarArticulo()
        {
            WSPortafolioClient client = null;
            DataTable dataTable = new DataTable();

            try
            {
                client = new WSPortafolioClient();

                // Llamamos al método del servicio web para obtener una lista de administradores
                articulo[] lista = client.listarArticulo();

                // Verificar si hay registros antes de continuar
                if (lista != null && lista.Length > 0)
                {
                    // Configurar las columnas del DataTable
                    dataTable.Columns.Add("Id Articulo", typeof(int));
                    dataTable.Columns.Add("Descripcion", typeof(string));
                    dataTable.Columns.Add("Stock", typeof(int));
                    dataTable.Columns.Add("Precio", typeof(int));

                    foreach (var art in lista)
                    {
                        // Crear una nueva fila en el DataTable
                        DataRow row = dataTable.NewRow();

                        // Asignar los valores del administrador a las columnas correspondientes
                        row["Id Articulo"] = art.id_articulo;
                        row["Descripcion"] = art.descripcion;
                        row["Stock"] = art.stock;
                        row["Precio"] = art.precio;

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

        public bool AgregarArticulo(string descripcion, int stock, int precio)
        {
            bool ward = false;
            WSPortafolioClient client = null; // Declaración del cliente proxy

            try
            {
                client = new WSPortafolioClient(); // Crear instancia del cliente proxy

                // Llamar al procedimiento agregarAdministrador del servicio web
                ward = client.agregarArticulo(descripcion,stock,precio);
            }
            catch (Exception ex)
            {
                // Manejo de excepciones o registro de errores
                Console.WriteLine("Error al agregar articulo: " + ex.Message);
            }
            finally
            {
                // Cerrar el cliente proxy
                if (client != null)
                {
                    client.Close();
                }
            }
            return ward;
        }

        public bool modificarArticulo(int id_art,string descripcion, int stock, int precio)
        {
            bool ward = false;
            WSPortafolioClient client = null;

            try
            {
                client = new WSPortafolioClient();

                // Llama al procedimiento modificarAdministrador del servicio web con dos valores de rut
                ward = client.modificarArticulo(id_art,descripcion,stock,precio);


                if (ward)
                {
                    Console.WriteLine("Articulo actualizado correctamente.");
                }
                else
                {
                    Console.WriteLine("Error al actualizar articulo.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al actualizar articulo: " + ex.Message);
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

        public bool EliminarArticulo(int rut)
        {
            bool ward = false;
            WSPortafolioClient client = null;

            try
            {
                client = new WSPortafolioClient();
                ward = client.eliminarArticulo(rut);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al eliminar articulo: " + ex.Message);
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
