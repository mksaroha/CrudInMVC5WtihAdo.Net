using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CrudWithAdo.Models
{
    public class StudentModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string City { get; set; }     
        public string CourseId { get; set; }  
        public string CourseName { get; set; }
    }
}