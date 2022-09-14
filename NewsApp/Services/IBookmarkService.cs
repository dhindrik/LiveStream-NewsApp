using System;
namespace NewsApp.Services
{
	public interface IBookmarkService
	{
		Task Save(NewsItem newsItem);
		Task<List<NewsItem>> GetAll();
	}
}

