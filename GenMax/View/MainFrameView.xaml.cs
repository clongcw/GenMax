using GenMax.ViewModel;
using Microsoft.Extensions.DependencyInjection;
using System.Windows.Controls;

namespace GenMax.View
{
    /// <summary>
    /// MainFrameView.xaml 的交互逻辑
    /// </summary>
    public partial class MainFrameView : UserControl
    {
        public MainFrameView()
        {
            InitializeComponent();
            this.DataContext = App.Current._host.Services.GetRequiredService<MainFrameViewModel>();
        }
    }
}
