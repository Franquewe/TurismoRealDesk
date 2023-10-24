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
    public class NTour
    {
        public static List<Tour> ListarTours()
        {
            DDTour datosTour = new DDTour();

            try
            {
                DataTable dataTable = datosTour.ListarTours();

                if (dataTable != null && dataTable.Rows.Count > 0)
                {
                    List<Tour> tours = new List<Tour>();

                    foreach (DataRow row in dataTable.Rows)
                    {
                        Tour tour = new Tour
                        {
                            id_servicio = Convert.ToInt32(row["IdTour"]),
                            nombre_servicio = row["NombreTour"].ToString(),
                            descripcion = row["Descripcion"].ToString(),
                            destino = row["Destino"].ToString(),
                            tarifa_adicional = Convert.ToInt32(row["TarifaAdicional"])
                        };

                        tours.Add(tour);
                    }

                    return tours;
                }
                else
                {
                    return new List<Tour>();
                }
            }
            catch (Exception ex)
            {
                // Puedes manejar la excepción, registrar el error o mostrar un mensaje de error si es necesario
                return null; // Puedes devolver una lista vacía o null en caso de error
            }
        }

        public static DataTable ListarToursDataTable()
        {
            DDTour datosTour = new DDTour();

            try
            {
                return datosTour.ListarTours();
            }
            catch (Exception ex)
            {
                // Puedes manejar la excepción, registrar el error o mostrar un mensaje de error si es necesario
                return null; // Puedes devolver un DataTable vacío o null en caso de error
            }
        }


    }
}
