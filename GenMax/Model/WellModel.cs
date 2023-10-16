using CommunityToolkit.Mvvm.ComponentModel;

namespace GenMax.Model
{
    public class WellModel : ObservableObject
    {
        private int _id = 0;

        public int Id
        {
            get { return _id; }
            set
            {
                SetProperty(ref _id, value);
            }
        }

        private int _wellType = 0;

        public int WellType
        {
            get { return _wellType; }
            set
            {
                SetProperty(ref _wellType, value);
            }
        }

        private string _name;

        public string Name
        {
            get { return _name; }
            set
            {
                SetProperty(ref _name, value);
            }
        }

        //private string _engName;

        //public string EnglishName
        //{
        //    get { return _engName; }
        //    set
        //    {
        //        _engName = value;
        //        RaisePropertyChanged(() => EnglishName);
        //    }
        //}

        private int _state = 0;

        public int State
        {
            get { return _state; }
            set
            {
                SetProperty(ref _state, value);
            }
        }

        private bool _isCurrent = false;

        public bool IsCurrent
        {
            get { return _isCurrent; }
            set
            {
                SetProperty(ref _isCurrent, value);
            }
        }
    }

    public enum WellType
    {
        Reagent = 0,
        Ext,
        Tip,
        IC,
        Waste,
        Temp,
        Smp
    }
}
