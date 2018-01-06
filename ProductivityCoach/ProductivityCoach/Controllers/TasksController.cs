using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using ProductivityCoach.Data.ADORepository;
using ProductivityCoach.Models;
using ProductivityCoach.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProductivityCoach.Controllers
{
    public class TasksController : Controller
    {
        // GET: Tasks
        public ActionResult Index()
        {
            string userId = string.Empty;
            if (Request.IsAuthenticated)
            {
                var userMgr = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new ApplicationDbContext()));
                var user = userMgr.FindByName(User.Identity.Name);
                ViewBag.UserId = user.Id;
                userId = user.Id;
            }
            var repo = new MyTaskRepo();

            if (userId.Length > 0)
            {
                List<MyTask> model = repo.GetTasksForUser(userId).ToList();
                return View(model);
            }
            else
                return View();
        }

        public ActionResult Add() 
        {
            var model = new AddTaskViewModel();
            var details = new TaskDetails();
            model.CompleteEveryTimeUnits = new SelectList(details.GetTimeUnits(), "CompleteEveryTimeUnit", "CompleteEveryTimeUnit");
            model.DurationUnits = new SelectList(details.GetDurationsUnits(), "DurationUnit", "DurationUnit");
            model.TypeNames = new SelectList(details.GetTaskTypes(), "TypeName", "TypeName");

            return View(model);
        }

        

        
    }
}