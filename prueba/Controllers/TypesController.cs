using prueba.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace prueba.Controllers
{
    public class TypesController : Controller
    {
        private ApplicationDbContext context = new ApplicationDbContext();
        // GET: Types
        public ActionResult Index()
        {
            return View(context.Types.ToList());
        }



        // GET: Types/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Types/Create
        [HttpPost]
        public ActionResult Create(Types types)
        {
            try
            {
                // TODO: Add insert logic here
                context.Types.Add(types);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Types/Edit/5
        public ActionResult Edit(int id)
        {
            Types type = context.Types.Find(id);
            return View(type);
        }

        // POST: Types/Edit/5
        [HttpPost]
        public ActionResult Edit(Types type)
        {
            try
            {
                context.Entry(type).State = EntityState.Modified;
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View(type);
            }
        }

        // GET: Types/Delete/5
        public ActionResult Delete(int id)
        {
         Types type = context.Types.Find(id);
            return View(type);
        }

        // POST: Types/Delete/5
        [HttpPost]
        public ActionResult Delete(Types type)
        {
            try
            {
                Types types = context.Types.Find(type.Id);
                context.Types.Remove(types);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
