using System.Collections.Generic;
using System.Linq;
using BusinessLogic.Exceptions;
using BusinessLogic.Services;
using Domain.Definitions;

namespace BusinessLogic
{
    public static class RolesThatHaveTheAbilityToCreateTasks
    {
        private static readonly List<RoleTaskStateSearch> Roles = new List<RoleTaskStateSearch>
        {
            new RoleTaskStateSearch(AccountRole.Referent, TaskState.SendToMinistr),
        };

        public static bool GetForRole(AccountRole role)
        {
            return Roles.Any(x=>x.AccountRole == role);
        }

        public static TaskState GetStateForCreateTask(AccountRole role)
        {
            var roleTaskStateSearch = Roles.FirstOrDefault(x => x.AccountRole == role);

            if (roleTaskStateSearch != null)
                return roleTaskStateSearch.TaskState;

            throw new BusinessLogicException(string.Format("Не задано состояние задач для поиска для роли {0}", role));
        }
    }
}