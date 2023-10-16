using GenMax.Common;
using SqlSugar;
using System;

namespace GenMax.Database.EntityModel
{
    public class SampleBarcode
    {
        public int Id { get; set; }

        public string Barcode { get; set; }//条码
        public int SampleIndex { get; set; }//序号
        [SugarColumn(IsIgnore = true)]
        public ExperimentRecord ExperimentRecord { get; set; }//实验记录
        public DateTime CreatedDateTime { get; set; }//创建时间
        //public int Channel { get; set; }//样本通道
        public SampleType SampleType { get; set; }//样本类型
        public bool IsValid { get; set; } = true;//是否合格


        //public PatientInfo PatientInfo { get; set; }//实验记录
    }
}