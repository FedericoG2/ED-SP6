using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ED_SP6
{
    internal class Nodo
    {
        public int NumeroCuenta { get; set; }
        public String Nombre { get; set; }
        public String Apellido { get; set; }
        public String DNI { get; set; }
        public Nodo Izquierdo { get; set; }
        public Nodo Derecho { get; set; }

        public Nodo()
        {
            NumeroCuenta = 0;
            Nombre = "";
            Apellido = "";
            DNI = "";
            Izquierdo = null;
            Derecho = null;
        }
    }
}
