global using System;
global using System.Windows.Input;
global using System.Collections.ObjectModel;

global using TinyMvvm;

global using NewsApp.Services;
global using NewsApp.ViewModels;
global using NewsApp.Views;
global using NewsApp.Models;

global using CommunityToolkit.Mvvm.ComponentModel;
global using CommunityToolkit.Mvvm.Input;
global using CommunityToolkit.Maui;
global using CommunityToolkit.Maui.Alerts;

global using TinyPubSubLib;



namespace NewsApp;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			})
			.UseTinyMvvm()
			.UseMauiCommunityToolkit();

		builder.Services.AddSingleton<INewsService, NewsService>();
        builder.Services.AddSingleton<IBookmarkService, BookmarkService>();

        builder.Services.AddTransient<MainViewModel>();
        builder.Services.AddTransient<NewsItemViewModel>();
        builder.Services.AddTransient<BookmarkViewModel>();

        builder.Services.AddTransient<MainView>();        
        builder.Services.AddTransient<NewsItemView>();
        builder.Services.AddTransient<BookmarkView>();

        Routing.RegisterRoute(nameof(NewsItemViewModel), typeof(NewsItemView));

        return builder.Build();
	}
}

