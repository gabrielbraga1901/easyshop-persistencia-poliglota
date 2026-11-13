using LiteDB;

namespace EasyShop.Models;

public class Product
{
    [BsonId]
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public string Category { get; set; } = string.Empty;
    public Dictionary<string, string> Attributes { get; set; } = new();
    [BsonIgnore]
    public string AttributesSummary => Attributes.Count == 0 ? "Sem atributos adicionais" : string.Join("  •  ", Attributes.Select(x => $"{x.Key}: {x.Value}"));
}
