using Models.Models;
using NW_Class_lib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NW_Tests
{
    public class UnitTest3
    {
        private readonly NorthwindContext _context = new();
        [Fact]
        public void Test_Report_Delayed_shipments()
        {

            Exercise3 ex = new(_context);
            var wynik = ex.Report_Delayed_shipments();
            Assert.Equal(37, wynik);

        }
        [Fact]
        public void Test_Report_Quantity_Of_Products()
        {

            Exercise3 ex = new(_context);
            var wynik = ex.Report_Quantity_Of_Products();
            Assert.Equal(5, wynik);

        }
        [Fact]
        public void Test_Report_Total_number_orders()
        {

            Exercise3 ex = new(_context);
            var wynik = ex.Report_Quantity_Of_Products();
            Assert.Equal(5, wynik);

        }
    }
}
