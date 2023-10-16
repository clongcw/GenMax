using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using GenMax.Log;
using GenMax.Util;
using GenMax.View;
using Microsoft.Extensions.DependencyInjection;
using System.Windows.Controls;

namespace GenMax.ViewModel;

public partial class MainViewModel : ObservableObject
{
    [ObservableProperty] private string _title;
    [ObservableProperty] private ILog _logger;
    [ObservableProperty] private object _content;

    public MainViewModel()
    {
        Title = "GenMax调试工具";
        Logger = LogService.Instance;

        Content = App.Current._host.Services.GetService<MainFrameView>();
    }

    [RelayCommand]
    public void SelectionChangedTop(object listboxitem)
    {
        var viewname = string.Empty;

        if (listboxitem as ListBoxItem != null)
        {
            var textBlock = WPFUtil.FindVisualChild<TextBlock>(listboxitem as ListBoxItem);
            if (textBlock != null)
            {
                viewname = textBlock.Text;
            }
        }

        switch (viewname)
        {
            case "主页":
                Content = App.Current._host.Services.GetService<MainFrameView>();
                break;
            case "结果查询":
                Content = App.Current._host.Services.GetService<ResultView>();
                break;
            default:
                break;
        }
    }


    [RelayCommand]
    public void SelectionChangedBottom(object listboxitem)
    {
        var viewname = string.Empty;

        if (listboxitem as ListBoxItem != null)
        {
            var textBlock = WPFUtil.FindVisualChild<TextBlock>(listboxitem as ListBoxItem);
            if (textBlock != null)
            {
                viewname = textBlock.Text;
            }
        }

        switch (viewname)
        {
            case "结果查询":
                Content = App.Current._host.Services.GetService<ResultView>();
                break;
            default:
                break;
        }
    }

}