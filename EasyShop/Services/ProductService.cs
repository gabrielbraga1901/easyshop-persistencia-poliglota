using EasyShop.Data.Repositories;

namespace EasyShop.Services;

/// <summary>Contém as regras de negócio relacionadas ao catálogo de produtos.</summary>
public sealed class ProductService
{
    private readonly IProductRepository _repository;
    public ProductService(IProductRepository repository) => _repository = repository;

    public Task<List<Product>> GetProductsAsync() => _repository.GetAllAsync();

    public async Task AddProductAsync(string name, string priceText, string category, string attributesText)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("Informe o nome do produto.");
        if (!decimal.TryParse(priceText, System.Globalization.NumberStyles.Number,
                System.Globalization.CultureInfo.CurrentCulture, out var price) || price <= 0)
            throw new ArgumentException("Informe um preço válido maior que zero.");

        var attributes = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
        if (!string.IsNullOrWhiteSpace(attributesText))
        {
            foreach (var item in attributesText.Split(';', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries))
            {
                var separator = item.IndexOf(':');
                if (separator <= 0 || separator == item.Length - 1)
                    throw new ArgumentException("Use os atributos no formato: Cor: Azul; Tamanho: M.");
                var key = item[..separator].Trim();
                var value = item[(separator + 1)..].Trim();
                attributes[key] = value;
            }
        }

        await _repository.AddAsync(new Product
        {
            Name = name.Trim(),
            Price = price,
            Category = category?.Trim() ?? string.Empty,
            Attributes = attributes
        });
    }
}
