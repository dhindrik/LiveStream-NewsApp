using System;
namespace NewsApp.Models
{
	public record NewsItem
	{
		public string Title { get; set; }
		public string Body { get; set; }
		public DateTime Published { get; set; }
		public string Image { get; set; }
	}
}

