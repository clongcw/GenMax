using SqlSugar;
using System;
using System.Collections.Generic;

namespace GenMax.Database.EntityModel
{
    public class ExperimentRecord
    {
        public int Id { get; set; }
        [SugarColumn(IsIgnore = true)]
        public Project Project { get; set; }//项目
        //public User User { get; set; }  //用户
        public string OperatorName { get; set; }//操作人员
        public string ExperimentName { get; set; }//实验名称
        public bool IsFinished { get; set; } = false;//是否完成
        public string Channel { get; set; } = "0";//通道名称
        [SugarColumn(IsIgnore = true)]
        public List<SampleBarcode> SampleBarcodes { get; set; }//样本条码
        //public string SampleType { get; set; }//样本类型
        public DateTime CreatedDateTime { get; set; }//创建时间
    }
}