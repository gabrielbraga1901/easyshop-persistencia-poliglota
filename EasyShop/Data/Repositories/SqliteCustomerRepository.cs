using SQLite;

namespace EasyShop.Data.Repositories;

/// <summary>Responsável exclusivamente pela persistência relacional de clientes no SQLite.</summary>
public sealed class SqliteCustomerRepository : ICustomerRepository
{
    private readonly SQLiteAsyncConnection _database;
    private readonly Task _initialization;

    public SqliteCustomerRepository()
    {
        var databasePath = Path.Combine(FileSystem.AppDataDirectory, "customers.db3");
        _database = new SQLiteAsyncConnection(databasePath);
        _initialization = _database.CreateTableAsync<Customer>();
    }

    public async Task<List<Customer>> GetAllAsync()
    {
        await _initialization;
        return await _database.Table<Customer>().OrderBy(x => x.Name).ToListAsync();
    }

    public async Task AddAsync(Customer customer)
    {
        await _initialization;
        await _database.InsertAsync(customer);
    }
}
