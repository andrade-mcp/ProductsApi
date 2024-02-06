using ProductsApi.Model;
using System.Collections.Generic;
using System.Threading.Tasks;


public interface IProductsService
{        
    Task<IEnumerable<Product>> GetAllProductsAsync();
    Task<IEnumerable<Product>> GetProductByColorAsync(string color);
}
