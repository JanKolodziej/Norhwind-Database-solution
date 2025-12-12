using Microsoft.EntityFrameworkCore;
using Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NW_Class_lib
{
    public class Exercise2
    {
        private NorthwindContext db;
        public Exercise2(NorthwindContext northwindContext)
        {
            db = northwindContext;
        }

        public List<Order> Report_Orders_Customers_1996() //Create a report for all the orders of 1996 and their Customers (152 rows)
        {
            var report = db.Orders.Where(p => p.OrderDate.Value.Year == 1996).Include(p => p.Customer).ToList();
            return report;
        }
        public int Report_Count_City_Where_Customers() //Create a report that shows the number of employees and customers from each city that has customers in it (69 rows)
        {
            int report = db.Customers.GroupBy(c => c.City).Select(g=> new 
            { City =g.Key,
                CustomerCount = g.Count(),
            EmployeeCount = db.Employees.Count(c=>c.City ==g.Key)
            }).Count();
            return report;
        }
        public int Report_Count_City_Where_Employees() //Create a report that shows the number of employees and customers from each city that has employees in it (5 rows)
        {
            int report = db.Employees.GroupBy(c => c.City).Select(g => new
            {
                City = g.Key,
                EmployeeCount = g.Count(),
                CustomerCount = db.Customers.Count(c => c.City == g.Key)
            }).Count();
            return report;
        }

    }
}
