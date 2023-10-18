using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using TurismoReal.Datos;

namespace TurismoReal.Negocio
{
    public class NFuncionario
    {
        public static DataTable Listar()
        {
            DDFuncionario Datos = new DDFuncionario();

            try
            {
                return Datos.ListarFuncionario();
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
            DDFuncionario Datos = new DDFuncionario();
            bool exito = Datos.AgregarFuncionario(rut, dv, nombre, apellido_paterno, apellido_materno, correo, usuario, contrasena, telefono);

            // Devolver un mensaje de éxito o error
            return exito;
        }

        public static bool ModificarFuncionario(int rut, string dv, string nombre, string apellido_paterno, string apellido_materno,
                                           string correo, string usuario, string contrasena, string telefono)
        {
            DDFuncionario Datos = new DDFuncionario();

            // Llama al método de la capa de datos para actualizar el administrador
            bool exito = Datos.modificarFuncionario(rut, dv, nombre, apellido_paterno, apellido_materno, correo, usuario, contrasena, telefono);

            // Devuelve un mensaje de éxito o error
            return exito;
        }

        public static bool EliminarFuncionario(int rut)
        {
            // Llamar al método de la capa de datos para eliminar el administrador
            DDFuncionario Datos = new DDFuncionario();
            bool exito = Datos.EliminarFuncionario(rut);

            // Devolver un mensaje de éxito o error
            return exito;
        }
    }
}
