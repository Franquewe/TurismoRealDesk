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
    public class NArticulo
    {
        public static DataTable Listar()
        {
             DDArticulo Datos = new DDArticulo();

            try
            {
                return Datos.ListarArticulo();
            }
            catch (Exception ex)
            {
                // Puedes manejar la excepción, registrar el error o mostrar un mensaje de error si es necesario
                return null; // Puedes devolver un DataTable vacío o null en caso de error
            }
        }

        public static bool Insertar(string descripcion,int stock,int precio)
        {
            // Llamar al método de la capa de datos para agregar el administrador
            DDArticulo Datos = new DDArticulo();
            bool exito = Datos.AgregarArticulo(descripcion,stock,precio);

            // Devolver un mensaje de éxito o error
            return exito;
        }

        public static bool ModificarArticulo(int id_art, string descripcion, int stock, int precio)
        {
            DDArticulo Datos = new DDArticulo();

            // Llama al método de la capa de datos para actualizar el artículo
            bool exito = Datos.modificarArticulo(id_art, descripcion, stock, precio);

            // Devuelve un mensaje de éxito o error
            return exito;
        }

        public static bool EliminarArticulo(int rut)
        {
            // Llamar al método de la capa de datos para eliminar el administrador
            DDArticulo Datos = new DDArticulo();
            bool exito = Datos.EliminarArticulo(rut);

            // Devolver un mensaje de éxito o error
            return exito;
        }
    }
}
