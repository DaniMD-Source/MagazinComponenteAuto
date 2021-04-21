using MagazinComponenteAuto.Models;
using MagazinComponenteAuto.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MagazinComponenteAuto.Controllers
{
    public class ProductsController : Controller
    {
        private ProductsRepository productRepository = new ProductsRepository();
        // GET: Products
        public ActionResult Index()
        {
            List<ProductsModels> productsModels = productRepository.GetAllProducts();
            return View("Index", productsModels);
        }

        // GET: Products/Details/5
        public ActionResult Details(int id)
        {
            ProductsModels productDetails = productRepository.GetProductById(id);
            return View("ProductDetails", productDetails);
        }

        // GET: Products/Create
        public ActionResult Create()
        {
            return View("CreateProduct");
        }

        // POST: Products/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                ProductsModels productModel = new ProductsModels();
                UpdateModel(productModel);

                productRepository.InsertProduct(productModel);

                return RedirectToAction("Index");
            }
            catch
            {
                return View("CreateProduct");
            }
        }

        // GET: Products/Edit/5
        public ActionResult Edit(int id)
        {
            ProductsModels product = productRepository.GetProductById(id);
            return View("EditProduct", product);
        }

        // POST: Products/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                ProductsModels productModels = new ProductsModels();
                UpdateModel(productModels);

                productRepository.UpdateProduct(productModels);

                return RedirectToAction("Index");
            }
            catch
            {
                return View("EditProduct");
            }
        }

        // GET: Products/Delete/5
        public ActionResult Delete(int id)
        {
            ProductsModels product = productRepository.GetProductById(id);
            return View("DeleteProduct", product);
        }

        // POST: Products/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                productRepository.DeleteProduct(id);

                return RedirectToAction("Index");
            }
            catch
            {
                return View("DeleteProduct");
            }
        }
    }
}
