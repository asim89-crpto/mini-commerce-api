using MiniCommerce.Api.Dtos;
using MiniCommerce.Api.Models;

namespace MiniCommerce.Api.Services;

public class InMemoryProductService : IProductService
{
    private static readonly List<Product> _products = new()
    {
        new Product { Name="Cricket Bat", Description="English willow bat", Price=199.99m, Stock=10, Category="Sports" },
        new Product { Name="Running Shoes", Description="Comfort runners", Price=79.99m, Stock=25, Category="Footwear" }
    };

    public IEnumerable<Product> GetAll() => _products;

    public Product? GetById(Guid id) => _products.FirstOrDefault(p => p.Id == id);

    public Product Create(CreateProductDto dto)
    {
        var p = new Product
        {
            Name = dto.Name,
            Description = dto.Description,
            Price = dto.Price,
            Stock = dto.Stock,
            Category = dto.Category
        };
        _products.Add(p);
        return p;
    }

    public bool Update(Guid id, UpdateProductDto dto)
    {
        var p = GetById(id);
        if (p is null) return false;

        p.Name = dto.Name;
        p.Description = dto.Description;
        p.Price = dto.Price;
        p.Stock = dto.Stock;
        p.Category = dto.Category;
        return true;
    }

    public bool Delete(Guid id)
    {
        var p = GetById(id);
        if (p is null) return false;
        _products.Remove(p);
        return true;
    }
}
