using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NW_Class_lib
{
    public class Exercise4 //Exercise SQL Inserting Records
    {
        private NorthwindContext db;
        
        public Exercise4(NorthwindContext northwindContext)
        {
            db = northwindContext;
        }
        //Insert yourself into the Employees table Include the following fields: LastName, FirstName, Title, TitleOfCourtesy, BirthDate,
        //HireDate, City, Region, PostalCode, Country, HomePhone, ReportsTo
        public void Insert_Myself()
        {
            Employee me = new(){
                LastName = "Kolodziej",
                FirstName = "Jan",
                Title = "Engineer", //Soon :)
                TitleOfCourtesy = "Mr.",
                BirthDate = new DateTime(2000,01,01),
                HireDate = DateTime.Now, //Finger Crossed
                City ="Cracow",
                Region="KR",
                PostalCode="30059",
                Country="Poland",
                HomePhone="(+48)502900974",
                ReportsTo=3
            };
            db.Employees.Add(me);
            
        }

        //Insert an order for yourself in the Orders table Include the following fields:
        //CustomerID, EmployeeID, OrderDate, RequiredDate
        public void Insert_Order()
        {
            var me = db.Employees.Where(e => e.LastName == "Kolodziej" && e.FirstName == "Jan")
                .FirstOrDefault();
            if (me == null) return;
            Order order = new()
            {
                CustomerId = "1",
                EmployeeId = me.EmployeeId,
                OrderDate = DateTime.Now.Date,
                RequiredDate = DateTime.Now.Date.AddDays(14)
            };
            db.Orders.Add(order);

            //Insert order details in the Order_Details table Include the following fields:
            //OrderID, ProductID, UnitPrice, Quantity, Discount
            OrderDetail orderDetail = new()
            {
                OrderId = order.OrderId,
                ProductId=1,
                UnitPrice=10,
                Quantity= 80,
                Discount=0
            };
            db.SaveChanges();
        }

    }
}
