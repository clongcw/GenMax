using CommunityToolkit.Mvvm.ComponentModel;

namespace GenMax.Model
{
    public class PcrWellModel : ObservableObject
    {
        private int _id;

        public int Id
        {
            get { return _id; }
            set
            {
                SetProperty(ref _id, value);
            }
        }

        private int _state = 0;

        public int State
        {
            get { return _state; }
            set
            {
                SetProperty(ref _state, value);
            }
        }

        private bool _isUsed;
        private int _row;

        public bool IsUsed
        {
            get { return _isUsed; }
            set
            {
                if (_isUsed != value)
                {
                    SetProperty(ref _isUsed, value);
                }
            }
        }

        public int Row
        {
            get => _row;
            set
            {
                SetProperty(ref _row, value);
            }
        }
    }
}
