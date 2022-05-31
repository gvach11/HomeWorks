using System;

namespace Week14
{
    public class Person
    {
        internal DateTime CreateDate { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string JobPosition { get; set; }
        public double Salary { get; set; }
        public double WorkExperince { get; set; }
        public Address PersonAddress { get; set; }
    }

    public class Address
    {
        public string City { get; set; }
        public string Country { get; set; }
        public int HomeNumber { get; set; }
    }
}
