using Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NW_Class_lib
{
    public class Exercise7: Exercise_temp //Exercise Advances SQL queries
    {
        public Exercise7(NorthwindContext context) : base(context) { }

        public decimal Total_revenue_1997() //What were our total revenues in 1997 (Result must be 617.085,27???)
        {
            decimal revenue = db.OrderDetails.Where(od => od.Order.OrderDate != null
            && od.Order.OrderDate.Value.Year == 1997)
                .Sum(od => (od.Quantity * od.UnitPrice) * (1 - (decimal)od.Discount));
            return Math.Round(revenue,2);
        }
        //What is the total amount each customer has payed us so far (Hint: QUICK-Stop has payed us 110.277,32)
        public decimal Total_revenue_customer()
        {
            var customers_revenue = db.OrderDetails.GroupBy(od => od.Order.Customer.CompanyName).Select(g => new
            {
                CustomerName=g.Key,
                Total = g.Sum(od => (od.Quantity * od.UnitPrice) * (1 - (decimal)od.Discount))
                
            }).ToList();
            var quickStop = customers_revenue.FirstOrDefault(c => c.CustomerName == "QUICK-Stop");

            if (quickStop == null) return 0m; 

            return (decimal)Math.Round(quickStop.Total, 2);
        }
        public decimal Top_selling_Product() //Find the 10 top selling products (Hint: Top selling product is "Côte de Blaye")
        {
            var top = db.OrderDetails.GroupBy(od => od.ProductId).Select(g => new
            {
                ProductID = g.Key,
                Total = g.Sum(od => (od.Quantity* od.UnitPrice) * (1 - (decimal) od.Discount))
            }).OrderByDescending(g=>g.Total).FirstOrDefault();
            return top.Total;
        }
        public int How_many_UKcustomers_paid_more_than_1000() //Which UK Customers have payed us more than 1000 dollars (6 rows)
        {
            var numberof = db.OrderDetails.Where(od => od.Order.Customer.Country == "UK").
                GroupBy(od => od.Order.CustomerId).Select(g => new
                {
                    CustomerId = g.Key,
                    Total = g.Sum(od => (od.Quantity * od.UnitPrice) * (1 - (decimal)od.Discount))

                }).Where(g => g.Total > 1000).Count();
            return numberof;
        }

        /*
             How much has each customer payed in total and how much in 1997. We want one result set with the following columns:
            CustomerID
            CompanyName
            Country
            Customer's total from all orders
            Customer's total from 1997 orders You can try this with views, 
            subqueries or temporary tables. Try using [Order Subtotals] view that already exists in database. 
            (91 rows, Customer "Centro comercial Moctezuma" has 100,80 total revenues and zero (0) revenues in 1997 )
         */

        public void Comparison_of_total_revenue_to_1997()
        {
            var comparison = db.OrderDetails.GroupBy(od => new
            { od.Order.CustomerId,
                od.Order.Customer.CompanyName,
                od.Order.Customer.Country})
                .Select(g => new
            {
                CustomerId = g.Key.CustomerId,
                CustomerName = g.Key.CompanyName,
                CustomerCountry = g.Key.Country,
                Total = g.Sum(od => (od.Quantity * od.UnitPrice) * (1 - (decimal)od.Discount)),
                Total1997 = g.Where(od => od.Order.OrderDate.Value.Year == 1997).Sum(od => (od.Quantity * od.UnitPrice) * (1 - (decimal)od.Discount))
            });
        }

    }
    
}
