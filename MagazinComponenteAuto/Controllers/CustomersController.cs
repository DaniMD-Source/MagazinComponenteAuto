using MagazinComponenteAuto.Models;
using MagazinComponenteAuto.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MagazinComponenteAuto.Controllers
{
    public class CustomersController : Controller
    {
        private CustomersRepository customersRepository = new CustomersRepository();
        // GET: Customers
        public ActionResult Index()
        {
            List<CustomersModels> customersModels = customersRepository.GetAllCustomers();
            return View("Index", customersModels);
        }

        // GET: Customers/Details/5
        public ActionResult Details(Guid id)
        {
            CustomersModels customerDetails = customersRepository.GetCustomersByID(id);
            return View("CustomerDetails", customerDetails);
        }

        // GET: Customers/Create
        public ActionResult Create()
        {
            return View("CreateCustomer");
        }

        // POST: Customers/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                CustomersModels customersModels = new CustomersModels();
                UpdateModel(customersModels);

                customersRepository.InsertCustomer(customersModels);

                return RedirectToAction("Index");
            }
            catch
            {
                return View("CreateCustomer");
            }
        }

        // GET: Customers/Edit/5
        public ActionResult Edit(Guid id)
        {
            CustomersModels customer = customersRepository.GetCustomersByID(id);
            return View("EditCustomer", customer);
        }

        // POST: Customers/Edit/5
        [HttpPost]
        public ActionResult Edit(Guid id, FormCollection collection)
        {
            try
            {
                CustomersModels customerModels = new CustomersModels();
                UpdateModel(customerModels);

                customersRepository.UpdateCustomer(customerModels);

                return RedirectToAction("Index");
            }
            catch
            {
                return View("EditCustomer");
            }
        }

        // GET: Customers/Delete/5
        public ActionResult Delete(Guid id)
        {
            CustomersModels customer = customersRepository.GetCustomersByID(id);
            return View("DeleteCustomer", customer);
        }

        // POST: Customers/Delete/5
        [HttpPost]
        public ActionResult Delete(Guid id, FormCollection collection)
        {
            try
            {
                customersRepository.DeleteCustomer(id);

                return RedirectToAction("Index");
            }
            catch
            {
                return View("DeleteCustomer");
            }
        }
    }
}
