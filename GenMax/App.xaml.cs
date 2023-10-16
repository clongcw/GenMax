#region

using GenMax.HostBuilder;
using GenMax.View;
using GenMax.ViewModel;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Windows;

#endregion

namespace GenMax
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public new static App? Current => Application.Current as App;

        public readonly IHost _host;

        public App()
        {
            _host = CreateHostBuilder().Build();
        }

        public static IHostBuilder CreateHostBuilder(string[] args = null)
        {
            return Host.CreateDefaultBuilder(args)
                .AddDbContext()
                .AddServices()
                .AddViewModels()
                .AddViews();
        }

        private void Application_Startup(object sender, StartupEventArgs e)
        {
            _host.Start();

            var loginView = _host.Services.GetRequiredService<LoginView>();
            loginView.DataContext = _host.Services.GetRequiredService<LoginViewModel>();
            loginView!.Show();




            //切换到excel转exp文件选这个
            /*XlsxToExpView mainView = App.Current._host.Services.GetRequiredService<XlsxToExpView>();
            mainView.DataContext = App.Current._host.Services.GetRequiredService<XlsxToExpViewModel>();
            mainView!.Show();*/



        }
    }
}