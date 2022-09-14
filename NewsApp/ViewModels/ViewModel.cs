namespace NewsApp.ViewModels;

public abstract class ViewModel : TinyViewModel
{
    public ViewModel()
    {
    }

    protected Task HandleException(Exception ex)
    {
        return Task.CompletedTask;
    }
}

