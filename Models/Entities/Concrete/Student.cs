using System;
using System.Collections.Generic;
using System.Text;
using Models.Entities.Abstract;

namespace Models.Entities.Concrete
{
    public class Student : IEntity
    {
        public long Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Faculty { get; set; }
        public double Scholarship { get; set; }
        public DateTime Dob { get; set; }
        public override string ToString()
        {
            return string.Format(
                            "Id: {0}\tFirstName: {1}\tLastName: {2}\tFaculty: {3}\tScholarship: {4}\tDob: {5}",
                            Id, FirstName, LastName, Faculty, Scholarship, Dob);
        }
    }
}
