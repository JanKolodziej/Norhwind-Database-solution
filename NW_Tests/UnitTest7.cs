using Models.Models;
using NW_Class_lib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NW_Tests
{
    public class UnitTest7
    {
        private readonly NorthwindContext _context = new();
        [Fact]
        //I believe there is a mistake in exercise since the answer is not 617.085,27
        // I double checked all possibilities of rounding in my code(round all lines one by one, round the answer)
        //What s more I ran this code
        /*
         * 
            SELECT SUM(([Order Details].UnitPrice)* [Order Details].Quantity * (1.0-[Order Details].Discount)) AS [1997 Total Revenues]
            FROM [Order Details]
            INNER JOIN (SELECT OrderID FROM Orders WHERE YEAR(OrderDate) = '1997') AS Ord 
            ON Ord.OrderID = [Order Details].OrderID
         */
        //(Code is a model answer), and stil got 617085.20
        public void Test_Total_revenue_1997()
        {
            Exercise7 ex = new(_context);
            decimal wynik = ex.Total_revenue_1997();
            Assert.Equal(617085.20M, wynik);
        }

        //Same problem as before
        /*
         SELECT Customers.CompanyName, SUM([Order Details].UnitPrice * [Order Details].Quantity * (1.0- [Order Details].Discount)) AS [Total]
        FROM Customers
        INNER JOIN Orders ON Customers.CustomerID = Orders.CustomerID
        INNER JOIN [Order Details] ON [Order Details].OrderID = Orders.OrderID
        GROUP BY Customers.CompanyName
        ORDER BY [Total] DESC;
         */
        // from model code answer is 110277.30 but in a task there is 110277.32
        [Fact]
        public void Test_Total_revenue_customer()
        {
            Exercise7 ex = new(_context);
            var wynik = ex.Total_revenue_customer();
            Assert.Equal(110277.30M, wynik);
        }
        [Fact]
        public void Test_Top_selling_Product()
        {
            Exercise7 ex = new(_context);
            decimal wynik = ex.Top_selling_Product();
            Assert.Equal(141396.74M, wynik,2);
        }
        [Fact]
        public void Test_How_many_UKcustomers_paid_more_than_1000()
        {
            Exercise7 ex = new(_context);
            decimal wynik = ex.How_many_UKcustomers_paid_more_than_1000();
            Assert.Equal(6, wynik);
        }

    }
}
