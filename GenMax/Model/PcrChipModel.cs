using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.Generic;

namespace GenMax.Model
{
    public class PcrChipModel : ObservableObject
    {
        #region 声明实例
        private int _state = 0;

        public int State
        {
            get { return _state; }
            set
            {
                SetProperty(ref _state, value);
            }
        }

        private string _name;

        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
                SetProperty(ref _name, value);
            }
        }
        public List<PcrWellModel> WellList { get; } = new List<PcrWellModel>();
        public List<PcrWellModel> WellListFirst { get; } = new List<PcrWellModel>();
        public List<PcrWellModel> WellListSecond { get; } = new List<PcrWellModel>();
        #endregion

        #region 构造函数
        public PcrChipModel()
        {
            InitPcrChipStatus();
        }
        #endregion

        #region 方法
        /// <summary>
        /// 更新PcrChip状态
        /// </summary>
        /// <param name="pcrChipIndex"></param>
        /// <param name="isInitAll"></param>
        public void UpdatePcrChipStatus(int pcrChipIndex, bool isInitAll = false)
        {
            if (isInitAll)
            {
                for (int i = 0; i < 24; i++)
                {
                    WellList[i].IsUsed = false;
                }

                for (int i = 0; i < 12; i++)
                {
                    WellListFirst[i].IsUsed = false;
                    WellListSecond[i].IsUsed = false;
                }
            }
            else
            {
                if (pcrChipIndex > 12 - 1)
                    WellListFirst[pcrChipIndex - 12].IsUsed = true;
                else
                    WellListSecond[pcrChipIndex].IsUsed = true;
            }


        }

        private void InitPcrChipStatus()
        {
            WellList.Clear();
            WellListFirst.Clear();
            WellListSecond.Clear();
            for (int i = 0; i < 24; i++)
            {
                WellList.Add(new PcrWellModel() { Id = i, IsUsed = false });

            }

            for (int i = 0; i < 12; i++)
            {
                WellListFirst.Add(new PcrWellModel() { Id = i, Row = 0, IsUsed = false });
                WellListSecond.Add(new PcrWellModel() { Id = i, Row = 1, IsUsed = false });
            }
        }
        #endregion
    }
}
