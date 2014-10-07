using System;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Domain;
using Web.Services;
using Web.WebModel;

namespace Web.Controllers
{
    public class AccountController : Controller
    {
        [HttpGet]
        public ActionResult LogOn()
        {
            return View();
        }

        [HttpPost]
        public ActionResult LogOn(string login, string password)
        {
            using (var session = MvcApplication.Store.OpenSession())
            {
                var account = session.Query<Account>().SingleOrDefault(x => x.Login == login);

                if (account != null && account.PasswordHash == PasswordHasher.Get(password))
                {
                    SingIn(account);
                    return RedirectToAction("List", "Task");
                }

                ViewBag.Error = "Неверный логин или пароль";

                return View();
            }
        }

        public ActionResult LogOff()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("LogOn", "Account");
        }

        private static void SingIn(Account account)
        {
            var accountEntry = new AccountEntry { Id = account.Id };

            var authTicket = new FormsAuthenticationTicket(1,
                                                           account.Login,
                                                           DateTime.Now,
                                                           DateTime.Now.Add(FormsAuthentication.Timeout),
                                                           true,
                                                           StringSerializer.Serialize(accountEntry));

            var encryptedTicket = FormsAuthentication.Encrypt(authTicket);

            var authCookie = new HttpCookie(FormsAuthentication.FormsCookieName, encryptedTicket)
            {
                Expires = DateTime.Now.Add(FormsAuthentication.Timeout),
            };

            HttpContext current = System.Web.HttpContext.Current;

            current.Response.Cookies.Add(authCookie);
        }
    }
}