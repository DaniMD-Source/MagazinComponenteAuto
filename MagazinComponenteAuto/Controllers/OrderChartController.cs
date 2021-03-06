using MagazinComponenteAuto.Models;
using MagazinComponenteAuto.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MagazinComponenteAuto.Controllers
{
    public class OrderChartController : Controller
    {
        private OrderChartRepository orderChartRepository = new OrderChartRepository();
        private ShoppingCartRepository shoppingCartRepository = new ShoppingCartRepository();
        // GET: OrderChart
        public ActionResult Index()
        {
            return View();
        }

        // GET: OrderChart/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: OrderChart/Create
        public ActionResult Create()
        {
            return View("CreateOrderChart");
        }

        // POST: OrderChart/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                OrderChartModels orderchartModel = new OrderChartModels();
                UpdateModel(orderchartModel);
                orderchartModel.Date = DateTime.UtcNow;
                orderchartModel.TotalPrice = shoppingCartRepository.TotalPrice();
                orderchartModel.ShoppingCartID = shoppingCartRepository.LastShoppingCartOrderID();
                orderchartModel.ClientID = new Guid();
                orderChartRepository.InsertOrderChart(orderchartModel);

                return RedirectToAction("Index");
            }
            catch
            {
                return View("CreateOrderChart");
            }
        }

        // GET: OrderChart/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: OrderChart/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: OrderChart/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: OrderChart/Delete/5
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
