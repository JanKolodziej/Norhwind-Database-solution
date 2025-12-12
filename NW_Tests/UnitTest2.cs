using Models.Models;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NW_Class_lib;


namespace NW_Tests
{
    //For those tests, the database was assumed to be static and unchanging. Therefore, the test results will not change.
    public class UnitTest2
    {
        private readonly NorthwindContext _context = new();
        [Fact]
        public void Test_Report_Orders_Customers_1996()
        {
            
            Exercise2 ex = new(_context);
            var wynik = ex.Report_Orders_Customers_1996();
            Assert.Equal(152, wynik.Count());
            
        }
        [Fact]
        public void Test_Report_Count_City_Where_Employees()
        {

            Exercise2 ex = new(_context);
            int wynik = ex.Report_Count_City_Where_Employees();
            Assert.Equal(5, wynik);
        }
        [Fact]
        public void Test_Report_Count_City_Where_Customers()
        {

            Exercise2 ex = new(_context);
            int wynik = ex.Report_Count_City_Where_Customers();
            Assert.Equal(69, wynik);
        }

    }
}
