using System;
using System.Collections.Generic;
using System.Text;
using Models.Entities.Abstract;

namespace Models.Entities.Concrete
{
    public class Faculty : IEntity
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public override string ToString()
        {
            return string.Format(
                            "Id: {0}\tName: {1}\tDescription: {2}",
                            Id, Name, Description);
        }
    }
}
