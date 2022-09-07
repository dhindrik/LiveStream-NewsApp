namespace NewsApp.ViewModels;

public partial class MainViewModel : ViewModel
{
    private readonly INewsService newsService;

    public MainViewModel(INewsService newsService)
    {
        this.newsService = newsService;

        open = new AsyncRelayCommand<NewsItem>(OpenView);
    }

    [ObservableProperty]
    private ObservableCollection<NewsItem> items = new();

    [ObservableProperty]
    private AsyncRelayCommand<NewsItem> open;

    public override async Task Initialize()
    {
        await base.Initialize();

        try
        {
            IsBusy = true;

            var data = await newsService.Get();

            Items = new(data);
        }
        catch (Exception ex)
        {
            //TODO: Handle exception
        }

        IsBusy = false;
    }

    private async Task OpenView(NewsItem item)
    {
        await Navigation.NavigateTo(nameof(NewsItemViewModel), item);
    }
}

