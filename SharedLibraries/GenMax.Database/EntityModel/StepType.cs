using System.ComponentModel;

namespace GenMax.Database.EntityModel
{
    public enum StepType
    {
        [Description("移液")]
        Pipptte,

        [Description("取磁套")]
        LoadCover,
        [Description("打磁套")]
        EjectCover,

        [Description("加样")]
        AddSmp,
        [Description("吸取磁珠")]
        ExtractBeads,
        [Description("分配模板")]
        TransferTemplate,
        [Description("戳膜")]
        Prick,
        [Description("转移至芯片")]
        TransToChip,
        [Description("PCR")]
        Pcr,
    }
}