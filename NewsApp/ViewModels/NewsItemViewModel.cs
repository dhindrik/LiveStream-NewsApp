


namespace NewsApp.ViewModels;

public partial class NewsItemViewModel : ViewModel
{
    private readonly IBookmarkService bookmarkService;

    public NewsItemViewModel(IBookmarkService bookmarkService)
    {
        this.bookmarkService = bookmarkService;

        addBookmark = new AsyncRelayCommand(SaveBookmark);
    }

    [ObservableProperty]
    private NewsItem item;

    [ObservableProperty]
    private ICommand addBookmark;

    public override async Task ParameterSet()
    {
        await base.ParameterSet();

        Item = NavigationParameter as NewsItem;
    }

    private async Task SaveBookmark()
    {
        try
        {
            await bookmarkService.Save(item);

            var toast = Toast.Make("Bookmark saved!");

            await toast.Show();
        }
        catch (Exception ex)
        {
            await HandleException(ex);
        }
    }
}

