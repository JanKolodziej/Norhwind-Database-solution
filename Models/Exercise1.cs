using Models.Models;
using Microsoft.EntityFrameworkCore;

namespace Models
{
    // Doing exercises do enhance my EF Core skills 
    //Exercises from https://github.com/eirkostop/SQL-Northwind-exercises?tab=readme-ov-file
    public class Exercise1
    {
        private NorthwindContext db;
        public Exercise1(NorthwindContext northwindContext)
        {
            db= northwindContext;
        }


        /// <summary>
        /// Exercise 1.1
        /// Get all columns from the tables Customers, Orders and Suppliers
        /// </summary>
        public (List<Customer>,List<Order>,List<Supplier>) Get_Customers_Orders_suppliers() 
         {
           
            List<Customer> customers = db.Customers.FromSqlRaw("SELECT * FROM Customers").ToList();
            List<Order> orders = db.Orders.AsNoTracking().ToList();
            List<Supplier> suppliers = db.Suppliers.FromSqlRaw("SELECT * FROM Suppliers").ToList();
            return (customers, orders, suppliers);
            
         }

        /// <summary>
        /// Exercise 1.2
        /// Get all Customers alphabetically, sorted by Country and name
        /// </summary>
        /// <returns></returns>
        public List<Customer> Get_Customers_By_Country_CompanyName() 
         {
            
            List<Customer> customers_sorted = db.Customers.OrderBy(p => p.Country).ThenBy(b => b.CompanyName).ToList();
            return customers_sorted;
            
         }

        /// <summary>
        /// Exercise 1.3
        /// Get all Orders by date
        /// </summary>
        /// <returns></returns>
        public List<Order> Get_Orders_By_Date() 
        {
            List<Order> orders_by_date = db.Orders.OrderBy(p => p.OrderDate).ToList();
            return orders_by_date;
        }

        /// <summary>
        /// Exercise 1.4
        /// Get the count of all Orders made during 1997 (generalized version)
        /// </summary>
        /// <param name="year"></param>
        /// <returns></returns>
        public int Count_Orders_In_GivenYear(int year)
        {
            int count = (db.Orders.Where(p => p.OrderDate.Value.Year == year)).Count();
            return count;
        }


        /// <summary>
        /// Exercise 1.5
        /// Get the names of all the contact persons where the person is a manager, alphabetically
        /// </summary>
        /// <returns></returns>
        public List<string> Get_Names_Managers_alphab()
        {
            List<string> names = db.Customers.Where(p => p.ContactTitle.Contains("Manager")).OrderBy(p=> p.CompanyName).Select(p => p.ContactName).ToList();
            return names;
        }

        /// <summary>
        /// Exercise 1.6
        /// Get all orders placed on the 19th of May, 1997 (generalized version)
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public List<Order> Get_Orders_At_Given_Date(DateTime date)
        {
            List<Order> orders = db.Orders.Where(p => p.OrderDate.Value.Date == date.Date).ToList();
            return orders;
        }
    }
}
