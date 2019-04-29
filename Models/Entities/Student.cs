using System;
using System.Collections.Generic;

namespace Models.Entities
{
    public class Student : IEntity
    {
        public long Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Faculty{ get; set; }
        public double Scholarship { get; set; }
        public DateTime Dob { get; set; }
        public List<string> GetObjectList()
        {
            List<string> objects = new List<string>();
            objects.Add(Convert.ToString(Id));
            objects.Add(Convert.ToString(FirstName));
            objects.Add(Convert.ToString(LastName));
            objects.Add(Convert.ToString(Faculty));
            objects.Add(Convert.ToString(Scholarship));
            objects.Add(Convert.ToString(Dob));
            return objects;
        }
    }
}
