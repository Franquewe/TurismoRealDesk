using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TurismoReal.Entidades
{
    internal class Login
    {
        public int Rut {  get; set; }
        public String Usuario { get; set; }
        public String Contrasena {  get; set; }
        public String tipoUsuario {  get; set; }

        public Login()
        {

        }
    }
}
