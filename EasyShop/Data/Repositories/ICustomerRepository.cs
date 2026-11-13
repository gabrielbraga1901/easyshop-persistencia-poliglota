namespace EasyShop.Data.Repositories;

public interface ICustomerRepository
{
    Task<List<Customer>> GetAllAsync();
    Task AddAsync(Customer customer);
}
