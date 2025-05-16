namespace SalesApi.Application.DTOs;

public record ProductRequestDto(string Name, string Description, decimal Price, string Category, string Image);
public record ProductResponseDto(Guid Id, string Name, string Description, decimal Price, string Category, string Image);