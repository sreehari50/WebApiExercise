using System;
using System.ComponentModel.DataAnnotations;

namespace WebApplication2
{
    public class Student
    {
        public int Id { get; set; } 

        [Required]
        [StringLength(255, ErrorMessage = "First name cannot be longer than  255 characters.")]
        public string FirstName { get; set; }

        
        [StringLength(25, ErrorMessage = "Second name cannot be longer than 25 characters.")]
        public string LastName { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime DateOfBirth { get; set; }


        [StringLength(2000, ErrorMessage = "Address cannot be longer than 2000 characters.")]
        public string Address { get; set; }

        [StringLength(10, ErrorMessage = "Phone number cannot be longer than 10 characters.")]
        public long PhoneNumber { get; set; }

        public string Course { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime EnrolmentDate { get; set; }

    }
}