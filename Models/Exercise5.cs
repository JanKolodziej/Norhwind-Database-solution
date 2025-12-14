using Microsoft.EntityFrameworkCore;
using Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NW_Class_lib
{
    public class Exercise5 //Exercise SQL Updating Records
    {
        private NorthwindContext db;

        public Exercise5(NorthwindContext northwindContext)
        {
            db = northwindContext;
        }
        public void Update_My_phone()//Update the phone of yourself (from the previous entry in Employees table)
        {
            Employee? me = db.Employees
                .Where(e => e.LastName == "Kolodziej" 
                && e.FirstName == "Jan")
                .FirstOrDefault();
                if (me == null) return;
            me.HomePhone = "(+48)555666777";
            db.SaveChanges();
        }
        public void Double_Quantity() //Double the quantity of the order details record you inserted before 
        {
            OrderDetail? lastdetail = db.OrderDetails
                .Where(od => od.Order.Employee!=null 
            && od.Order.Employee.LastName == "Kolodziej" 
            && od.Order.Employee.FirstName == "Jan")
                .OrderByDescending(od => od.OrderId)
                .FirstOrDefault();
            if (lastdetail == null) return;

            lastdetail.Quantity *= 2;
            db.SaveChanges();
        }
        public void Double_all_Quantity() //Repeat previous update but this time update all orders associated with you 
        {
            var orderDetails= db.OrderDetails
                .Where(od => od.Order.Employee != null 
                && od.Order.Employee.LastName == "Kolodziej" 
                && od.Order.Employee.FirstName == "Jan");
            foreach(var od in orderDetails)
            {
                od.Quantity *= 2;
            }
            db.SaveChanges();
        }

    }
}
