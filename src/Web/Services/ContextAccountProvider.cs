using System.Web;
using System.Web.Security;
using Domain;
using Raven.Client;
using Web.WebModel;

namespace Web.Services
{
    public static class ContextAccountProvider
    {
        public static int GetContextAccountId()
        {
            var context = HttpContext.Current;

            if (context.User == null || context.User.Identity.IsAuthenticated == false)
                return 0;

            var cookie = context.Request.Cookies[FormsAuthentication.FormsCookieName.ToUpper()];

            if (cookie == null)
                return 0;

            var ticket = FormsAuthentication.Decrypt(cookie.Value);


            var accountEntry = StringSerializer.Deserialize<AccountEntry>(ticket.UserData);

            return accountEntry.Id;
        }

        public static Account GetContextAccount(IDocumentSession session)
        {
            return session.Load<Account>(GetContextAccountId());
        }
    }
}