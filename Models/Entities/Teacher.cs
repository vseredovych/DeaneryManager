using System;
using System.Collections.Generic;

namespace Models.Entities
{
    public class Teacher : IEntity
    {
        public long Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Faculty { get; set; }
        public string Specialty { get; set; }
        public double Salary { get; set; }
        public DateTime Dob { get; set; }
        public List<string> GetObjectList()
        {
            List<string> objects = new List<string>();
            objects.Add(Convert.ToString(Id));
            objects.Add(Convert.ToString(FirstName));
            objects.Add(Convert.ToString(LastName));
            objects.Add(Convert.ToString(Faculty));
            objects.Add(Convert.ToString(Specialty));
            objects.Add(Convert.ToString(Salary));
            objects.Add(Convert.ToString(Dob));
            return objects;
        }
    }
}
