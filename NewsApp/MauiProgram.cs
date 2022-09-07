global using System;
global using TinyMvvm;
global using NewsApp.Services;
global using NewsApp.ViewModels;
global using NewsApp.Views;
global using System.Collections.ObjectModel;
global using NewsApp.Models;

global using CommunityToolkit.Mvvm.ComponentModel;
global using CommunityToolkit.Mvvm.Input;

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
			.UseTinyMvvm();

		builder.Services.AddSingleton<INewsService, NewsService>();

		builder.Services.AddTransient<MainViewModel>();
        builder.Services.AddTransient<NewsItemViewModel>();

        builder.Services.AddTransient<MainView>();        
        builder.Services.AddTransient<NewsItemView>();

		Routing.RegisterRoute(nameof(NewsItemViewModel), typeof(NewsItemView));

        return builder.Build();
	}
}

