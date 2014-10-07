using System.ComponentModel;
using Domain;
using Domain.Definitions;

namespace Web.Services
{
    public static class ExtensionMethods
    {
        public static string GetDescription<T>(this T obj)
        {
            var type = typeof(T);
            var memInfo = type.GetMember(obj.ToString());
            var attributes = memInfo[0].GetCustomAttributes(typeof(DescriptionAttribute),
                false);
            return ((DescriptionAttribute)attributes[0]).Description;
        }

        public static string GetNameAndRole(this Account account)
        {
            return string.Format("{0} {1} ({2})", account.Name, account.Surname, account.Role.GetDescription());
        }
    }
}