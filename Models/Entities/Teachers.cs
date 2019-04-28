using System;

namespace Models.Entities
{
    public class Teachers
    {
        public long Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Specialty { get; set; }
        public string Faculty { get; set; }

        public double Salary { get; set; }
        public DateTime Dob { get; set; }
    }
}
