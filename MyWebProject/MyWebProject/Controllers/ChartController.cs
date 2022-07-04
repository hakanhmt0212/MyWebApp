using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MyWebProject.Models;

namespace MyWebProject.Controllers
{
    public class ChartController : Controller
    {
        private Database1Entities db = new Database1Entities();
        // GET: Chart
        public ActionResult Index()
        {
            List<Chart> genderRatio = new List<Chart>();
            int femaleCount = db.Person.Where(person => person.Gender == 1).Count();
            int maleCount = db.Person.Where(person => person.Gender == 0).Count();
            Chart female = new Chart("Female", femaleCount);
            Chart male = new Chart("Male", maleCount);
            genderRatio.Add(male);
            genderRatio.Add(female);
            ViewData["genderRatio"] = genderRatio;

            //Yaş kısmı
            List<int> ageCalculatorResult = new List<int>();
            int sıfOnbes = 0;
            int onbesOtuz = 0;
            int otuzKırkbes = 0;
            int kırkbesplus = 0;
            var query = (from person in db.Person
                         select new
                         {
                             BirthDate = person.BirthDate
                         }).ToList();
            ViewData["ageCalculatorResult"] = ageCalculatorResult;
            foreach (var singleDate in query)
            {
                var birth = singleDate.BirthDate;
                var Age = DateTime.Today.Year - birth.Year;
                // eğer ay kurtarmıyorsa yaşını 1 azaltıyoruz ki doğru yaş gözüksün.
                if (birth.Date > DateTime.Today.AddYears(-Age)) { Age--; }
                if (Age >= 0 && Age <= 15)
                {
                    sıfOnbes++;
                }
                else if (Age > 15 && Age <= 30)
                {
                    onbesOtuz++;
                }
                else if (Age > 30 && Age <= 45)
                {
                    otuzKırkbes++;
                }
                else
                {
                    kırkbesplus++;
                }
            }
            ageCalculatorResult.Add(sıfOnbes);
            ageCalculatorResult.Add(onbesOtuz);
            ageCalculatorResult.Add(otuzKırkbes);
            ageCalculatorResult.Add(kırkbesplus);
            return View();
        }
    }
}