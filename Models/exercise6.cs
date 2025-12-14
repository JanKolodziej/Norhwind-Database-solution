using Microsoft.EntityFrameworkCore;
using Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NW_Class_lib
{
    public class Exercise6
    {
        private NorthwindContext db;

        public Exercise6(NorthwindContext northwindContext)
        {
            db = northwindContext;
        }
        public void Delete_records_with_me() //Delete the records you inserted before. Don't delete any other records!
        {
            Employee? me = db.Employees
                .Where(e => e.LastName == "Kolodziej" 
                && e.FirstName == "Jan")
                .FirstOrDefault();
            if (me == null) return;
            using (var transaction = db.Database.BeginTransaction())
            {
                try
                {
                    var ordersdetail = db.OrderDetails
                    .Where(od => od.Order.EmployeeId == me.EmployeeId)
                    .ExecuteDelete();

                    var my_orders = db.Orders.Where(o => o.EmployeeId == me.EmployeeId)
                        .ExecuteDelete();

                    db.Remove(me);
                    db.SaveChanges();

                    transaction.Commit();
                }
                catch
                {
                    transaction.Rollback();
                    throw;
                }
            }
            

        }
    }
}
