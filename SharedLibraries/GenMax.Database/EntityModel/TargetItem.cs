using SqlSugar;
using System;

namespace GenMax.Database.EntityModel
{
    /// <summary>
    /// 检测靶标信息
    /// </summary>
    public class TargetItem
    {
        public int Id { get; set; }
        public string TargetName { get; set; }//检测靶标名称
        public string Reporter { get; set; }//荧光染料名称
        public DateTime CreatedDateTime { get; set; }//创建时间
        public string DetectionTarget { get; set; }//检测靶标,无效
        public double JudgmentValue { get; set; }//检测结果判断值
        [SugarColumn(IsIgnore = true)]
        public Reagent Reagent { get; set; }
        public double Threshold { get; set; }//阈值

    }
}