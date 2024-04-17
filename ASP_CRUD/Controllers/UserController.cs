using Microsoft.AspNetCore.Mvc;
using ASP_CRUD.Models;
using ASP_CRUD.Data;

namespace ASP_CRUD.Controllers
{
    public class UserController : Controller
    {
        private readonly ApplicationDBContext _db;

        public UserController(ApplicationDBContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            IEnumerable<User> allusers = _db.users;
            return View(allusers);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(User obj)
        {
            if (ModelState.IsValid)
            {
                _db.users.Add(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        public IActionResult Edit(int? id)
            
        {
            var obj = _db.users.Find(id);
            return View(obj);
        }
        [HttpPost]
        public IActionResult Edit(User obj)

        {
            _db.users.Update(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");
            //return View(obj);
        }

        public IActionResult Delete(int? id)

        {
            var u = _db.users.Find(id);

            _db.users.Remove(u);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
