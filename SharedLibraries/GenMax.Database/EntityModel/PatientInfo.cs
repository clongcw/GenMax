using System;

namespace GenMax.Database.EntityModel
{
    public class PatientInfo : BaseEntity
    {
        public string PatientName { get; set; }//患者姓名
        public string Gender { get; set; }//性别

        //public SampleBarcode Sample { get; set; }//样本信息
        public int SampleId { get; set; }
        public int Age { get; set; }//年龄


        public string SampleType { get; set; }  //样本类型

        public DateTime SampingDateTime { get; set; } = DateTime.Now.AddDays(-365);//送检日期

        public string InspectionDoctor { get; set; }//送检医生
        public string Auditor { get; set; }//审核人员
        public string InspectionDepartment { get; set; }//送检部门

        public string CaseNumber { get; set; }//病历号

        public string Notes { get; set; }//备注
    }
}
