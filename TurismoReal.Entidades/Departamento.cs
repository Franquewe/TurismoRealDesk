using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TurismoReal.Entidades
{
    public class Departamento
    {
        public int id_departamento { get; set; }
        public string direccion { get; set; }
        public string descripcion { get; set; }
        public int precio { get; set; }
        public float latitud { get; set; }
        public float longitud { get; set; }
        public int capacidad_persona { get; set; }
        public int cantidad_img { get; set; }
        public int comuna_id_comuna { get; set; }
        public int estado_id_estado { get; set; }
    }
}
