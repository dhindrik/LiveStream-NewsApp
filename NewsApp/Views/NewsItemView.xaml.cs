namespace NewsApp.Views;

public partial class NewsItemView
{
	public NewsItemView(NewsItemViewModel viewModel)
	{
		InitializeComponent();

		BindingContext = viewModel;
	}
}
