namespace GenMax.Database.EntityModel
{
    public class Sample
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public int Channel { get; set; }
        public int SubId { get; set; }
        public int SmpType { get; set; } = 4;
        public int ContainerType { get; set; }
        public bool IsValid { get; set; } = true;
    }
}