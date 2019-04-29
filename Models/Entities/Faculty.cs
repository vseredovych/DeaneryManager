using System;
using System.Collections.Generic;

namespace Models.Entities
{
    public class Faculty : IEntity
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<string> GetObjectList()
        {
            List<string> objects = new List<string>();
            objects.Add(Convert.ToString(Id));
            objects.Add(Convert.ToString(Name));
            objects.Add(Convert.ToString(Description));
            return objects;
        }
    }
}