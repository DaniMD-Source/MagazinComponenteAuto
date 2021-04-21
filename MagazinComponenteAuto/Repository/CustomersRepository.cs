using MagazinComponenteAuto.Models;
using MagazinComponenteAuto.Models.DBObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MagazinComponenteAuto.Repository
{
    public class CustomersRepository
    {
        private MagazinComponenteAutoDataContext dbContext;

        public CustomersRepository()
        {
            dbContext = new MagazinComponenteAutoDataContext();
        }
        public CustomersRepository(MagazinComponenteAutoDataContext _dbContext)
        {
            dbContext = _dbContext;
        }
        public CustomersModels GetCustomersByID(Guid id)
        {
            var Customers = dbContext.Customers.FirstOrDefault(x => x.ClientID == id);
            return MapDbObjectToModel(Customers);
        }
        private Customer MapModelToDbObject(CustomersModels Customers)
        {
            Customer CustomerDB = new Customer();
            if (CustomerDB != null)
            {
                CustomerDB.ClientID = Customers.CliendID;
                CustomerDB.FirstName = Customers.FirstName;
                CustomerDB.LastName = Customers.LastName;
                CustomerDB.Phone = Customers.Phone;
                CustomerDB.Email = Customers.Email;
                CustomerDB.Adress = Customers.Adress;
                return CustomerDB;
            }
            return null;
        }
        private CustomersModels MapDbObjectToModel(Customer CustomersDB)
        {
            CustomersModels Customers = new CustomersModels();
            if (CustomersDB != null)
            {
                Customers.CliendID = CustomersDB.ClientID;
                Customers.FirstName = CustomersDB.FirstName;
                Customers.LastName = CustomersDB.LastName;
                Customers.Phone = CustomersDB.Phone;
                Customers.Email = CustomersDB.Email;
                Customers.Adress = CustomersDB.Adress;
                return Customers;
            }
            return null;
        }
        public void InsertCustomer(CustomersModels customer)
        {
            dbContext.Customers.InsertOnSubmit(MapModelToDbObject(customer));
            dbContext.SubmitChanges();
        }
        public List<CustomersModels> GetAllCustomers()
        {
            List<CustomersModels> customerList = new List<CustomersModels>();
            foreach (Customer dbCustomer in dbContext.Customers)
            {
                customerList.Add(MapDbObjectToModel(dbCustomer));
            }
            return customerList;
        }
        public void UpdateCustomer(CustomersModels customer)
        {
            Customer dbCustomers = dbContext.Customers.FirstOrDefault(x => x.ClientID == customer.CliendID);
            if (customer != null)
            {
                dbCustomers.ClientID = customer.CliendID;
                dbCustomers.FirstName = customer.FirstName;
                dbCustomers.LastName = customer.LastName;
                dbCustomers.Phone = customer.Phone;
                dbCustomers.Email = customer.Email;
                dbCustomers.Adress = customer.Adress;
                dbContext.SubmitChanges();
            }
        }
        public void DeleteCustomer(Guid id)
        {
            Customer dbCustomer = dbContext.Customers.FirstOrDefault(x => x.ClientID == id);
            if (dbCustomer != null)
            {
                dbContext.Customers.DeleteOnSubmit(dbCustomer);
                dbContext.SubmitChanges();
            }
        }
    }
}
