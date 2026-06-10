using lab13_rpm.Data;
using lab13_rpm.ViewModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Windows;


namespace lab13_rpm
{
    public partial class App : Application
    {
        private readonly IHost _host;

        public App()
        {
            _host = Host.CreateDefaultBuilder()
                .ConfigureServices((context, services) =>
                {
                    string connectionString =
                        "Server=DESKTOP-0RTRFU5;Database=PhoneBookDB_Lab_12_Mitanov_DV_2407CA1;Trusted_Connection=True;TrustServerCertificate=True;";

                    services.AddDbContext<ApplicationContext>(
                        options =>
                        {
                            options.UseSqlServer(connectionString);
                        },
                        contextLifetime: ServiceLifetime.Transient);

                    services.AddTransient<ContactEditViewModel>();
                    services.AddTransient<ContactsListViewModel>();
                    services.AddTransient<MainWindow>();
                })
                .Build();
        }

        protected override async void OnStartup(StartupEventArgs e)
        {
            await _host.StartAsync();

            MainWindow mainWindow = _host.Services.GetRequiredService<MainWindow>();
            mainWindow.Show();

            base.OnStartup(e);
        }

        protected override async void OnExit(ExitEventArgs e)
        {
            await _host.StopAsync();
            _host.Dispose();

            base.OnExit(e);
        }
    }

}
