using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Customer
    {
        //[IdCustomer], [Names], [LastName], [DNI], [Email]
        public int IdCustomer { get; set; }
        public string Names { get; set; }
        public string LastName { get; set; }
        public string DNI { get; set; }
        public string Email { get; set; }

    }
}
