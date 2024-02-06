using ProductsApi.Model;
using System.Collections;

public class ProductsService : IProductsService
{
       
    public async Task<IEnumerable<Product>> GetAllProductsAsync()
    {
        return (IEnumerable<Product>)ListProducts();
    }

    public async Task<IEnumerable<Product>> GetProductByColorAsync(string color)
    {
        IEnumerable<Product> Prod = (IEnumerable<Product>)ListProducts();
        return Prod.Where(p => p.Colour == color);
    }

    private static IEnumerable ListProducts()
    {
        List<Product> Products = new List<Product>()
            {
                new Product(){ Id=1, Name="Men Trousers", Description="Wide Blue Leg Beach Trousers", Colour="blue"},
                new Product(){ Id=2, Name="Kids Jumper", Description="Knitted Crew Neck Jumper", Colour="red"},
                new Product(){ Id=3, Name="Dress", Description="Sequin Floral Blue Dress", Colour="blue"},
                new Product(){ Id=4, Name="Jacket", Description="Denim Baseball Jacket", Colour="N/A"},
                new Product(){ Id=5, Name="T-Shirt", Description="Blue Print Oversized T-Shirt", Colour="blue"},
                new Product(){ Id=5, Name="T-Shirt", Description="Yellow Print Oversized T-Shirt", Colour="yellow"},
                new Product(){ Id=5, Name="T-Shirt", Description="Red Oversized T-Shirt", Colour="red"},
                new Product(){ Id=5, Name="T-Shirt", Description="White Oversized T-Shirt", Colour="white"},
                new Product(){ Id=5, Name="T-Shirt", Description="Gray Oversized T-Shirt", Colour="gray"},
            };

        return Products;
    }
}

