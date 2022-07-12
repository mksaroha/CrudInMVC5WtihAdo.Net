using System.Collections.Generic;
using System.Data.SqlClient;
using System.Web.Configuration;
using System.Data;
using CrudWithAdo.Models;
using System;

namespace CrudWithAdo.Repository
{
    public class StudentRepository
    {
        SqlConnection con = new SqlConnection(WebConfigurationManager.ConnectionStrings["Connect"].ConnectionString);

        public List<StudentModel> GetAllStudent()
        {           
            SqlCommand cmd = new SqlCommand("UDP_GetStudents",con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter dap = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            con.Open();
            dap.Fill(dt);
            con.Close();
            List<StudentModel> allStudents = new List<StudentModel>();
            foreach(DataRow dr in dt.Rows)
            {
                allStudents.Add(new StudentModel
                {
                    Id = Convert.ToInt32(dr["Id"]),
                    Name = Convert.ToString(dr["Name"]),
                    City = Convert.ToString(dr["City"]),
                    CourseName = Convert.ToString(dr["CourseName"])
                });
            }

            return allStudents;
			
			
			//List<Emplyee> employeeList = new List<Emplyee>();  
   //         string CS = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;  
   //         using (SqlConnection con = new SqlConnection(CS))  
   //         {  
   //             SqlCommand cmd = new SqlCommand("SELECT * FROM Employees", con);  
   //             cmd.CommandType = CommandType.Text;  
   //             con.Open();  
   
   //             SqlDataReader rdr = cmd.ExecuteReader();  
   //             while (rdr.Read())  
   //             {  
   //                 var employee = new Emplyee();  
   
   //                 employee.EmployeeId = Convert.ToInt32(rdr["EmployeeId"]);  
   //                 employee.Name = rdr["Name"].ToString();  
   //                 employee.Gender = rdr["Gender"].ToString();  
   //                 employee.Age = Convert.ToInt32(rdr["Age"]);  
   //                 employee.Position = rdr["Position"].ToString();  
   //                 employee.Office = rdr["Office"].ToString();  
   //                 employee.HireDate =Convert.ToDateTime(rdr["HireDate"]);  
   //                 employee.Salary = Convert.ToInt32(rdr["Salary"]);  
   //                 employeeList.Add(employee);  
   //             }  
   //         }  
   //         return View(employeeList);   

        }

        public Student GetStudentById(int id)
        {
            SqlCommand cmd = new SqlCommand("UDP_GetStudent", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@id", id);
            SqlDataAdapter dap = new SqlDataAdapter(cmd);
            //DataTable dt = new DataTable();
            DataSet ds = new DataSet();
            con.Open();
            dap.Fill(ds);
            con.Close();

            Student sobj = new Student();
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)            {
                
                sobj.Id = Convert.ToInt32(ds.Tables[0].Rows[i]["Id"].ToString());
                sobj.Name = ds.Tables[0].Rows[i]["Name"].ToString();
                sobj.City = ds.Tables[0].Rows[i]["City"].ToString();
                sobj.CourseId =Convert.ToInt32(ds.Tables[0].Rows[i]["CourseId"].ToString());
                //sobj.EmailID = ds.Tables[0].Rows[i]["EmailID"].ToString();
                //cobj.Birthdate = Convert.ToDateTime(ds.Tables[0].Rows[i]["Birthdate"].ToString());
            }
            return sobj;
        }

        public List<Course> GetAllCourses()
        {            
            SqlCommand cmd = new SqlCommand("UDP_GetCourse", con);
            cmd.CommandType = CommandType.StoredProcedure;            
            SqlDataAdapter dap = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            con.Open();
            dap.Fill(dt);
            con.Close();
            List<Course> allCourses = new List<Course>();
            foreach(DataRow dr in dt.Rows)
            {
                allCourses.Add(new Course {
                    CourseId = Convert.ToInt32(dr["CourseId"]),
                    CourseName=Convert.ToString(dr["CourseName"])
                });
            }
            return allCourses;
        }

        public bool AddStudent(Student student/*string name,string city,string courseid*/)
        {            
            SqlCommand cmd = new SqlCommand("UDP_AddStudent", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@name", student.Name);
            cmd.Parameters.AddWithValue("@city", student.City);
            cmd.Parameters.AddWithValue("@courseid", student.CourseId);
            con.Open();
            int res = cmd.ExecuteNonQuery();
            con.Close();
            if (res >= 1)
                 return true;
            else
                return false;
        }

        public bool UpdateStudent(int id,string name, string city, int courseid)
        {            
            SqlCommand cmd = new SqlCommand("UDP_UpdateStudent", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@id", id);
            cmd.Parameters.AddWithValue("@name", name);
            cmd.Parameters.AddWithValue("@city", city);
            cmd.Parameters.AddWithValue("@courseid", courseid);
            con.Open();
            int res = cmd.ExecuteNonQuery();
            con.Close();
            if (res >=1)
                return true;
            else
                return false;
        }

        public bool DeleteStudent(int id)
        {            
            SqlCommand cmd = new SqlCommand("UDP_DeleteStudent", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@id", id);
            con.Open();
            int res=cmd.ExecuteNonQuery();
            con.Close();
            if (res >= 1)
                return true;
            else
                return false;
        }
    }
}