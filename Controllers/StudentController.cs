using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace WebApplication2.Controllers
{
    [ApiController]
    public class StudentController : ControllerBase
    {
        private static List<Student> _student = new List<Student>();

        [HttpPost("api/students")]
        public IActionResult CreateStudent(StudentCreationDto student)
        {
            var lastStudent = _student.OrderByDescending(x => x.Id).LastOrDefault();

            int id = lastStudent == null ? 1 : lastStudent.Id + 1;

            var studentToBeAdded = new Student
            {
                Id = id,
                FirstName = student.FirstName,
                LastName = student.LastName,
                DateOfBirth = student.DateOfBirth,
                Address = student.Address,
                Course = student.Course,
                PhoneNumber = student.PhoneNumber,
                EnrolmentDate = student.EnrolmentDate
            };

            _student.Add(studentToBeAdded);
            return Ok(studentToBeAdded.Id);
        }

        [HttpGet("api/students")]
        public IActionResult GetStudents()
        {
            return Ok(_student);
        }

        [HttpGet("api/students/{id}")]
        public IActionResult GetStudentId(int id)
        {
            var student = _student.SingleOrDefault(x => x.Id == id);

            if (student == null)
                return NotFound();

            return Ok(new StudenteDetailsDto
            {
                Id = student.Id,
                FirstName = student.FirstName,
                LastName = student.LastName,
                DateOfBirth = student.DateOfBirth,
                Address = student.Address,
                Course = student.Course,
                PhoneNumber = student.PhoneNumber,
                EnrolmentDate = student.EnrolmentDate
            });
        }

        /*[HttpPut("api/students/{id}")]
        public IActionResult EditStudent(StudenteDetailsDto student)
        {
            var existingStudent = _student.Where(s => s.Id == student.Id).FirstOrDefault<Student>();

            if (existingStudent != null)
            {
                existingStudent.FirstName = student.FirstName;
                existingStudent.LastName = student.LastName;


            }
            else
            {
                return NotFound();

            }

        }*/
    }
}