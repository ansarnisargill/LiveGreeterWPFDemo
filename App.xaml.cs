using LiveGreeterWpfDemo.Models;
using LiveGreeterWpfDemo.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using LiveGreeterWpfDemo.Views;
using HandyControl.Controls;


namespace LiveGreeterWpfDemo
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static IHost host;

        public App()
        {
            host = Host.CreateDefaultBuilder()  
                                                
                    .ConfigureAppConfiguration((context, builder) =>
                    {
                        
                        builder.AddJsonFile("appsettings.local.json", optional: true);
                    }).ConfigureServices((context, services) =>
                    {
                        ConfigureServices(context.Configuration, services);
                    })
                    .ConfigureLogging(logging =>{})
                    .Build();
        }

        private void ConfigureServices(IConfiguration configuration, IServiceCollection services)
        {
            services.AddDbContext<Context>(options =>
            options.UseInMemoryDatabase("MainDB"));
            services.Configure<AppSettings>(configuration.GetSection(nameof(AppSettings)));
            services.AddScoped<IRestApiService, RestApiService>();

            services.AddSingleton<MainWindow>();
            services.AddTransient<RestApiDemo>();
            services.AddTransient<Game>();
            services.AddTransient<FlowDocument>();

        }

        protected override async void OnStartup(StartupEventArgs e)
        {
            await host.StartAsync();

            var mainWindow = host.Services.GetRequiredService<MainWindow>();
            mainWindow.Show();
            var context = host.Services.GetRequiredService<Context>();
            Initializer.Initialize(context);
            base.OnStartup(e);
        }

        protected override async void OnExit(ExitEventArgs e)
        {
            using (host)
            {
                await host.StopAsync(TimeSpan.FromSeconds(5));
            }

            base.OnExit(e);
        }

        private void Application_DispatcherUnhandledException(object sender, System.Windows.Threading.DispatcherUnhandledExceptionEventArgs e)
        {
            HandyControl.Controls.MessageBox.Fatal(e.Exception.Message, "Exception Occured");
        }
    }
}
