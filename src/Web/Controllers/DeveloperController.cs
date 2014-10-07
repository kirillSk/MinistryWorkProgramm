using System.Linq;
using System.Web.Mvc;
using Domain;
using Domain.Definitions;
using Web.Services;

namespace Web.Controllers
{
    public class DeveloperController : Controller
    {

        /*
         * http://localhost:48850/Developer/CreateAccount?name=Василий&surname=Иванов&login=Министр&role=Ministr&password=123
         * http://localhost:48850/Developer/CreateAccount?name=Людмила&surname=Сидирова&login=Секретарь&role=Referent&password=123
         */
        public string CreateAccount(string name, string surname, string login, AccountRole role, string password)
        {
            using (var session = MvcApplication.Store.OpenSession())
            {
                var account = new Account
                {
                    Name = name,
                    Surname = surname,
                    Login = login,
                    Role = role,
                    PasswordHash = PasswordHasher.Get(password)
                };

                session.Store(account);
                session.SaveChanges();

                return "Пользователь создан";
            }
        }


        public string InitDb()
        {
            DropTasks();
            DropAccounts();

            CreateAccount("Василий", "Иванов", "Министр", AccountRole.Ministr, "123");
            CreateAccount("Людмила", "Сидирова", "Секретарь", AccountRole.Referent, "123");

            return "База проинициализирована";
        }

        public string DropAccounts()
        {
            using (var session = MvcApplication.Store.OpenSession())
            {
                var accounts = session.Query<Account>().ToList();
                foreach (var account in accounts)
                {
                    session.Delete(account);   
                }
                session.SaveChanges();

                return "Пользователи удалены";
            }
        }

        public string DropTasks()
        {
            using (var session = MvcApplication.Store.OpenSession())
            {
                var tasks = session.Query<Task>().ToList();
                foreach (var task in tasks)
                {
                    session.Delete(task);   
                }
                session.SaveChanges();

                return "Задачи удалены";
            }
        }
    }
}