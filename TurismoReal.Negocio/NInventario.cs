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
    public class NInventario
    {
        public static DataTable Listar()
        {
            DDInventario Datos = new DDInventario();

            try
            {
                return Datos.ListarInventario();
            }
            catch (Exception ex)
            {
                // Puedes manejar la excepción, registrar el error o mostrar un mensaje de error si es necesario
                return null; // Puedes devolver un DataTable vacío o null en caso de error
            }
        }

        public static bool AgregarInventario(int idArticulo, int idDepartamento, int cantidad)
        {
            try
            {
                DDInventario datosInventario = new DDInventario(); // Suponiendo que tienes una clase de acceso a datos DInventario

                // Aquí podrías realizar validaciones adicionales si es necesario antes de agregar el inventario

                return datosInventario.AgregarInventario(idArticulo, idDepartamento, cantidad);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error en capa de negocios al agregar inventario: " + ex.Message);
                return false; // Indica que la operación no se realizó con éxito
            }
        }

        public static bool ModificarInventario(Inventario inv)
        {
            try
            {
                DDInventario datosInventario = new DDInventario();

                // Llama al método de la capa de datos para modificar el inventario
                return datosInventario.ModificarInventario(inv);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error en capa de negocios al modificar inventario: " + ex.Message);
                return false;
            }
        }

        public static bool EliminarInventario(int id_depa, int id_art)
        {
            try
            {
                DDInventario datosInventario = new DDInventario();

                // Llama al método de la capa de datos para eliminar el inventario
                return datosInventario.EliminarInventario(id_depa, id_art);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error en capa de negocios al eliminar inventario: " + ex.Message);
                return false;
            }
        }

    }
}
