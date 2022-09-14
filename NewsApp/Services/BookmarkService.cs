namespace NewsApp.Services;

public class BookmarkService : IBookmarkService
{
    private static List<NewsItem> items = new List<NewsItem>();

    public BookmarkService()
    {
    }

    public Task<List<NewsItem>> GetAll()
    {
        return Task.FromResult(items);
    }

    public Task Save(NewsItem newsItem)
    {
        items.Add(newsItem);

        TinyPubSub.Publish("bookmark_added");

        return Task.CompletedTask;
    }
}

