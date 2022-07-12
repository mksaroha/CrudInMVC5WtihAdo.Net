using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CrudWithAdo.Repository;
using CrudWithAdo.Models;

namespace CrudWithAdo.Controllers
{
    public class StudentController : Controller
    {
        StudentRepository repo = new StudentRepository();
        // GET: Student
        public ActionResult Index()
        {
            var allStudent = repo.GetAllStudent();
            return View(allStudent);
        }

        public ActionResult Create()
        {
            ViewBag.CourseList = repo.GetAllCourses();
            return View();
        }

        [HttpPost]
        public ActionResult Create(Student student /*string name,string city,int courseid*/)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            else
            {
                bool result = repo.AddStudent(student);
                if(result==true)
                {
                    return RedirectToAction("Index");
                }
            }
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            //var student = repo.GetAllStudent().Find(x => x.Id == id);
            //here we need to return view as studentmodel model 
            var student = repo.GetStudentById(id);
            //Now we can return view as student  model
            ViewBag.CourseList = repo.GetAllCourses();
            return View(student);
        }

        [HttpPost]
        public ActionResult Edit(int id,string name,string city,int courseid)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            else
            {
                bool result = repo.UpdateStudent(id,name,city,courseid);
                if (result == true)
                {
                    return RedirectToAction("Index");
                }
            }
            return RedirectToAction("Index");            
        }

        public ActionResult Details(int id)
        {
            var student = repo.GetAllStudent().Find(x => x.Id == id);
            return View(student);
            //here i return studentmodel model but after creating getstudetbyid function in repo i can 
            // return student model to view.
        }

        public ActionResult Delete(int id)
        {
            bool result = repo.DeleteStudent(id);
            return RedirectToAction("Index");
        }        
    }
}