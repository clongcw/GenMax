using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using GenMax.Model;
using System.Collections.Generic;

namespace GenMax.ViewModel
{
    public class TipBoxHViewModel : ObservableObject
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

        private int _tipType = 2;
        public int TipType
        {
            get { return _tipType; }
            set
            {
                SetProperty(ref _tipType, value);
            }
        }

        private string _name = "175";

        public string Name
        {
            get { return _name; }
            set
            {
                SetProperty(ref _name, value);
            }
        }

        private bool _isEmpty = true;

        public bool IsEmpty
        {
            get { return _isEmpty; }
            set
            {
                SetProperty(ref _isEmpty, value);
            }
        }

        private bool _isLoaded = false;

        public bool IsLoaded
        {
            get { return _isLoaded; }
            set
            {
                SetProperty(ref _isLoaded, value);
            }
        }

        private int _rowCount = 8;

        public int RowCount
        {
            get { return _rowCount; }
            set
            {
                SetProperty(ref _rowCount, value);
            }
        }

        private int _colCount = 12;

        public int ColCount
        {
            get { return _colCount; }
            set
            {
                SetProperty(ref _colCount, value);
            }
        }

        public List<TipModel> TipModels { get; } = new List<TipModel>();

        public TipBoxHViewModel()
        {
            for (int i = 0; i < RowCount * ColCount; i++)
            {
                TipModels.Add(new TipModel(i));
            }
        }

        public RelayCommand<int> RefreshCommand { get; set; }

        #region 方法
        public void UpdateTipState(int TipBoxId, int TipId)
        {
            TipModels.Find(p => p.Id == TipId).IsUsed = true;
        }

        /// <summary>
        /// 更新Tip盒子装满
        /// </summary>
        /// <param name="TipId"></param>
        public void UpdateTipState(int TipId)
        {
            TipModels.Find(p => p.Id == TipId).IsUsed = false;
        }
        #endregion
    }
}
