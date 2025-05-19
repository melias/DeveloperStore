namespace SalesApi.Application.DTOs;

public record ProductRequestDto(string Title, string Description, decimal Price, string Category, string Image);
public record ProductResponseDto(Guid Id, string Title, string Description, decimal Price, string Category, string Image);