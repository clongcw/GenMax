using SqlSugar;

namespace GenMax.Database.EntityModel
{
    [SugarTable("ExtractMixParameters")]
    public class ExtractMixParameter
    {
        public int Id { get; set; }
        [SugarColumn(IsIgnore = true)]
        public Step Step { get; set; }

        private int _mixTime = 5;
        /// <summary>
        /// 混匀时间
        /// </summary>
        public int MixTime
        {
            get => _mixTime;
            set
            {
                _mixTime = value;
            }
        }

        private int _mixSpeed = 95;
        /// <summary>
        /// 混匀速度
        /// </summary>
        public int MixSpeed
        {
            get => _mixSpeed;
            set
            {
                _mixSpeed = value;
            }
        }
    }
}