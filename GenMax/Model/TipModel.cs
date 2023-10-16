using CommunityToolkit.Mvvm.ComponentModel;

namespace GenMax.Model
{
    public class TipModel : ObservableObject
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

        private bool _isUsed;

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

        private bool _isValid;
        public bool IsValid
        {
            get { return _isValid; }
            set
            {
                if (_isValid != value)
                {
                    SetProperty(ref _isValid, value);
                }
            }
        }

        public TipModel(int id)
        {
            Id = id;
            IsUsed = false;
            IsValid = true;
        }
    }
}
