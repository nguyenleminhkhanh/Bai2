using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MvcWebApp.Models;

namespace MvcWebApp.Controllers
{
    public class StudentController : Controller
    {

        private static List<Student> products = new List<Student>();

        public StudentController()
        {
            if (products.Count == 0)
            {
                products.Add(new Student() { Id = "S00001", Name = "Daniel", Age = 18, Email = "student@tdtu.edu.vn" });
                products.Add(new Student() { Id = "S00002", Name = "Louis", Age = 18, Email = "student@tdtu.edu.vn" });
                products.Add(new Student() { Id = "S00003", Name = "Christain", Age = 18, Email = "student@tdtu.edu.vn" });
                products.Add(new Student() { Id = "S00004", Name = "Lucas", Age = 18, Email = "student@tdtu.edu.vn" });

            }
        }

        
        public ActionResult Index()
        {
            return View(products);
        }

       

        // GET: ProductManagement/Edit/5
        public ActionResult Edit(string id)
        {
            Student p = products.FirstOrDefault(p => p.Id == id);
            if (p == null)
            {
                return RedirectToAction("Index");
            }
            else return View(p);
        }

        // POST: ProductManagement/Edit/5
        [HttpPost]
        public ActionResult Edit(string id, Student s)
        {
            Student p = products.FirstOrDefault(p => p.Id == id);
            if (p != null)
            {
                p.Name = s.Name;
                p.Age = s.Age;
                p.Email = s.Email;
            }
            

            return RedirectToAction("Index");
        }
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(Student s)
        {
           
            products.Add(s);

            return RedirectToAction("Index");
        }
        public IActionResult Delete()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Delete(Student s)
        {

            products.Remove(s);

            return RedirectToAction("Index");
        }

    }
}
