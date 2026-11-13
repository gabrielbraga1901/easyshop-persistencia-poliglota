using EasyShop.Data.Repositories;
using System.Net.Mail;

namespace EasyShop.Services;

/// <summary>Contém as regras de negócio relacionadas ao cadastro de clientes.</summary>
public sealed class CustomerService
{
    private readonly ICustomerRepository _repository;
    public CustomerService(ICustomerRepository repository) => _repository = repository;

    public Task<List<Customer>> GetCustomersAsync() => _repository.GetAllAsync();

    public async Task AddCustomerAsync(string name, string email)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("Informe o nome completo do cliente.");
        if (name.Trim().Length < 3)
            throw new ArgumentException("O nome deve ter pelo menos 3 caracteres.");
        if (string.IsNullOrWhiteSpace(email) || !MailAddress.TryCreate(email.Trim(), out var address) || address.Address != email.Trim())
            throw new ArgumentException("Informe um e-mail válido.");

        await _repository.AddAsync(new Customer { Name = name.Trim(), Email = email.Trim().ToLowerInvariant() });
    }
}
