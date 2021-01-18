using Lab6.App_Start;
using Lab6.Models;
using System;
using System.Web.Mvc;

namespace Lab6.Controllers
{
    public class SchoolController : Controller
    {
        Context context = new Context();
        public ActionResult Index()
        {
            return View(context);
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            School c = new School { id = id };
            context.School.Attach(c);
            context.School.Remove(c);
            context.SaveChanges();

            return RedirectToAction("Index", "School");
        }

        [HttpGet]
        public ActionResult AddSchool()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddSchool(School item)
        {
            context.School.Add(item);
            context.SaveChanges();

            return RedirectToAction("Index", "School");
        }

        public ActionResult Update(FormCollection form)
        {
            var idString = Request.Form["id"];
            var schoolName = Request.Form["name"];
            var yearString = Request.Form["year"];

            if (idString != null && schoolName != null && yearString != null)
            {
                int id = int.Parse(idString);
                string name = schoolName.ToString();
                int year = int.Parse(yearString);

                if (name.Length != 0 && year > 0)
                {
                    try
                    {
                        Update(id, name, year);
                    }
                    catch (Exception e)
                    {
                        return RedirectToAction("Error", "Home", new { errorMessage = e.Message });
                    }
                }
                else
                {
                    return RedirectToAction("Error", "Home", new { errorMessage = "Please insert id, name and year of school to update" });
                }
            }
            else
            {
                return RedirectToAction("Error", "Home", new { errorMessage = "Please insert id, name and year of school to update" });
            }
            return RedirectToAction("Index", "School");
        }

        private void Update(int id, string name, int year)
        {
            var dbModel = context.School.Find(id);
            if (dbModel != null)
            {
                dbModel.name = name;
                dbModel.year = year;
                context.SaveChanges();
            }
            else
            {
                throw new Exception("School not found!");
            }
        }
    }
}