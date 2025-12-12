using Microsoft.EntityFrameworkCore;
using Models.Models;
using NW_Class_lib;
internal class Program
{
    private static void Main(string[] args)
    {
        // Testing if database works as intended
        Write_Number_of_Products_In_Categories();
        // Doing exercises do enhance my EF Core skills 
        //Exercises from https://github.com/eirkostop/SQL-Northwind-exercises?tab=readme-ov-file
        using (NorthwindContext db = new())
        {
            Exercise2 ex = new(new NorthwindContext());
            var wynik = ex.Report_Orders_Customers_1996();
            foreach( var i in  wynik )
            {
                Console.WriteLine(i.Customer.ContactName);
            }
            

        }
    }
    static void Write_Number_of_Products_In_Categories()
    {
        using (NorthwindContext db = new())
        {
            Console.WriteLine("List of Categories and number of products assigned to them:");
            IQueryable<Category> categories = db.Categories.Include(c => c.Products);
            foreach (Category k in categories)
            {
                Console.WriteLine($"Category {k.CategoryName} has {k.Products.Count} products");
            }
        }
    }


}