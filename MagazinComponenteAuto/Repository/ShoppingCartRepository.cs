using MagazinComponenteAuto.Models;
using MagazinComponenteAuto.Models.DBObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MagazinComponenteAuto.Repository
{
    public class ShoppingCartRepository
    {
        private MagazinComponenteAutoDataContext dbContext;

        public ShoppingCartRepository()
        {
            dbContext = new MagazinComponenteAutoDataContext();
        }
        public ShoppingCartRepository(MagazinComponenteAutoDataContext _dbContext)
        {
            dbContext = _dbContext;
        }

        private ShoppingCartModels MapDbObjectsToModel(ShoppingCart dbShoppingCart)
        {
            ShoppingCartModels shoppingCartModels = new ShoppingCartModels();
            if (dbShoppingCart != null)
            {
                shoppingCartModels.ShoppingCartID = dbShoppingCart.ShoppingCartID;
                shoppingCartModels.OrderID = dbShoppingCart.OrderID;
                shoppingCartModels.ProductCodeID = dbShoppingCart.ProductCodeID;
                shoppingCartModels.Quantity = dbShoppingCart.Quantity;
                shoppingCartModels.Price = dbShoppingCart.Price;
                return shoppingCartModels;
            }
            return null;
        }
        public void InsertShoppingCart(ShoppingCartModels shoppingcart)
        {
            dbContext.ShoppingCarts.InsertOnSubmit(MapModelToDbObject(shoppingcart));
            dbContext.SubmitChanges();
        }

        private ShoppingCart MapModelToDbObject(ShoppingCartModels shoppingcart)
        {
            ShoppingCart dbShoppingCart = new ShoppingCart();
            if (shoppingcart != null)
            {
                dbShoppingCart.ShoppingCartID = shoppingcart.ShoppingCartID;
                dbShoppingCart.OrderID = shoppingcart.OrderID;
                dbShoppingCart.ProductCodeID = shoppingcart.ProductCodeID;
                dbShoppingCart.Quantity = shoppingcart.Quantity;
                dbShoppingCart.Price = shoppingcart.Price;
                return dbShoppingCart;
            }
            return null;
        }
        public void UpdateShoppingCart(ShoppingCartModels shoppingcart)
        {
            ShoppingCart dbShoppingCart = dbContext.ShoppingCarts.FirstOrDefault(x => x.ShoppingCartID == shoppingcart.ShoppingCartID);
            if (dbShoppingCart != null)
            {
                dbShoppingCart.ShoppingCartID = shoppingcart.ShoppingCartID;
                dbShoppingCart.OrderID = shoppingcart.OrderID;
                dbShoppingCart.ProductCodeID = shoppingcart.ProductCodeID;
                dbShoppingCart.Quantity = shoppingcart.Quantity;
                dbShoppingCart.Price = shoppingcart.Price;
                dbContext.SubmitChanges();
            }
        }
        public void DeleteShoppingCart(int id)
        {
            ShoppingCart dbShoppingCart = dbContext.ShoppingCarts.FirstOrDefault(x => x.ShoppingCartID == id);
            if (dbShoppingCart != null)
            {
                dbContext.ShoppingCarts.DeleteOnSubmit(dbShoppingCart);
                dbContext.SubmitChanges();
            }
        }
        public ShoppingCartModels GetShoppingCartByID(int ID)
        {
            var shoppingCart = dbContext.ShoppingCarts.FirstOrDefault(x => x.ShoppingCartID == ID);

            return MapDbObjectsToModel(shoppingCart);
        }
        public List<ShoppingCartModels> GetAllShoppingCart()
        {
            List<ShoppingCartModels> shoppingCartList = new List<ShoppingCartModels>();
            foreach (ShoppingCart dbShoppingCart in dbContext.ShoppingCarts)
            {
                shoppingCartList.Add(MapDbObjectsToModel(dbShoppingCart));
            }
            return shoppingCartList;
        }
        public decimal TotalPrice()
        {
            decimal total = 0;
            foreach (var item in dbContext.ShoppingCarts.Where(x => x.OrderID == LastShoppingCartOrderID()))
                {
                total = total + item.Price;
                }
            return total;
        }

        public int LastShoppingCartOrderID()
        {
            ShoppingCart shoppingCart = dbContext.ShoppingCarts.OrderByDescending(x => x.ShoppingCartID).FirstOrDefault();
            return shoppingCart.OrderID;
        }
        
    }
}