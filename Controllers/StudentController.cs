using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace WebApplication2.Controllers
{
    [ApiController]
    public class StudentController : ControllerBase
    {
        private static List<Student> _student = new List<Student>();

        private static List<Courses> _course = new List<Courses>();

        [HttpPost("api/students")]
        public IActionResult CreateStudent(StudentCreationDto student)
        {
            var lastStudent = _student.OrderByDescending(x => x.Id).LastOrDefault();

            int id = lastStudent == null ? 1 : lastStudent.Id + 1;
            bool flag = false;

            foreach (var course in _course)
            {
                if (student.Course == course.CourseName)
                {
                    flag = true;
                }
            }
            if (flag == false)
            {
                return Conflict("Course is Not is list");
            }
            if (Convert.ToDateTime(student.DateOfBirth) > DateTime.Now)
            {
                return Conflict("enter a valid date");
            }
            if (Convert.ToDateTime(student.EnrolmentDate) > DateTime.Now)
            {
                return Conflict("enter a valid date");
            }


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

        [HttpPut("api/students/{id}")]
        public IActionResult Put(StudenteDetailsDto student, int id)
        {
            var existingStudent = _student.FirstOrDefault(x => x.Id == id);

            if (existingStudent != null)
            {
                existingStudent.FirstName = student.FirstName;
                existingStudent.LastName = student.LastName;
                existingStudent.DateOfBirth = student.DateOfBirth;
                existingStudent.Address = student.Address;
                existingStudent.PhoneNumber = student.PhoneNumber;
                existingStudent.Course = student.Course;
                existingStudent.EnrolmentDate = student.EnrolmentDate;
                return Ok(_student);



            }
            else
            {
                return NotFound();

            }
        }
        
        [HttpDelete("api/students/{id}")]
        public IActionResult Delete(int id)
        {
            foreach (var entity in _student)
            {
                if (entity.Id == id)
                {
                    _student.Remove(entity);
                    return Ok();
                }
            }
            return NotFound();


        }

        

        [HttpGet("api/courses")]
        public IActionResult GetCourseDetails()
        {
            return Ok(_course);
        }
        [HttpPost("api/courses")]
        public IActionResult CreateCourse(Courses courses)
        {
            var lastCourse = _course.OrderByDescending(x => x.Id).LastOrDefault();

            int id = lastCourse == null ? 1 : lastCourse.Id + 1;

            var courseToBeAdded = new Courses
            {
                Id = id,
                CourseName = courses.CourseName,
                Sub1 = courses.Sub1,
                Sub2 = courses.Sub2,
                Sub3 = courses.Sub3
            };

            _course.Add(courseToBeAdded);
            return Ok(courseToBeAdded.Id);
        }
        [HttpGet("api/courses/{id}")]
        public IActionResult GetCourseId(int id)
        {
            var course = _course.SingleOrDefault(x => x.Id == id);

            if (course == null)
                return NotFound();

            return Ok(new Courses
            {
                Id = id,
                CourseName = course.CourseName,
                Sub1 = course.Sub1,
                Sub2 = course.Sub2,
                Sub3 = course.Sub3
            });
        }

        [HttpPut("api/courses/{id}")]
        public IActionResult PutCourse(Courses course, int id)
        {
            var existingCourse = _course.FirstOrDefault(x => x.Id == id);

            if (existingCourse != null)
            {
                existingCourse.CourseName = course.CourseName;
                existingCourse.Sub1 = course.Sub1;
                existingCourse.Sub2 = course.Sub2;
                existingCourse.Sub3 = course.Sub3;
                
                return Ok(_course);

            }
            else
            {
                return NotFound();

            }
        }

        [HttpGet("api/courses/details")]
        public IActionResult GetCourseListDetails()
        {
            var courselist = from C in _course 
                             join S in _student on   C.CourseName equals S.Course into CS
                             from a in CS.DefaultIfEmpty()
                             group a by C.CourseName into g
                             select new { CourseName = g.Key, Student_Count = g.Count(S => S!= null) };

            return Ok(courselist);
        }

        [HttpDelete("api/courses/{id}")]
        public IActionResult DeleteCourse(int id)
        {
            foreach (var entity in _course)
            {
                if (entity.Id == id)
                {
                    _course.Remove(entity);
                    return Ok();
                }
            }
            return NotFound();


        }



    }
}
