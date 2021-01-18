using Lab6.App_Start;
using Lab6.Models;
using System;
using System.Web.Mvc;

namespace Lab6.Controllers
{
    public class TeacherController : Controller
    {
        Context context = new Context();
        public ActionResult Index()
        {
            return View(context);
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            Teacher c = new Teacher { id = id };
            context.Teacher.Attach(c);
            context.Teacher.Remove(c);
            context.SaveChanges();

            return RedirectToAction("Index", "Teacher");
        }

        [HttpGet]
        public ActionResult AddTeacher()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddTeacher(Teacher item)
        {
            context.Teacher.Add(item);
            context.SaveChanges();

            return RedirectToAction("Index", "Teacher");
        }

        public ActionResult Update(FormCollection form)
        {
            var idString = Request.Form["id"];
            var firstName = Request.Form["first_name"];
            var lastName = Request.Form["last_name"];
            var gender = Request.Form["gender"];
            var ageString = Request.Form["age"];
            var schoolIdString = Request.Form["schoolId"];

            if (idString != null && firstName != null && lastName != null && gender != null && ageString != null && schoolIdString != null)
            {
                int id = int.Parse(idString);
                string first_name = firstName.ToString();
                string last_name = lastName.ToString();
                gender = gender.ToString();
                int age = int.Parse(ageString);
                int schoolId = int.Parse(schoolIdString);

                if (first_name.Length != 0 && last_name.Length != 0 && gender.Length != 0 && age > 0 && schoolId > 0)
                {
                    try
                    {
                        Update(id, first_name, last_name, age, gender, schoolId);
                    }
                    catch (Exception e)
                    {
                        return RedirectToAction("Error", "Home", new { errorMessage = e.Message });
                    }
                }
                else
                {
                    return RedirectToAction("Error", "Home", new { errorMessage = "Please insert valid data" });
                }
            }
            else
            {
                return RedirectToAction("Error", "Home", new { errorMessage = "Please insert valid data" });
            }
            return RedirectToAction("Index", "Teacher");
        }

        private void Update(int id, string first_name, string last_name, int age, string gender, int schoolId)
        {
            var dbModel = context.Teacher.Find(id);
            if (dbModel != null)
            {
                dbModel.first_name = first_name;
                dbModel.last_name = last_name;
                dbModel.age = age;
                dbModel.gender = gender;
                dbModel.school_id = schoolId;
                context.SaveChanges();
            }
            else
            {
                throw new Exception("Teacher not found!");
            }
        }
    }
}