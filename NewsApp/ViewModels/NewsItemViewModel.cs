
namespace NewsApp.ViewModels;

public partial class NewsItemViewModel : ViewModel
{
    public NewsItemViewModel()
    {
    }

    [ObservableProperty]
    private NewsItem item;

    public override async Task ParameterSet()
    {
        await base.ParameterSet();

        Item = NavigationParameter as NewsItem;
    }
}

