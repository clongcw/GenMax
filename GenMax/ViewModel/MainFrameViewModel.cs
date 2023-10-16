using CommunityToolkit.Mvvm.ComponentModel;
using GenMax.Model;
using System.Collections.ObjectModel;

namespace GenMax.ViewModel
{
    public partial class MainFrameViewModel : ObservableObject
    {
        [ObservableProperty] private ObservableCollection<ChannelCtrlViewModel> _channelCtrls;
        [ObservableProperty] private ObservableCollection<PcrStateViewModel> _pcrStates;
        [ObservableProperty] private ObservableCollection<ChannelOptViewModel> _channelOpts;
        [ObservableProperty] private TipBoxHViewModel _tipBoxHViewModel0 = new TipBoxHViewModel();
        [ObservableProperty] private TipBoxHViewModel _tipBoxHViewModel1 = new TipBoxHViewModel();
        [ObservableProperty] private PcrChipModel _pcrChipModel = new PcrChipModel();
        public MainFrameViewModel()
        {
            ChannelCtrls = new ObservableCollection<ChannelCtrlViewModel>();
            PcrStates = new ObservableCollection<PcrStateViewModel>();
            ChannelOpts = new ObservableCollection<ChannelOptViewModel>();


            for (int i = 0; i < 4; i++)
            {
                ChannelCtrls.Add(new ChannelCtrlViewModel() { MpIndex = i });
                PcrStates.Add(new PcrStateViewModel() { MpIndex = i });
                //optView.OptCommand = null;
                ChannelOpts.Add(new ChannelOptViewModel() { MpIndex = i });
            }
        }
    }
}
