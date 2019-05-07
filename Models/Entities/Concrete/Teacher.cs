using System;
using System.Collections.Generic;
using System.Text;
using Models.Entities.Abstract;

namespace Models.Entities.Concrete
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
        public override string ToString()
        {
            return string.Format(
                            "Id: {0}\tFirstName: {1}\tLastName: {2}\tFaculty: {3}\tSpecialty: {4}\tSalary: {5}\tDob: {6}",
                            Id, FirstName, LastName, Faculty, Specialty, Salary, Dob);
        }
    }
}
