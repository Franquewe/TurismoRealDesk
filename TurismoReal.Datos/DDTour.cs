using System;
using System.Collections.Generic;
using System.Data;
using TurismoReal.Datos.WSportafolio;
using TurismoReal.Entidades;

namespace TurismoReal.Datos
{
    public class DDTour
    {
        public DataTable ListarTours()
        {
            WSPortafolioClient client = null;
            DataTable dataTable = new DataTable();

            try
            {
                client = new WSPortafolioClient();

                // Llamamos al método del servicio web para obtener una lista de tours
                tour[] listaTours = client.listarTour();

                // Verificar si hay registros antes de continuar
                if (listaTours != null && listaTours.Length > 0)
                {
                    // Configurar las columnas del DataTable
                    dataTable.Columns.Add("IdServicio", typeof(int));
                    dataTable.Columns.Add("NombreServicio", typeof(string));
                    dataTable.Columns.Add("Descripcion", typeof(string));
                    dataTable.Columns.Add("Destino", typeof(string));
                    dataTable.Columns.Add("TarifaAdicional", typeof(int));


                    // Agrega más propiedades según las columnas que hayas definido en tu entidad Tour.

                    foreach (var tour in listaTours)
                    {
                        // Crear una nueva fila en el DataTable
                        DataRow row = dataTable.NewRow();

                        // Asignar los valores del tour a las columnas correspondientes
                        row["IdServicio"] = tour.id_tour;
                        row["NombreServicio"] = tour.nombre_servicio;
                        row["Descripcion"] = tour.descripcion;
                        row["Destino"] = tour.destino;
                        row["TarifaAdicional"] = tour.tarifa_adicional;
                        // Agregar más propiedades según las columnas que hayas definido en tu entidad Tour.

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


    }
}
