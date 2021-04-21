using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MagazinComponenteAuto.Controllers
{
    public class ShoppingCartController : Controller
    {
        private ShoppingCartRepository shoppingCartRepository = new ShoppingCartRepository();
        // GET: ShoppingCart
        public ActionResult Index()
        {
            List<ShoppingCartModels> shoppingCartModels = shoppingCartRepository.GetAllShoppingCart();
            return View("Index", shoppingCartModels);
        }

        // GET: ShoppingCart/Details/5
        public ActionResult Details(int id)
        {
            ShoppingCartModels shoppingCartDetails = shoppingCartRepository.GetShoppingCartByID(id);
            return View("ShoppingCartDetails", shoppingCartDetails);
        }

        // GET: ShoppingCart/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ShoppingCart/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: ShoppingCart/Edit/5
        public ActionResult Edit(int id)
        {
            ShoppingCartModels shoppingCart = shoppingCartRepository.GetShoppingCartByID(id);
            return View("EditShoppingCart", shoppingCart);
        }

        // POST: ShoppingCart/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                ShoppingCartModels shoppingCartModels = new ShoppingCartModels();
                UpdateModel(shoppingCartModels);

                return RedirectToAction("Index");
            }
            catch
            {
                return View("EditShoppingCart");
            }
        }

        // GET: ShoppingCart/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ShoppingCart/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
