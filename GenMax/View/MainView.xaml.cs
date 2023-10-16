#region

using System.Windows;

#endregion

namespace GenMax.View;

public partial class MainView
{
    public MainView()
    {
        InitializeComponent();
    }

    private void Close(object sender, RoutedEventArgs e)
    {
        this.Close();
    }

    private void Minimize(object sender, RoutedEventArgs e)
    {
        this.Minimize();
    }
}