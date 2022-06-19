using System;

namespace Week17.Domain
{
    public class Person
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public DateTime CreateDate { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string JobPosition { get; set; }
        public double Salary { get; set; }
        public double WorkExperince { get; set; }
        public Address PersonAddress { get; set; }
        public string Role { get; set; }
        public string Token { get; set; }
    }


}
