namespace MiniCommerce.Api.Dtos;

public record UpdateProductDto(
    string Name,
    string Description,
    decimal Price,
    int Stock,
    string Category
);
