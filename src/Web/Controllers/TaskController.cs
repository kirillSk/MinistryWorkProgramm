using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web.Mvc;
using System.Web.Routing;
using BusinessLogic;
using Domain;
using Domain.Definitions;
using Web.Models;
using Web.Services;

namespace Web.Controllers
{
    [Authorize]
    public class TaskController : MyControllerBase
    {
        public ActionResult List(string notification = "")
        {
            using (var session = MvcApplication.Store.OpenSession())
            {
                var contextAccount = ContextAccountProvider.GetContextAccount(session);

                var taskState = SearchStatesForRolies.GetForRole(contextAccount.Role);

                var tasks = session.Query<Task>().ToList().Where(x => x.State == taskState);

                ViewBag.Notification = notification;

                return View(tasks);
            }
        }

        public ActionResult Details(int id)
        {
            using (var session = MvcApplication.Store.OpenSession())
            {
                var contextAccount = ContextAccountProvider.GetContextAccount(session);
                var task = session.Load<Task>(id);
                ViewBag.Actions = ActionDeterminant.Get(contextAccount.Role, task.State);

                return View(task);
            }
        }


        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(TaskModel model)
        {
            try
            {
                using (var session = MvcApplication.Store.OpenSession())
                {
                    var contextAccount = ContextAccountProvider.GetContextAccount(session);

                    var task = new Task(model.Title, model.Content, model.Source, DateTime.Parse(model.Deadline, null, DateTimeStyles.RoundtripKind), RolesThatHaveTheAbilityToCreateTasks.GetStateForCreateTask(contextAccount.Role));

                    task.AddСomment(new Log("Задача создана", contextAccount));

                    if (!string.IsNullOrWhiteSpace(model.AdditionalСomment))
                        task.AddСomment(new Comment(model.AdditionalСomment, contextAccount));

                    session.Store(task);
                    session.SaveChanges();
                    return RedirectToAction("List", new { notification = string.Format("Задача \"{0}\" создана!", model.Title) });

                }
            }
            catch (Exception ex)
            {

                return View("Error", ex);
            }
        }

        public ActionResult AddComment(int id, string comment)
        {

            using (var session = MvcApplication.Store.OpenSession())
            {
                var contextAccount = ContextAccountProvider.GetContextAccount(session);

                var task = session.Load<Task>(id);

                task.AddСomment(new Comment(comment, contextAccount));
                session.SaveChanges();
                return RedirectToAction("Details", "Task", new { id });

            }
        }

        public ActionResult SetTaskState(int id, TaskState taskState)
        {
            using (var session = MvcApplication.Store.OpenSession())
            {
                var contextAccount = ContextAccountProvider.GetContextAccount(session);
                var task = session.Load<Task>(id);

                task.SetState(taskState);
                task.AddСomment(new Log(string.Format("Задача переведена в состояние \"{0}\"", taskState.GetDescription()), contextAccount));
                session.SaveChanges();
                return RedirectToAction("List", "Task", new { notification = string.Format("Задача \"{0}\" переведена в состояние \"{1}\"", task.Title, taskState.GetDescription()) });
            }
        }
    }
}
