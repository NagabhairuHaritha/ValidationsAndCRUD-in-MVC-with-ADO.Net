using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ValidationsAndCRUD_in_MVC_with_ADO.Net.Models;

namespace ValidationsAndCRUD_in_MVC_with_ADO.Net.Controllers
{
    public class EmpController : Controller
    {
        // GET: Emp
        public ActionResult Index()
        {
            EmpDbHandle dbhandle = new EmpDbHandle();
            ModelState.Clear();
            return View(dbhandle.GetEmployee());
        }

        

        // GET: Emp/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Emp/Create
        [HttpPost]
        public ActionResult Create(Employee em)
        {
            try
            {
                if(ModelState.IsValid)
                {
                    EmpDbHandle edb = new EmpDbHandle();
                    if(edb.AddEmployee(em))
                    {
                        ViewBag.Message = "Employee Details Added Successfully";
                        ModelState.Clear();
                    }
                }

                return View();
            }
            catch
            {
                return View();
            }
        }

        // GET: Emp/Edit/5
        public ActionResult Edit(int id)
        {
            EmpDbHandle edb = new EmpDbHandle();
            return View(edb.GetEmployee().Find(em=>em.id==id));
        }

        // POST: Emp/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Employee em)
        {
            try
            {
                EmpDbHandle edb = new EmpDbHandle();
                edb.UpdateEmployeeDetails(em);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Emp/Delete/5
        public ActionResult Delete(int id)
        {
            try
            {
                EmpDbHandle edb = new EmpDbHandle();
                if (edb.DeleteEmployeeDetails(id))
                {
                    ViewBag.AlertMsg = "Employee Deleted Successfully";
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        
    }
}
