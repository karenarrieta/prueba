using Microsoft.AspNet.Identity;
using prueba.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace prueba.Controllers
{
    public class ProjectsController : Controller
    {
        private ApplicationDbContext context = new ApplicationDbContext();
        // GET: Projects

            [Authorize]
        public ActionResult Index()
        {
            string id = User.Identity.GetUserId();
            var projects = (from p in context.Projects
                            join t in context.Types on p.TypeId equals t.Id.ToString()
                            where p.Deleted == false
                            && p.UserId == id
                            select new
                            {
                                id = p.Id,
                                userid = p.UserId,
                                typeid = t.Name,
                                name = p.Name,
                                startdate = p.StartDate,
                                finishdate = p.FinishDate,
                                deleted = p.Deleted
                            }).AsEnumerable().Select(z => new Projects
                            {
                                Id = z.id,
                                UserId = z.userid,
                                TypeId = z.typeid,
                                Name = z.name,
                                StartDate = z.startdate,
                                FinishDate = z.finishdate,
                                Deleted = z.deleted
                            }).ToList();
                            
            return View(projects);
        }
        [Authorize]
        // GET: Projects/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }
        [Authorize]
        // GET: Projects/Create
        public ActionResult Create()
        {
            Projects project = new Projects();
       
            var types = context.Types.ToList();
            ViewData["projecttype"] = new SelectList(types, "Id", "Name",null);



            return View(project);
        }

        public List<Types> type()
        { return context.Types.ToList();
        }
        [Authorize]
        // POST: Projects/Create
        [HttpPost]
        public ActionResult Create([Bind(Include = "TypeId, Name, StartDate, FinishDate")] Projects project, FormCollection form)
        {
            try
            {
                
                project.UserId = User.Identity.GetUserId();
                project.TypeId =  form[1];
                context.Projects.Add(project);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        [Authorize]
        // GET: Projects/Edit/5
        public ActionResult Edit(int id)
        {
            Projects project = context.Projects.Find(id);
            var types = context.Types.ToList();
            ViewData["projecttype"] = new SelectList(types, "Id", "Name", project.TypeId);
            return View(project);
        }
        [Authorize]
        // POST: Projects/Edit/5
        [HttpPost]
        public ActionResult Edit([Bind(Include = "Id,TypeId, Name, StartDate, FinishDate")] Projects project, FormCollection form)
        {
            try
            {
                project.UserId = User.Identity.GetUserId();
                project.TypeId = form[1];
                context.Entry(project).State = EntityState.Modified;
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                return View();
            }
        }
        [Authorize]
        // GET: Projects/Delete/5
        public ActionResult Delete(int id)
        {
            Projects project = context.Projects.Find(id);
            return View(project);
        }
        [Authorize]
        // POST: Projects/Delete/5
        [HttpPost]
        public ActionResult Delete(Projects project)
        {
            try
            {
                project.Deleted = true;
                context.Entry(project).State = EntityState.Modified;
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
