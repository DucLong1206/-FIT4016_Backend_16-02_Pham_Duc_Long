using Microsoft.AspNetCore.Mvc;
using FIT4016_KiemTra_2026.Data;
using FIT4016_KiemTra_2026.Models;

namespace FIT4016_KiemTra_2026.Controllers
{
    public class StudentsController : Controller
    {
        private readonly SchoolDbContext _context;

        public StudentsController(SchoolDbContext context)
        {
            _context = context;
        }

       
        public IActionResult Index()
        {
            ViewBag.Schools = _context.Schools.ToList();
            return View(_context.Students.ToList());
        }

      
        [HttpPost]
        public IActionResult Create(Student model)
        {
            // Full name
            if (string.IsNullOrWhiteSpace(model.full_name) ||
                model.full_name.Length < 2 || model.full_name.Length > 100)
                ModelState.AddModelError("full_name", "Full name must be between 2 and 100 characters.");

            // Student ID
            if (string.IsNullOrWhiteSpace(model.student_id) ||
                model.student_id.Length < 5 || model.student_id.Length > 20)
                ModelState.AddModelError("student_id", "Student ID must be between 5 and 20 characters.");
            else if (_context.Students.Any(s => s.student_id == model.student_id))
                ModelState.AddModelError("student_id", "Student ID already exists.");

            // Email
            if (string.IsNullOrWhiteSpace(model.email))
                ModelState.AddModelError("email", "Email is required.");
            else if (_context.Students.Any(s => s.email == model.email))
                ModelState.AddModelError("email", "Email already exists.");

            // Phone
            if (!string.IsNullOrEmpty(model.phone) &&
                !System.Text.RegularExpressions.Regex.IsMatch(model.phone, @"^\d{10,11}$"))
                ModelState.AddModelError("phone", "Phone number must contain 10–11 digits.");

            // School
            if (!_context.Schools.Any(s => s.Id == model.school_id))
                ModelState.AddModelError("school_id", "Selected school does not exist.");

            if (!ModelState.IsValid)
            {
                ViewBag.Schools = _context.Schools.ToList();
                return View("Index", _context.Students.ToList());
            }

            model.created_at = DateTime.Now;
            model.updated_at = DateTime.Now;

            _context.Students.Add(model);
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

        // =========================
        // EDIT
        // =========================
        [HttpPost]
        public IActionResult Edit(Student model)
        {
            var student = _context.Students.FirstOrDefault(s => s.Id == model.Id);
            if (student == null) return NotFound();

            if (string.IsNullOrWhiteSpace(model.full_name) || model.full_name.Length < 2)
                ModelState.AddModelError("full_name", "Invalid full name.");

            if (_context.Students.Any(s => s.email == model.email && s.Id != model.Id))
                ModelState.AddModelError("email", "Email already exists.");

            if (!_context.Schools.Any(s => s.Id == model.school_id))
                ModelState.AddModelError("school_id", "Selected school does not exist.");

            if (!ModelState.IsValid)
            {
                ViewBag.Schools = _context.Schools.ToList();
                return View("Index", _context.Students.ToList());
            }

            student.full_name = model.full_name;
            student.email = model.email;
            student.phone = model.phone;
            student.school_id = model.school_id;
            student.updated_at = DateTime.Now;

            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        
        [HttpPost]
        public IActionResult Delete(int id)
        {
            var student = _context.Students.FirstOrDefault(s => s.Id == id);
            if (student == null) return NotFound();

            _context.Students.Remove(student);
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }
    }
}
