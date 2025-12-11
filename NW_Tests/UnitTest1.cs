using Models;
using Microsoft.EntityFrameworkCore;
using Models.Models;
using Microsoft.Identity.Client;
namespace NW_Tests
{
    public class UnitTest1
    {
        private NorthwindContext GetInMemoryContext()
        {
            var options = new DbContextOptionsBuilder<NorthwindContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString()).Options;
            return new NorthwindContext(options);
        }

        [Fact]
        public void Test_Get_Customers_By_Country_CompanyName_()
        {
            using(var context = GetInMemoryContext())
            {
                context.Customers.Add(new Customer { CustomerId = "1", CompanyName = "Zabka", Country = "Poland" });
                context.Customers.Add(new Customer { CustomerId = "2", CompanyName = "Aldi", Country = "Germany" });
                context.Customers.Add(new Customer { CustomerId = "3", CompanyName = "Lidl", Country = "Germany" });
                context.SaveChanges();

                var service = new Exercise1(context);


                var wynik = service.Get_Customers_By_Country_CompanyName();

                Assert.Equal("Germany", wynik[0].Country);
                Assert.Equal("Poland", wynik[2].Country);
            }
        }

        [Fact]
        public void Test_Count_Orders_In_GivenYear()
        {
            using (var context = GetInMemoryContext())
            {
                context.Orders.Add(new Order { OrderId = 1, OrderDate = new DateTime(1997, 10, 11) });
                context.Orders.Add(new Order { OrderId = 2, OrderDate = new DateTime(1998, 10, 11) });
                context.Orders.Add(new Order { OrderId = 3, OrderDate = DateTime.Now });
                context.SaveChanges();
                var service = new Exercise1(context);
                int wynik = service.Count_Orders_In_GivenYear(1997);

                Assert.Equal(1, wynik);
            }
        }
        [Fact]
        public void Test_Get_Names_Managers_alphab()
        {
            using (var context = GetInMemoryContext())
            {
                context.Customers.Add(new Customer { CustomerId = "1", ContactName = "John", ContactTitle = "Manager",CompanyName="A"});
                context.Customers.Add(new Customer { CustomerId = "2", ContactName = "Simon", ContactTitle = "Intern",CompanyName = "B" });
                context.Customers.Add(new Customer { CustomerId = "3", ContactName = "Mathew", ContactTitle = "CEO" ,CompanyName = "C" });
                context.Customers.Add(new Customer { CustomerId = "4", ContactName = "Victor", ContactTitle = "Manager" ,CompanyName = "D" });
                context.SaveChanges();
                var service = new Exercise1(context);
                var wynik = service.Get_Names_Managers_alphab();

                Assert.Equal(["John","Victor"], wynik);
            }
        }
        [Fact]
        public void Test_Get_Orders_At_Given_Date()
        {
            using (var context = GetInMemoryContext())
            {
                context.Orders.Add(new Order { OrderId = 1, OrderDate = new DateTime(1997, 10, 11) });
                context.Orders.Add(new Order { OrderId = 2, OrderDate = new DateTime(1998, 10, 11) });
                context.Orders.Add(new Order { OrderId = 3, OrderDate = DateTime.Now });
                context.SaveChanges();
                var service = new Exercise1(context);
                List<Order> wynik = service.Get_Orders_At_Given_Date(DateTime.Now.Date);

                Assert.Equal(3, wynik[0].OrderId);
            }
        }
    }
}
