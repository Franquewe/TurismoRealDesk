using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using TurismoReal.Datos;
using TurismoReal.Entidades;

namespace TurismoReal.Negocio
{
    public class NAdministrador
    {
        public static DataTable Listar()
        {
            DDAdministrador Datos = new DDAdministrador();

            try
            {
                return Datos.ListarAdministrador();
            }
            catch (Exception ex)
            {
                // Puedes manejar la excepción, registrar el error o mostrar un mensaje de error si es necesario
                return null; // Puedes devolver un DataTable vacío o null en caso de error
            }
        }

        /*public static DataTable Buscar(string valor)
        {

        }*/

        public static bool Insertar(int rut, string dv, string nombre, string apellido_paterno, string apellido_materno, string correo,
                              string usuario, string contrasena, string telefono)
        {
            // Llamar al método de la capa de datos para agregar el administrador
            DDAdministrador Datos = new DDAdministrador();
            bool exito = Datos.AgregarAdministrador(rut, dv, nombre, apellido_paterno, apellido_materno, correo, usuario, contrasena, telefono);

            // Devolver un mensaje de éxito o error
            return exito;
        }

        public static bool ModificarAdministrador(int rut, string dv, string nombre, string apellido_paterno, string apellido_materno,
                                           string correo, string usuario, string contrasena, string telefono)
        {
            DDAdministrador Datos = new DDAdministrador();

            // Llama al método de la capa de datos para actualizar el administrador
            bool exito = Datos.modificarAdministrador(rut, dv, nombre, apellido_paterno, apellido_materno, correo, usuario, contrasena, telefono);

            // Devuelve un mensaje de éxito o error
            return exito;
        }

        public static bool EliminarAdministrador(int rut)
        {
            // Llamar al método de la capa de datos para eliminar el administrador
            DDAdministrador Datos = new DDAdministrador();
            bool exito = Datos.EliminarAdministrador(rut);

            // Devolver un mensaje de éxito o error
            return exito;
        }

        private DDAdministrador datosAdministrador = new DDAdministrador();

        public Administrador BuscarAdministradorPorRut(int rut)
        {
            try
            {
                return datosAdministrador.BuscarAdministradorPorRut(rut);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error en capa de negocios al buscar administrador por RUT: " + ex.Message);
                return null;
            }
        }

        /*public DataTable ListarPorRut(int rut)
        {
            try
            {
                return datosAdministrador.ListarAdministrador(rut);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error en capa de negocios al listar administradores: " + ex.Message);
                return null;
            }
        }*/





    }
}

