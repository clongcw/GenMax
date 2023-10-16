using MahApps.Metro.Controls;
using System.Windows;

namespace GenMax.View
{
    /// <summary>
    /// SingleInputView.xaml 的交互逻辑
    /// </summary>
    public partial class SingleInputView : MetroWindow
    {
        public SingleInputView()
        {
            InitializeComponent();
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
