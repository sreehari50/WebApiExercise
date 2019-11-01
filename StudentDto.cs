using System;

namespace WebApplication2.Controllers
{
    public class StudentCreationDto
    {

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Address { get; set; }
        public long PhoneNumber { get; set; }
        public string Course { get; set; }
        public DateTime EnrolmentDate { get; set; }
    }
}