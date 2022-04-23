using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Coneccion
    {
        private readonly static string cadena = "Data Source=.;Initial Catalog=Customers;Integrated Security=True";
        public static string Cadena()
        {
            return cadena;
        }
    }
}
