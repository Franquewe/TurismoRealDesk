using System;
using System.Collections.Generic;
using System.Data;
using TurismoReal.Datos.WSportafolio;
using TurismoReal.Entidades;
using System.Linq;

namespace TurismoReal.Datos
{
    public class DDDepartamento
    {
        public DataTable Listar()
        {
            WSPortafolioClient client = null;
            DataTable dataTable = new DataTable();

            try
            {
                client = new WSPortafolioClient();

                // Llama al método del servicio web para obtener una lista de departamentos
                departamentoDetalle[] lista = client.listarDepartamento();

                if (lista != null && lista.Length > 0)
                {
                    // Configura las columnas del DataTable
                    dataTable.Columns.Add("ID", typeof(int));
                    dataTable.Columns.Add("Direccion", typeof(string));
                    dataTable.Columns.Add("Descripcion", typeof(string));
                    dataTable.Columns.Add("Precio", typeof(int));
                    dataTable.Columns.Add("Latitud", typeof(float));
                    dataTable.Columns.Add("Longitud", typeof(float));
                    dataTable.Columns.Add("Capacidad", typeof(int));
                    dataTable.Columns.Add("Comuna", typeof(string));
                    dataTable.Columns.Add("Estado", typeof(string));

                    foreach (var dep in lista)
                    {
                        DataRow row = dataTable.NewRow();
                        row["ID"] = dep.id_depa;
                        row["Direccion"] = dep.direccion;
                        row["Descripcion"] = dep.descripcion;
                        row["Precio"] = dep.precio;
                        row["Latitud"] = dep.latitud;
                        row["Longitud"] = dep.longitud;
                        row["Capacidad"] = dep.cap_personas;
                        row["Comuna"] = dep.nom_comuna;
                        row["Estado"] = dep.desc_estado;
                        dataTable.Rows.Add(row);
                    }
                }
            }
            catch (Exception ex)
            {
                // Manejo de excepciones o registro de errores
                throw ex;
            }
            finally
            {
                // Asegúrate de cerrar el cliente para liberar recursos
                if (client != null)
                {
                    client.Close();
                }
            }

            return dataTable;
        }

        public bool AgregarDepartamento(string direccion, string descripcion, int precio, float latitud, float longitud, int capacidadPersona, int cantidadImagenes, int idComuna, int idEstado)
        {
            bool ward = false;
            WSPortafolioClient client = null;

            try
            {
                client = new WSPortafolioClient();
                ward = client.agregarDepartamento(direccion, descripcion, precio, latitud, longitud, capacidadPersona, cantidadImagenes, idComuna, idEstado);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al agregar departamento: " + ex.Message);
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

        public bool ModificarDepartamento(int id_departamento, string direccion, string descripcion, int precio, float latitud, float longitud, int capacidadPersona, int cantidadImagenes, int idComuna, int idEstado)
        {
            try
            {
                WSPortafolioClient client = new WSPortafolioClient();
                bool resultado = client.modificarDepartamento(id_departamento, direccion, descripcion, precio, latitud, longitud, capacidadPersona, cantidadImagenes, idComuna, idEstado);
                client.Close();
                return resultado;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al modificar departamento a través del servicio web: " + ex.Message);
                return false;
            }
        }

        public bool EliminarDepartamento(int id_departamento)
        {
            try
            {
                WSPortafolioClient client = new WSPortafolioClient();
                bool resultado = client.eliminarDepartamento(id_departamento);
                client.Close();
                return resultado;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al eliminar departamento: " + ex.Message);
                return false;
            }
        }
        
        /*public DataTable ListarAdministradorPorRut(int rut)
        {
            WSPortafolioClient client = null;
            DataTable dataTable = new DataTable();

            try
            {
                client = new WSPortafolioClient();

                // Llamamos al método del servicio web para obtener una lista de todos los administradores
                administrador[] lista = client.listarAdministrador();

                // Crear un DataTable con las mismas columnas que en el método ListarAdministrador
                dataTable.Columns.Add("RUT", typeof(int));
                dataTable.Columns.Add("DV", typeof(string));
                dataTable.Columns.Add("Nombre", typeof(string));
                dataTable.Columns.Add("ApellidoPaterno", typeof(string));
                dataTable.Columns.Add("ApellidoMaterno", typeof(string));
                dataTable.Columns.Add("Correo", typeof(string));
                dataTable.Columns.Add("Usuario", typeof(string));
                dataTable.Columns.Add("Contrasena", typeof(string));
                dataTable.Columns.Add("Telefono", typeof(string));

                // Filtrar los administradores por el RUT
                foreach (var adm in lista)
                {
                    if (adm.rut == rut)
                    {
                        DataRow row = dataTable.NewRow();
                        row["RUT"] = adm.rut;
                        row["DV"] = adm.dv;
                        row["Nombre"] = adm.nombre;
                        row["ApellidoPaterno"] = adm.apellido_paterno;
                        row["ApellidoMaterno"] = adm.apellido_materno;
                        row["Correo"] = adm.correo;
                        row["Usuario"] = adm.usuario;
                        row["Contrasena"] = adm.contrasena;
                        row["Telefono"] = adm.telefono;
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
        }*/


    }
}









