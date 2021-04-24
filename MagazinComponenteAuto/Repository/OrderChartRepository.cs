using MagazinComponenteAuto.Models;
using MagazinComponenteAuto.Models.DBObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MagazinComponenteAuto.Repository
{
    public class OrderChartRepository
    {
        private MagazinComponenteAutoDataContext dbContext;

        public OrderChartRepository()
        {
            dbContext = new MagazinComponenteAutoDataContext();
        }
        public OrderChartRepository(MagazinComponenteAutoDataContext _dbContext)
        {
            dbContext = _dbContext;
        }

        private OrderChartModels MapDbObjectsToModel(OrderChart dbOrderChart)
        {
            OrderChartModels OrderChartModels = new OrderChartModels();
            if (dbOrderChart != null)
            {
                OrderChartModels.OrderChartID = dbOrderChart.OrderChartID;
                OrderChartModels.ShoppingCartID = dbOrderChart.ShoppingCartID;
                OrderChartModels.Date = dbOrderChart.Date;
                OrderChartModels.ClientID = dbOrderChart.ClientID;
                OrderChartModels.TotalPrice = dbOrderChart.TotalPrice;
                OrderChartModels.DeliveryAdress = dbOrderChart.DeliveryAdress;
                return OrderChartModels;
            }
            return null;
        }
        public void InsertOrderChart(OrderChartModels orderChartModels)
        {
            dbContext.OrderCharts.InsertOnSubmit(MapModelToDbObject(orderChartModels));
            dbContext.SubmitChanges();
        }

        private OrderChart MapModelToDbObject(OrderChartModels orderchart)
        {
            OrderChart dbOrderChart = new OrderChart();
            if (orderchart != null)
            {
                dbOrderChart.OrderChartID = orderchart.OrderChartID;
                dbOrderChart.ShoppingCartID = orderchart.ShoppingCartID;
                dbOrderChart.Date = orderchart.Date;
                dbOrderChart.ClientID = orderchart.ClientID;
                dbOrderChart.TotalPrice = orderchart.TotalPrice;
                dbOrderChart.DeliveryAdress = orderchart.DeliveryAdress;
                return dbOrderChart;
            }
            return null;
        }
        public void UpdateOrderChart(OrderChartModels orderchart)
        {
            OrderChart dbOrderChart = dbContext.OrderCharts.FirstOrDefault(x => x.OrderChartID == orderchart.OrderChartID);
            if (dbOrderChart != null)
            {
                dbOrderChart.OrderChartID = orderchart.OrderChartID;
                dbOrderChart.ShoppingCartID = orderchart.ShoppingCartID;
                dbOrderChart.Date = orderchart.Date;
                dbOrderChart.ClientID = orderchart.ClientID;
                dbOrderChart.TotalPrice = orderchart.TotalPrice;
                dbOrderChart.DeliveryAdress = orderchart.DeliveryAdress;
                dbContext.SubmitChanges();
            }
        }
        public void DeleteOrderChart(int id)
        {
            OrderChart dbOrderChart = dbContext.OrderCharts.FirstOrDefault(x => x.OrderChartID == id);
            if (dbOrderChart != null)
            {
                dbContext.OrderCharts.DeleteOnSubmit(dbOrderChart);
                dbContext.SubmitChanges();
            }
        }
        public int LastOrder()
        {
            OrderChart orderChart = dbContext.OrderCharts.OrderByDescending(x => x.OrderChartID).FirstOrDefault();
            if (orderChart != null)
            {
                return MapDbObjectsToModel(orderChart).OrderChartID+1;
            }
            return 1;       
        }
        public OrderChartModels GetOrderChartByID(int ID)
        {
            var orderChart = dbContext.OrderCharts.FirstOrDefault(x => x.OrderChartID == ID);

            return MapDbObjectsToModel(orderChart);
        }
        public List<OrderChartModels> GetAllShoppingCart()
        {
            List<OrderChartModels> orderChartList = new List<OrderChartModels>();
            foreach (OrderChart dbOrderChart in dbContext.OrderCharts)
            {
                orderChartList.Add(MapDbObjectsToModel(dbOrderChart));
            }
            return orderChartList;
        }
    }
}