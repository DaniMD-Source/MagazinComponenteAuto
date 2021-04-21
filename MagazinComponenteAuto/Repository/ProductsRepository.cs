using MagazinComponenteAuto.Models;
using MagazinComponenteAuto.Models.DBObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MagazinComponenteAuto.Repository
{
    public class ProductsRepository
    {
        private MagazinComponenteAutoDataContext dbContext;

        public ProductsRepository()
        {
            dbContext = new MagazinComponenteAutoDataContext();
        }
        public ProductsRepository(MagazinComponenteAutoDataContext _dbContext)
        {
            dbContext = _dbContext;
        }
        public List<ProductsModels> GetAllProducts()
        {
            List<ProductsModels> productList = new List<ProductsModels>();
            foreach (Product dbProducts in dbContext.Products)
            {
                productList.Add(MapDbObjectsToModel(dbProducts));
            }
            return productList;
        }

        private ProductsModels MapDbObjectsToModel(Product dbProducts)
        {
            ProductsModels productsModels = new ProductsModels();
            if (dbProducts != null)
            { 
                productsModels.ProductCode = dbProducts.ProductCodeID;
                productsModels.ProductName = dbProducts.ProductName;
                productsModels.Details = dbProducts.Details;
                productsModels.Price = dbProducts.Price;
                productsModels.ImageName = dbProducts.ImageName;
                return productsModels;
            }
            return null;
        }

        public ProductsModels GetProductById(int ID)
        {
            var product = dbContext.Products.FirstOrDefault(x => x.ProductCodeID == ID);

            return MapDbObjectsToModel(product);
        }
        public void InsertProduct(ProductsModels product)
        {
            dbContext.Products.InsertOnSubmit(MapModelToDbObject(product));
            dbContext.SubmitChanges();
        }

        private Product MapModelToDbObject(ProductsModels product)
        {
            Product dbProducts = new Product();
            if (product != null)
            {
                dbProducts.ProductCodeID = product.ProductCode;
                dbProducts.ProductName = product.ProductName;
                dbProducts.Details = product.Details;
                dbProducts.Price = product.Price;
                dbProducts.ImageName = product.ImageName;
                return dbProducts;
            }
            return null;
        }
        public void UpdateProduct(ProductsModels product)
        {
            Product dbProducts = dbContext.Products.FirstOrDefault(x => x.ProductCodeID == product.ProductCode);
            if (product != null)
            {
                dbProducts.ProductCodeID = product.ProductCode;
                dbProducts.ProductName = product.ProductName;
                dbProducts.Details = product.Details;
                dbProducts.Price = product.Price;
                dbProducts.ImageName = product.ImageName;
                dbContext.SubmitChanges();
            }
        }
        public void DeleteProduct(int id)
        {
            Product dbProducts = dbContext.Products.FirstOrDefault(x => x.ProductCodeID == id);
            if (dbProducts != null)
            {
                dbContext.Products.DeleteOnSubmit(dbProducts);
                dbContext.SubmitChanges();
            }
        }
    }
}