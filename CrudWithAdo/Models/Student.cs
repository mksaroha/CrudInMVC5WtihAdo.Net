using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CrudWithAdo.Models
{
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
        public int CourseId { get; set; } 
        public virtual Course Course { get; set; }
    }
}