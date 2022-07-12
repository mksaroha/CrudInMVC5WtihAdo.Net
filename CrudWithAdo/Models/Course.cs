using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CrudWithAdo.Models
{
    public class Course
    {
        public int CourseId { get; set; }
        public string CourseName { get; set; }
        public virtual ICollection<Student> Student { get; set; }
    }
}