using MagazinComponenteAuto.Models;
using MagazinComponenteAuto.Repository;
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
        private ProductsRepository productRepository = new ProductsRepository();
        private OrderChartRepository orderChartRepository = new OrderChartRepository();
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
            return View("DetailsShoppingCart", shoppingCartDetails);
        }

        // GET: ShoppingCart/Create
        public ActionResult Create()
        {
            return View("CreateShoppingCart");
        }

        // POST: ShoppingCart/Create
        [HttpPost]
        public ActionResult Create(int id, FormCollection collection)
        {
            try
            {
                ProductsModels productsModels = productRepository.GetProductById(id);
                ShoppingCartModels shoppingCartModel = new ShoppingCartModels();
                UpdateModel(shoppingCartModel);
                shoppingCartModel.OrderID = orderChartRepository.LastOrder();
                shoppingCartModel.ProductCodeID = productsModels.ProductCode;
                shoppingCartModel.Price = productsModels.Price*shoppingCartModel.Quantity;
                shoppingCartRepository.InsertShoppingCart(shoppingCartModel);

                return RedirectToAction("Index");
            }
            catch
            {
                return View("CreateShoppingCart");
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
                ShoppingCartModels shoppingCartModels = shoppingCartRepository.GetShoppingCartByID(id);
                UpdateModel(shoppingCartModels);
                shoppingCartModels.Price = shoppingCartModels.Quantity * productRepository.GetProductById(shoppingCartModels.ProductCodeID).Price;
                shoppingCartRepository.UpdateShoppingCart(shoppingCartModels);

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
            ShoppingCartModels shoppingCart = shoppingCartRepository.GetShoppingCartByID(id);
            return View("DeleteShoppingCart", shoppingCart);
        }

        // POST: ShoppingCart/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                shoppingCartRepository.DeleteShoppingCart(id);

                return RedirectToAction("Index");
            }
            catch
            {
                return View("DeleteShoppingCart");
            }
        }
    }
}
