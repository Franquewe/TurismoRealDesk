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
    public class NDepartamento
    {
        public DataTable Listar()
        {
            DDDepartamento Datos = new DDDepartamento();

            try
            {
                return Datos.Listar();
            }
            catch (Exception ex)
            {
                // Manejo de excepciones, registro de errores o mensajes de error
                return null;
            }
        }

        public static bool AgregarDepartamento(string direccion, string descripcion, int precio, float latitud, float longitud, int capacidadPersona, int cantidadImagenes, int idComuna, int idEstado)
        {
            DDDepartamento datos = new DDDepartamento();
            return datos.AgregarDepartamento(direccion, descripcion, precio, latitud, longitud, capacidadPersona, cantidadImagenes, idComuna, idEstado);
        }

        public static bool ModificarDepartamento(int id_departamento, string direccion, string descripcion, int precio, float latitud, float longitud, int capacidadPersona, int cantidadImagenes, int idComuna, int idEstado)
        {
            DDDepartamento datos = new DDDepartamento();
            return datos.ModificarDepartamento(id_departamento, direccion, descripcion, precio, latitud, longitud, capacidadPersona, cantidadImagenes, idComuna, idEstado);
        }

        public static bool EliminarDepartamento(int id_departamento)
        {
            DDDepartamento datos = new DDDepartamento();
            return datos.EliminarDepartamento(id_departamento);
        }



    }
}
