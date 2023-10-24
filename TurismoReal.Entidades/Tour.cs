using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TurismoReal.Entidades
{
    public class Tour
    {
        public int id_servicio { get; set; }
        public string nombre_servicio { get; set; }
        public string descripcion { get; set; }
        public string destino { get; set; }
        public int tarifa_adicional { get; set; }
    }
}
