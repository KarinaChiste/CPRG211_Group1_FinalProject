using System;
using Microsoft.Maui;
using Microsoft.Maui.Hosting;

namespace CPRG211_Group1_FinalProject;

class Program : MauiApplication
{
	protected override MauiApp CreateMauiApp() => MauiProgram.CreateMauiApp();

	static void Main(string[] args)
	{
		var app = new Program();
		app.Run(args);
	}
}
