using System;
namespace NewsApp.ViewModels
{
	public partial class BookmarkViewModel : ViewModel
	{
        private readonly IBookmarkService bookmarkService;

        public BookmarkViewModel(IBookmarkService bookmarkService)
		{
            this.bookmarkService = bookmarkService;

            open = new AsyncRelayCommand<NewsItem>(OpenView);

            TinyPubSub.Subscribe("bookmark_added", async () => await LoadData());
        }

        public override async Task Initialize()
        {
            await base.Initialize();

            try
            {
                IsBusy = true;

                await LoadData(); 
            }
            catch (Exception ex)
            {
                await HandleException(ex);
            }

            IsBusy = false;
        }

        private async Task LoadData()
        {
            var result = await bookmarkService.GetAll();

            Bookmarks = new ObservableCollection<NewsItem>(result);
        }

        [ObservableProperty]
        private ObservableCollection<NewsItem> bookmarks = new ObservableCollection<NewsItem>();

        [ObservableProperty]
        private AsyncRelayCommand<NewsItem> open;

        private async Task OpenView(NewsItem item)
        {
            try
            {
                await Navigation.NavigateTo(nameof(NewsItemViewModel), item);
            }
            catch (Exception ex)
            {
                await HandleException(ex);
            }
        }
    }
}

