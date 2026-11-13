namespace EasyShop.ViewModels;

public sealed class CustomersViewModel : BaseViewModel
{
    private readonly CustomerService _service;
    private string _name = string.Empty;
    private string _email = string.Empty;
    private bool _isBusy;

    public ObservableCollection<Customer> Customers { get; } = new();
    public string Name { get => _name; set => SetProperty(ref _name, value); }
    public string Email { get => _email; set => SetProperty(ref _email, value); }
    public bool IsBusy { get => _isBusy; set => SetProperty(ref _isBusy, value); }
    public ICommand AddCommand { get; }
    public ICommand RefreshCommand { get; }

    public CustomersViewModel(CustomerService service)
    {
        _service = service;
        AddCommand = new AsyncCommand(AddAsync, () => !IsBusy);
        RefreshCommand = new AsyncCommand(LoadAsync, () => !IsBusy);
    }

    public async Task LoadAsync()
    {
        try
        {
            IsBusy = true;
            Customers.Clear();
            foreach (var customer in await _service.GetCustomersAsync()) Customers.Add(customer);
            Message = $"{Customers.Count} cliente(s) encontrado(s) no SQLite.";
        }
        catch (Exception ex) { Message = $"Erro ao carregar clientes: {ex.Message}"; }
        finally { IsBusy = false; }
    }

    private async Task AddAsync()
    {
        try
        {
            IsBusy = true;
            await _service.AddCustomerAsync(Name, Email);
            Name = Email = string.Empty;
            await LoadAsync();
            Message = "Cliente cadastrado com sucesso no banco SQL (SQLite).";
        }
        catch (Exception ex) { Message = ex.Message; }
        finally { IsBusy = false; }
    }
}
