using MiniCommerce.Api.Dtos;
using MiniCommerce.Api.Models;

namespace MiniCommerce.Api.Services;

public interface IProductService
{
    IEnumerable<Product> GetAll();
    Product? GetById(Guid id);
    Product Create(CreateProductDto dto);
    bool Update(Guid id, UpdateProductDto dto);
    bool Delete(Guid id);
}
