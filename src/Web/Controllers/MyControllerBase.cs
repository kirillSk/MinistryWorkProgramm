using System.Linq;
using System.Web.Mvc;
using BusinessLogic;
using Domain;
using Web.Services;

namespace Web.Controllers
{
    public class MyControllerBase : Controller
    {
        protected override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            using (var session = MvcApplication.Store.OpenSession())
            {
                var contextAccount = ContextAccountProvider.GetContextAccount(session);

                ViewBag.CurrentAccount = contextAccount;

                ViewBag.Accounts = session.Query<Account>().ToList();

                ViewBag.AbilityToCreateTask = RolesThatHaveTheAbilityToCreateTasks.GetForRole(contextAccount.Role);
            }
            base.OnActionExecuted(filterContext);
        }
    }
}