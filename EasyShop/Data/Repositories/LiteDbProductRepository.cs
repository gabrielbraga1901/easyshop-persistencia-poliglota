using LiteDB;

namespace EasyShop.Data.Repositories;

/// <summary>Responsável exclusivamente pela persistência de produtos no LiteDB (NoSQL).</summary>
public sealed class LiteDbProductRepository : IProductRepository
{
    private readonly string _databasePath = Path.Combine(FileSystem.AppDataDirectory, "products.db");

    public Task<List<Product>> GetAllAsync()
    {
        using var database = new LiteDatabase(_databasePath);
        var products = database.GetCollection<Product>("products");
        products.EnsureIndex(x => x.Name);
        return Task.FromResult(products.FindAll().OrderBy(x => x.Name).ToList());
    }

    public Task AddAsync(Product product)
    {
        using var database = new LiteDatabase(_databasePath);
        var products = database.GetCollection<Product>("products");
        products.Insert(product);
        return Task.CompletedTask;
    }
}
