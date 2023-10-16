using System;

namespace GenMax.Database.EntityModel
{
    public class BaseEntity
    {
        public int Id { get; set; }
        public DateTime CreatedDateTime { get; set; }//创建时间
    }
}
