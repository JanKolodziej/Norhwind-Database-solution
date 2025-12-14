using Microsoft.EntityFrameworkCore;
using Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NW_Class_lib
{
    public class Exercise3:Exercise_temp //Exercise SQL Queries for HAVING
    {
        public Exercise3(NorthwindContext context) : base(context) { }
        public int Report_Delayed_shipments() //Create a report that shows the order ids and the associated employee names for orders that shipped after the required date (37 rows)
        {
            var report = db.Orders.Where(o => o.ShippedDate!= null && o.ShippedDate.Value > o.RequiredDate).Select(o => new
            {
                o.OrderId,
                o.Employee
            }).ToList();
            return report.Count;
        }
        public int Report_Quantity_Of_Products() //Create a report that shows the total quantity of products (from the Order_Details table) ordered.
                                                 //Only show records for products for which the quantity ordered is fewer than 200 (5 rows)
        {
            var report = db.OrderDetails.Include(o=> o.Product).GroupBy(o => o.ProductId).Select(o => new
            {
                Id=o.Key,
                Number=o.Sum(g=>g.Quantity)
            }).Where(o => o.Number < 200).ToList();
            return report.Count;
        }
        //Create a report that shows the total number of orders by Customer since December 31,1996.
        //The report should only return rows for which the total number of orders is greater than 15 (5 rows)
        public int Report_Total_number_orders()
        {
            var report = db.Orders.Include(c => c.Customer).GroupBy(o => o.CustomerId).Select(o => new
            {
                ID = o.Key,
                NumberOfOrders = o.Count()
            }).Where(o => o.NumberOfOrders > 15).ToList();
            return report.Count;
        }
    }
}
