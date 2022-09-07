using System;
using NewsApp.Models;

namespace NewsApp.Services
{
	public interface INewsService
	{
		Task<List<NewsItem>> Get();
	}
}

