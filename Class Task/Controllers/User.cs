using Class_Task.Models;
using Microsoft.AspNetCore.Mvc;

namespace Class_Task.Controllers
{
    public class User : Controller
    {

        PracticalContext db = new PracticalContext();
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Shop()
        {
            var showpro = db.Products.ToList();
            return View(showpro);


        }

        [HttpPost]
        public IActionResult Search(string xyz)
        {
            var resultt = db.Products.Where(x => x.Name.Contains(xyz));
            return View("Shop", resultt.ToList());
        }

    }
}
