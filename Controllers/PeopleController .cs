using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Test_dev_pagination.Models;

namespace Test_dev_pagination.Controllers
{
    public class PeopleController : Controller
    {
        // Dummy data
        private static List<Person> DummyData = Enumerable.Range(1, 100).Select(i => new Person
        {
            Id = i,
            Name = $"Person {i}"
        }).ToList();

        // Loads the page
        public IActionResult People()
        {
            return View();
        }

        // Server-side pagination endpoint
        [HttpGet]
        public JsonResult LoadData(int page = 1, int pageSize = 10)
        {
            var total = DummyData.Count;
            var data = DummyData.Skip((page - 1) * pageSize).Take(pageSize).ToList();

            return Json(new
            {
                data = data,
                total = total
            });
        }
    }
}
