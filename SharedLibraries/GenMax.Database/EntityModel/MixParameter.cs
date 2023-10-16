using SqlSugar;

namespace GenMax.Database.EntityModel
{
    /// <summary>
    /// ADP混匀
    /// </summary>
    [SugarTable("MixParameters")]
    public class MixParameter
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int Times { get; set; } = 5;

        public double Volume { get; set; } = 100;

        public double AspirateDepth { get; set; } = 28;//吸液深度

        public double DispenseDepth { get; set; } = 23;//排液深度

        public bool IsMixAfterDis { get; set; } = true;
        [SugarColumn(IsIgnore = true)]
        public Step Step { get; set; }

        [SugarColumn(IsIgnore = true)]
        public double DispenseOffsetY { get; set; } = 5;
    }
}