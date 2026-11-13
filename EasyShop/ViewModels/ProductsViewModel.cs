namespace EasyShop.ViewModels;

public sealed class ProductsViewModel : BaseViewModel
{
    private readonly ProductService _service;
    private string _name = string.Empty;
    private string _price = string.Empty;
    private string _category = string.Empty;
    private string _attributes = string.Empty;
    private bool _isBusy;

    public ObservableCollection<Product> Products { get; } = new();
    public string Name { get => _name; set => SetProperty(ref _name, value); }
    public string Price { get => _price; set => SetProperty(ref _price, value); }
    public string Category { get => _category; set => SetProperty(ref _category, value); }
    public string Attributes { get => _attributes; set => SetProperty(ref _attributes, value); }
    public bool IsBusy { get => _isBusy; set => SetProperty(ref _isBusy, value); }
    public ICommand AddCommand { get; }
    public ICommand RefreshCommand { get; }

    public ProductsViewModel(ProductService service)
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
            Products.Clear();
            foreach (var product in await _service.GetProductsAsync()) Products.Add(product);
            Message = $"{Products.Count} produto(s) encontrado(s) no LiteDB.";
        }
        catch (Exception ex) { Message = $"Erro ao carregar produtos: {ex.Message}"; }
        finally { IsBusy = false; }
    }

    private async Task AddAsync()
    {
        try
        {
            IsBusy = true;
            await _service.AddProductAsync(Name, Price, Category, Attributes);
            Name = Price = Category = Attributes = string.Empty;
            await LoadAsync();
            Message = "Produto cadastrado com sucesso no banco NoSQL (LiteDB).";
        }
        catch (Exception ex) { Message = ex.Message; }
        finally { IsBusy = false; }
    }
}
