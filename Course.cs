using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication2
{
        public class Courses
        {
            public int Id { get; set; }
            [Required]
            public string CourseName { get; set; }
            public string Sub1 { get; set; }
            public string Sub2 { get; set; }
            public string Sub3 { get; set; }

        }
}
