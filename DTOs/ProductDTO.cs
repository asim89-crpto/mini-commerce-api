namespace MiniCommerce.Api.Dtos;

public record CreateProductDto(
    string Name,
    string Description,
    decimal Price,
    int Stock,
    string Category
);
