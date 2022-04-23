using Entidades;
using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace UIWebMVC.Controllers
{
    public class CustomerController : Controller
    {
        CN_Customer cn_Customer = new CN_Customer();
        // GET: Customer
        public ActionResult Index()
        {
            return View(cn_Customer.SelectCustomer());
        }

        // GET: Customer/Details/5
        public ActionResult Details(int id)
        {
            return View(cn_Customer.SelectCustomerByIdCustomer(id));
        }

        // GET: Customer/Create
        public ActionResult Create()
        {
            Customer customer = new Customer();
            return View(customer);
        }

        // POST: Customer/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here
                string mensaje = string.Empty;

                Customer customer = new Customer();
                customer.Names = collection["Names"];
                customer.LastName = collection["LastName"];
                customer.DNI = collection["DNI"];
                customer.Email = collection["Email"];

                cn_Customer.InsertCustomer(customer, out mensaje);

                if(!string.IsNullOrEmpty(mensaje))
                {
                    ViewBag.Mensaje = mensaje;
                    return View(customer);
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Customer/Edit/5
        public ActionResult Edit(int id)
        {
            return View(cn_Customer.SelectCustomerByIdCustomer(id));
        }

        // POST: Customer/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here
                string mensaje = string.Empty;

                Customer customer = new Customer();
                customer.IdCustomer = Convert.ToInt32(collection["IdCustomer"]);
                customer.Names = collection["Names"];
                customer.LastName = collection["LastName"];
                customer.DNI = collection["DNI"];
                customer.Email = collection["Email"];

                cn_Customer.UpdateCustomer(customer, out mensaje);

                if (!string.IsNullOrEmpty(mensaje))
                {
                    ViewBag.Mensaje = mensaje;
                    return View(customer);
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Customer/Delete/5
        public ActionResult Delete(int id)
        {
            return View(cn_Customer.SelectCustomerByIdCustomer(id));
        }

        // POST: Customer/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                cn_Customer.DeleteCustomer(id);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
