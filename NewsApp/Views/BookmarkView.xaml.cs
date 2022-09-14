namespace NewsApp.Views;

public partial class BookmarkView
{
    private readonly BookmarkViewModel bookmarkViewModel;

    public BookmarkView(BookmarkViewModel bookmarkViewModel)
	{
		InitializeComponent();
        this.bookmarkViewModel = bookmarkViewModel;

        BindingContext = bookmarkViewModel;
    }
}
