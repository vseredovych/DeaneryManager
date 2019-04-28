using System;

namespace Models.Entities
{
    public class Students
    {
        public long Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Faculty{ get; set; }
        public string Scholarship { get; set; }
        public DateTime Dob { get; set; }
    }
}
