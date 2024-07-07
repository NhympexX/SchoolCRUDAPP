using Microsoft.AspNetCore.Mvc;
using SchoolCRUDAPP.Models;
using System.Diagnostics;

namespace SchoolCRUDAPP.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly AppDbContext _appDbContext;

        public HomeController(ILogger<HomeController> logger, AppDbContext appDbContext)
        {
            _logger = logger;
            _appDbContext = appDbContext;
        }

        public IActionResult Index()
        {
            var list = _appDbContext.Students.ToList();

            return View(list);
        }
        public IActionResult Create(Student student)
        {
             _appDbContext.Students.Add(student);
             _appDbContext.SaveChanges();
            return RedirectToAction(nameof(Index));

        }

        [HttpGet]
        public IActionResult Student(int? Id)
        {
            Student student;
            if (Id.HasValue)
                student = _appDbContext.Students.Find(Id);
            else
                student = new Student();
            return View(student);
        }

        public IActionResult Delete(int id)
        {
            var student = _appDbContext.Students.Find(id);
            _appDbContext.Students.Remove(student);
            _appDbContext.SaveChanges();
            return RedirectToAction(nameof(Index));

        }
        [HttpGet]
        public IActionResult Update(int id)
        {
            var student = _appDbContext.Students.Find(id);
            return View(student);
        }

        [HttpPost]
        public IActionResult Update(Student student)
        {
            _appDbContext.Students.Update(student);
            _appDbContext.SaveChanges();
            return RedirectToAction(nameof(Index));

        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
