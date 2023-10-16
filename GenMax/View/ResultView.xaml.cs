using GenMax.ViewModel;
using Microsoft.Extensions.DependencyInjection;
using System.Windows.Controls;

namespace GenMax.View
{
    /// <summary>
    /// ResultView.xaml 的交互逻辑
    /// </summary>
    public partial class ResultView : UserControl
    {
        public ResultView()
        {
            InitializeComponent();
            this.DataContext = App.Current._host.Services.GetRequiredService<ResultViewModel>();
        }
    }
}
