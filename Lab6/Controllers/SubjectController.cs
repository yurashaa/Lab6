using Lab6.App_Start;
using Lab6.Models;
using System;
using System.Web.Mvc;

namespace Lab6.Controllers
{
    public class SubjectController : Controller
    {
        Context context = new Context();
        public ActionResult Index()
        {
            return View(context);
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            Subject c = new Subject { id = id };
            context.Subject.Attach(c);
            context.Subject.Remove(c);
            context.SaveChanges();

            return RedirectToAction("Index", "Subject");
        }

        [HttpGet]
        public ActionResult AddSubject()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddSubject(Subject item)
        {
            context.Subject.Add(item);
            context.SaveChanges();

            return RedirectToAction("Index", "Subject");
        }

        public ActionResult Update(FormCollection form)
        {
            var idString = Request.Form["id"];
            var nameQ = Request.Form["name"];
            var coefficientString = Request.Form["coeeficient"];
            var durationString = Request.Form["duration"];

            if (idString != null && coefficientString != null && durationString != null)
            {
                int id = int.Parse(idString);
                string name = nameQ.ToString();
                int coefficient = int.Parse(coefficientString);
                int duration = int.Parse(durationString);

                if (name.Length != 0 && coefficient > 0 && duration > 0)
                {
                    try
                    {
                        Update(id, name, coefficient, duration);
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
            return RedirectToAction("Index", "Subject");
        }

        private void Update(int id, string name, int coefficient, int duration)
        {
            var dbModel = context.Subject.Find(id);
            if (dbModel != null)
            {
                dbModel.name = name;
                dbModel.coefficient = coefficient;
                dbModel.duration = duration;
                context.SaveChanges();
            }
            else
            {
                throw new Exception("Subject not found!");
            }
        }
    }
}