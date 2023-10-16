using SqlSugar;
using System;
using System.Collections.Generic;

namespace GenMax.Database.EntityModel
{
    /// <summary>
    /// 项目信息
    /// </summary>
    public class Project
    {
        public int Id { get; set; }
        //public string Name { get; set; }    //项目名称
        private string name;
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public DateTime CreatedDateTime { get; set; }//创建时间
        public string UniqueIdentifier { get; set; }//唯一识别码

        public int PcrTube { get; set; }//PCR孔数

        public string ThresholdMethod { get; set; }//阈值方法
        //public double Threshold { get; set; }//阈值
        [SugarColumn(IsIgnore = true)]
        public List<Reagent> Reagents { get; set; }
        [SugarColumn(IsIgnore = true)]
        public Protocol Protocol { get; set; }
        [SugarColumn(IsIgnore = true)]
        public LinkedList<ExperimentRecord> ExperimentRecords { get; set; }
    }
}