using Entidades;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace Datos
{
    public class CD_Customer
    {
        public Customer SelectCustomerByIdCustomer(int idCustomer)
        {
            Customer customer = new Customer();
            try
            {
                using (SqlConnection cn = new SqlConnection(Coneccion.Cadena()))
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = cn;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "sp_SelectCustomerByIdCustomer";
                    cmd.Parameters.AddWithValue("IdCustomer", idCustomer);
                    cn.Open();
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            customer.IdCustomer = Convert.ToInt32(dr["IdCustomer"]);
                            customer.Names = dr["Names"].ToString();
                            customer.LastName = dr["LastName"].ToString();
                            customer.DNI = dr["DNI"].ToString();
                            customer.Email = dr["Email"].ToString();
                        }
                    }
                }
                return customer;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public List<Customer> SelectCustomer()
        {
            List<Customer> customers = new List<Customer>();
            try
            {
                using (SqlConnection cn = new SqlConnection(Coneccion.Cadena()))
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = cn;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "sp_SelectCustomer";
                    cn.Open();
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            Customer customer = new Customer();
                            customer.IdCustomer = Convert.ToInt32(dr["IdCustomer"]);
                            customer.Names = dr["Names"].ToString();
                            customer.LastName = dr["LastName"].ToString();
                            customer.DNI = dr["DNI"].ToString();
                            customer.Email = dr["Email"].ToString();
                            customers.Add(customer);
                        }
                    }
                }
                return customers;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public int InsertCustomer(Customer customer, out string mensaje)
        {
            int resultado = 0;
            mensaje= string.Empty;
            try
            {
                using (SqlConnection cn = new SqlConnection(Coneccion.Cadena()))
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.CommandText = "sp_InsertCustomer";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Connection = cn;
                    cmd.Parameters.AddWithValue("Names", customer.Names);
                    cmd.Parameters.AddWithValue("LastName", customer.LastName);
                    cmd.Parameters.AddWithValue("DNI", customer.DNI);
                    cmd.Parameters.AddWithValue("Email", customer.Email);
                    cmd.Parameters.Add("Resultado", SqlDbType.Int).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("Mensaje", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;
                    cn.Open();
                    cmd.ExecuteNonQuery();
                    resultado = Convert.ToInt32(cmd.Parameters["Resultado"].Value);
                    mensaje = cmd.Parameters["Mensaje"].Value.ToString();
                }
                return resultado;
            }
            catch (Exception)
            {
                return resultado;
            }
        }

        public int UpdateCustomer(Customer customer, out string mensaje)
        {
            int resultado = 0;
            mensaje = string.Empty;
            try
            {
                using (SqlConnection cn = new SqlConnection(Coneccion.Cadena()))
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.CommandText = "sp_UpdateCustomer";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Connection = cn;
                    cmd.Parameters.AddWithValue("IdCustomer", customer.IdCustomer);
                    cmd.Parameters.AddWithValue("Names", customer.Names);
                    cmd.Parameters.AddWithValue("LastName", customer.LastName);
                    cmd.Parameters.AddWithValue("DNI", customer.DNI);
                    cmd.Parameters.AddWithValue("Email", customer.Email);
                    cmd.Parameters.Add("Resultado", SqlDbType.Int).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("Mensaje", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;
                    cn.Open();
                    cmd.ExecuteNonQuery();
                    resultado = Convert.ToInt32(cmd.Parameters["Resultado"].Value);
                    mensaje = cmd.Parameters["Mensaje"].Value.ToString();
                }
                return resultado;
            }
            catch (Exception)
            {
                return resultado;
            }
        }

        public int DeleteCustomer(int idCustomer)
        {
            int resultado = 0;
            try
            {
                using (SqlConnection cn = new SqlConnection(Coneccion.Cadena()))
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.CommandText = "sp_DeleteCustomer";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Connection = cn;
                    cmd.Parameters.AddWithValue("IdCustomer", idCustomer);
                    cmd.Parameters.Add("Resultado", SqlDbType.Int).Direction = ParameterDirection.Output;
                    cn.Open();
                    cmd.ExecuteNonQuery();
                    resultado = Convert.ToInt32(cmd.Parameters["Resultado"].Value);
                }
                return resultado;
            }
            catch (Exception)
            {
                return resultado;
            }
        }
    }
}
