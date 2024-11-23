using Class_Task.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Class_Task.Controllers
{
    public class Admin : Controller
    {
        PracticalContext db = new PracticalContext();
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult AddPro()
        { 
            return View();
        }
        [HttpPost]
        public IActionResult AddPro(Product pg, IFormFile file)
        {
            var imageName = Path.GetFileName(file.FileName);
            string imagePath = Path.Combine(HttpContext.Request.PathBase.Value, "wwwroot/Image/");
            string imagevalue = Path.Combine(imagePath, imageName);
            using (var stream = new FileStream(imagevalue, FileMode.Create))
            {
                file.CopyTo(stream);
            }
            var dbimage = Path.Combine("/Image/", imageName);
            pg.Image = dbimage;
            db.Products.Add(pg);
            db.SaveChanges();

            
            return View();
        }

        public IActionResult ShowPro()
        {
            var showpro = db.Products.ToList();
            return View(showpro);

           
        }

        [HttpPost]
        public IActionResult Search(string xyz)
        {
            var resultt = db.Products.Where(x => x.Name.Contains(xyz));
            return View("ShowPro", resultt.ToList());
        }
        [HttpGet]
        public IActionResult DeletePro(Product pg)
        {

            db.Products.Remove(pg);
            db.SaveChanges();
            return RedirectToAction("ShowPro");

        }

    }
}
