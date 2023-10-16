using SqlSugar;
using System;
using System.Collections.Generic;

namespace GenMax.Database.EntityModel
{
    /// <summary>
    /// 试剂信息
    /// </summary>
    public class Reagent
    {
        public int Id { get; set; }
        public string Name { get; set; }//试剂名称
        public DateTime CreatedDateTime { get; set; }//创建时间
        public int TubeLocation { get; set; }//反应孔位置index
        public int ExpiryDate { get; set; }//有效期，单位年

        public string InternalReference { get; set; }//内参
        [SugarColumn(IsIgnore = true)]
        public List<TargetItem> DyeInfos { get; set; }
        [SugarColumn(IsIgnore = true)]
        public Project Project { get; set; }

    }
}