using SQLite;

namespace EasyShop.Models;

[Table("Customers")]
public class Customer
{
    [PrimaryKey, AutoIncrement]
    public int Id { get; set; }

    [NotNull, MaxLength(120)]
    public string Name { get; set; } = string.Empty;

    [NotNull, MaxLength(160), Unique]
    public string Email { get; set; } = string.Empty;
}
