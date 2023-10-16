using SqlSugar;
using System;
using System.Collections.Generic;

namespace GenMax.Database.EntityModel
{
    [SugarTable("Protocols")]
    public class Protocol
    {

        public int Id { get; set; }

        public string Name { get; set; }

        public string Version { get; set; }

        public DateTime CreateDateTime { get; set; }
        [SugarColumn(IsIgnore = true)]
        public List<Step> Steps { get; set; }
        [SugarColumn(IsIgnore = true)]
        public Project Project { get; set; }
        public int ProjectId { get; set; }
        [SugarColumn(IsIgnore = true)]
        public int StartSequence { get; set; }

        public int PcrTempCount { get; set; } = 1;

        public string Token { get; set; }
        public string PcrTemplateFile { get; set; }

        [SugarColumn(IsIgnore = true)]
        public bool IsManualAddSmp { get; set; }

        [SugarColumn(IsIgnore = true)]
        public List<Sample> SmpList { get; set; }

        [SugarColumn(IsIgnore = true)]
        public int ExcuteResult { get; set; }

        [SugarColumn(IsIgnore = true)]
        public int Channel { get; set; }

    }
}
