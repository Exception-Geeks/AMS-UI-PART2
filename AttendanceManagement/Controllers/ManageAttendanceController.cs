using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AttendanceManagement.Models;
using System.Data.Entity;

namespace AttendanceManagement.Controllers
{
    public class ManageAttendanceController : Controller
    {
        private AttendanceManagementDBEntities db = new AttendanceManagementDBEntities();

        // GET: ManageAttendance/Index
        public ActionResult Index()
        {

            ViewBag.Department_DID = new SelectList(db.Departments, "DID", "Name");
            ViewBag.Section = new SelectList(db.Students, "USN",  "Section", "Sem" );
            ViewBag.Sem = new SelectList(db.Students, "USN", "Sem");
            return View();
        }

        [HttpPost]
        public ActionResult Index(int semester, String section)
        {
            ViewBag.Department_DID = new SelectList(db.Departments, "DID", "Name");
            ViewBag.Section = new SelectList(db.Students, "USN", "Section", "Sem");
            ViewBag.Sem = new SelectList(db.Students, "USN", "Sem");

            var exams = db.Students.Include(s => s.Department_DID).Where(s => s.Sem == semester).Where(s => s.Section.Equals(section));
            return View(exams.ToList());

        }



    }
}