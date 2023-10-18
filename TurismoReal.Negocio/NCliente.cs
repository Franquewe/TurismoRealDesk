using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using TurismoReal.Datos;

namespace TurismoReal.Negocio
{
    public class NCliente
    {
        public static DataTable Listar()
        {
            DDCliente Datos = new DDCliente();

            try
            {
                return Datos.ListarCliente();
            }
            catch (Exception ex)
            {
                // Puedes manejar la excepción, registrar el error o mostrar un mensaje de error si es necesario
                return null; // Puedes devolver un DataTable vacío o null en caso de error
            }
        }

        public static bool Insertar(int rut, string dv, string nombre, string apellido_paterno, string apellido_materno, string correo,
                              string usuario, string contrasena, string telefono)
        {
            // Llamar al método de la capa de datos para agregar el administrador
            DDCliente Datos = new DDCliente();
            bool exito = Datos.AgregarCliente(rut, dv, nombre, apellido_paterno, apellido_materno, correo, usuario, contrasena, telefono);

            // Devolver un mensaje de éxito o error
            return exito;
        }

        public static bool ModificarCliente(int rut, string dv, string nombre, string apellido_paterno, string apellido_materno,
                                           string correo, string usuario, string contrasena, string telefono)
        {
            DDCliente Datos = new DDCliente();

            // Llama al método de la capa de datos para actualizar el administrador
            bool exito = Datos.modificarCliente(rut, dv, nombre, apellido_paterno, apellido_materno, correo, usuario, contrasena, telefono);

            // Devuelve un mensaje de éxito o error
            return exito;
        }

        public static bool EliminarCliente(int rut)
        {
            // Llamar al método de la capa de datos para eliminar el administrador
            DDCliente Datos = new DDCliente();
            bool exito = Datos.EliminarCliente(rut);

            // Devolver un mensaje de éxito o error
            return exito;
        }
    }
}
