using Datos;
using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class CN_Customer
    {
        CD_Customer cd_Customer = new CD_Customer();

        public Customer SelectCustomerByIdCustomer(int idCustomer)
        {
            return cd_Customer.SelectCustomerByIdCustomer(idCustomer);
        }

        public List<Customer> SelectCustomer()
        {
            return cd_Customer.SelectCustomer();
        }

        public int InsertCustomer(Customer customer, out string mensaje)
        {
            mensaje = String.Empty;
            if (string.IsNullOrEmpty(customer.Names) || string.IsNullOrWhiteSpace(customer.Names))
                mensaje = "El nombre no puede ser vacio";
            else if(string.IsNullOrEmpty(customer.LastName) || string.IsNullOrWhiteSpace(customer.LastName))
                mensaje = "Los apellidos no pueden ser vacios";
            else if (string.IsNullOrEmpty(customer.DNI) || string.IsNullOrWhiteSpace(customer.DNI))
                mensaje = "El DNI no puede ser vacio";
            else if (string.IsNullOrEmpty(customer.Email) || string.IsNullOrWhiteSpace(customer.Email))
                mensaje = "El Email no puede ser vacio";

            if (string.IsNullOrEmpty(mensaje))
                return cd_Customer.InsertCustomer(customer, out mensaje);
            else
                return 0;
        }

        public int UpdateCustomer(Customer customer, out string mensaje)
        {
            mensaje = String.Empty;
            if (string.IsNullOrEmpty(customer.Names) || string.IsNullOrWhiteSpace(customer.Names))
                mensaje = "El nombre no puede ser vacio";
            else if (string.IsNullOrEmpty(customer.LastName) || string.IsNullOrWhiteSpace(customer.LastName))
                mensaje = "Los apellidos no pueden ser vacios";
            else if (string.IsNullOrEmpty(customer.DNI) || string.IsNullOrWhiteSpace(customer.DNI))
                mensaje = "El DNI no puede ser vacio";
            else if (string.IsNullOrEmpty(customer.Email) || string.IsNullOrWhiteSpace(customer.Email))
                mensaje = "El Email no puede ser vacio";

            if (string.IsNullOrEmpty(mensaje))
                return cd_Customer.UpdateCustomer(customer, out mensaje);
            else
                return 0;
        }

        public int DeleteCustomer(int idCustomer)
        {
            return cd_Customer.DeleteCustomer(idCustomer);
        }
    }
}
