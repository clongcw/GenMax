using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using GenMax.Common;
using GenMax.Log;
using GenMax.View;
using System.Threading.Tasks;

namespace GenMax.ViewModel
{
    public partial class ChannelOptViewModel : ObservableObject
    {
        #region Property
        [ObservableProperty] private ILog _logger;

        private int _groupId = 0;
        private int _mpIndex = 0;

        public int MpIndex
        {
            get { return _mpIndex; }
            set
            {
                SetProperty(ref _mpIndex, value);
            }
        }

        private bool _isInputed = false;

        public bool IsInputed
        {
            get { return _isInputed; }
            set
            {
                SetProperty(ref _isInputed, value);
            }
        }

        /// <summary>
        /// 运行/暂停
        /// </summary>
        private bool _state = false;

        public bool State
        {
            get { return _state; }
            set
            {
                SetProperty(ref _state, value);
            }
        }


        /// <summary>
        /// 运行/暂停
        /// </summary>
        /// 
        //[ObservableProperty] private bool _isPause = false;
        private bool _isPause = false;

        public bool IsPause
        {
            get { return _isPause; }
            set
            {
                SetProperty(ref _isPause, value);
            }
        }

        private bool _isInit = false;

        public bool IsInit
        {
            get { return _isInit; }
            set
            {
                SetProperty(ref _isInit, value);
            }
        }

        private int _totalTipCount = 0;

        public int TotalTipCount
        {
            get { return _totalTipCount; }
            set
            {
                SetProperty(ref _totalTipCount, value);
            }
        }
        #endregion

        #region Command
        [RelayCommand]
        public async Task Input()
        {
            SingleInputView singleInputView = new SingleInputView();
            singleInputView.DataContext = new SingleInputViewModel((Channels)1);
            singleInputView.Show();
        }

        //[RelayCommand(CanExecute = nameof(CanExcuteOpt))]
        [RelayCommand]
        public async Task Opt()
        {
            IsPause = !IsPause;
        }

        private bool CanExcuteOpt() => IsInputed & IsInit;


        #endregion

        public ChannelOptViewModel()
        {
            Logger = LogService.Instance;
        }
    }
}
