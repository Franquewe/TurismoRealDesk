using System;
using System.Collections.Generic;
using TurismoReal.Datos.WSportafolio;
using System.Data;
using TurismoReal.Entidades;

namespace TurismoReal.Datos
{
    public class DDFuncionario
    {
        // Método que devuelve un DataTable con la lista de administradores
        public DataTable ListarFuncionario()
        {
            WSPortafolioClient client = null;
            DataTable dataTable = new DataTable();

            try
            {
                client = new WSPortafolioClient();

                // Llamamos al método del servicio web para obtener una lista de administradores
                funcionario[] lista = client.listarFuncionario();

                // Verificar si hay registros antes de continuar
                if (lista != null && lista.Length > 0)
                {
                    // Configurar las columnas del DataTable
                    dataTable.Columns.Add("RUT", typeof(int));
                    dataTable.Columns.Add("DV", typeof(string));
                    dataTable.Columns.Add("Nombre", typeof(string));
                    dataTable.Columns.Add("ApellidoPaterno", typeof(string));
                    dataTable.Columns.Add("ApellidoMaterno", typeof(string));
                    dataTable.Columns.Add("Correo", typeof(string));
                    dataTable.Columns.Add("Usuario", typeof(string));
                    dataTable.Columns.Add("Contrasena", typeof(string));
                    dataTable.Columns.Add("Telefono", typeof(string));

                    foreach (var adm in lista)
                    {
                        // Crear una nueva fila en el DataTable
                        DataRow row = dataTable.NewRow();

                        // Asignar los valores del administrador a las columnas correspondientes
                        row["RUT"] = adm.rut;
                        row["DV"] = adm.dv;
                        row["Nombre"] = adm.nombre;
                        row["ApellidoPaterno"] = adm.apellido_paterno;
                        row["ApellidoMaterno"] = adm.apellido_materno;
                        row["Correo"] = adm.correo;
                        row["Usuario"] = adm.usuario;
                        row["Contrasena"] = adm.contrasena;
                        row["Telefono"] = adm.telefono;
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

        public bool AgregarFuncionario(int rut, string dv, string nombre, string apellido_paterno, string apellido_materno,
                                 string correo, string usuario, string contrasena, string telefono)
        {
            bool ward = false;
            WSPortafolioClient client = null; // Declaración del cliente proxy

            try
            {
                client = new WSPortafolioClient(); // Crear instancia del cliente proxy

                // Llamar al procedimiento agregarAdministrador del servicio web
                ward = client.agregarFuncionario(rut, dv, nombre, apellido_paterno, apellido_materno, correo, usuario, contrasena, telefono);
            }
            catch (Exception ex)
            {
                // Manejo de excepciones o registro de errores
                Console.WriteLine("Error al agregar funcionario: " + ex.Message);
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

        public bool modificarFuncionario(int rut, string dv, string nombre, string apellido_paterno, string apellido_materno,
                                   string correo, string usuario, string contrasena, string telefono)
        {
            bool ward = false;
            WSPortafolioClient client = null;

            try
            {
                client = new WSPortafolioClient();

                // Llama al procedimiento modificarAdministrador del servicio web con dos valores de rut
                ward = client.modificarFuncionario(rut, rut, dv, nombre, apellido_paterno, apellido_materno, correo, usuario, contrasena, telefono);


                if (ward)
                {
                    Console.WriteLine("Funcionario actualizado correctamente.");
                }
                else
                {
                    Console.WriteLine("Error al actualizar funcionario.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al actualizar funcionario: " + ex.Message);
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

        public bool EliminarFuncionario(int rut)
        {
            bool ward = false;
            WSPortafolioClient client = null;

            try
            {
                client = new WSPortafolioClient();
                ward = client.eliminarFuncionario(rut);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al eliminar funcionario: " + ex.Message);
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
