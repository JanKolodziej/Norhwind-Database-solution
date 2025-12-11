using Microsoft.EntityFrameworkCore;
using Models.Models;
// Testing if database works as intended
Write_Number_of_Products_In_Categories();
static void Write_Number_of_Products_In_Categories()
{
    using (NorthwindContext db = new())
    {
        Console.WriteLine("List of Categories and number of products assigned to them:");
        IQueryable<Category> categories = db.Categories.Include(c => c.Products);
        foreach(Category k in categories)
        {
            Console.WriteLine($"Category {k.CategoryName} has {k.Products.Count} products");
        }
    }
}
static void Get_all_columns_Customers_Orders_Suppliers()
{
    using(NorthwindContext db = new())
    {
        IQueryable<Customer>
    }
}

