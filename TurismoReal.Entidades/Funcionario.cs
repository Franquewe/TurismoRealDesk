using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TurismoReal.Entidades
{
    public class Funcionario
    {
        public int rut { get; set; }
        public string dv { get; set; }
        public string nombre { get; set; }
        public string apellido_paterno { get; set; }
        public string apellido_materno { get; set; }
        public string correo { get; set; }
        public string usuario { get; set; }
        public string contrasena { get; set; }
        public string telefono { get; set; }

        public Funcionario()
        {

        }
    }

}
