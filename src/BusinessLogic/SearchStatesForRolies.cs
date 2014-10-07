using System.Collections.Generic;
using System.Linq;
using BusinessLogic.Exceptions;
using BusinessLogic.Services;
using Domain.Definitions;

namespace BusinessLogic
{
    public static class SearchStatesForRolies
    {
        private static readonly List<RoleTaskStateSearch> RoleTaskStateSearches = new List<RoleTaskStateSearch>
        {
            new RoleTaskStateSearch(AccountRole.Ministr, TaskState.SendToMinistr),
            new RoleTaskStateSearch(AccountRole.Referent, TaskState.BackToReferet)
        };

        public static TaskState GetForRole(AccountRole role)
        {
            var roleTaskStateSearch = RoleTaskStateSearches.FirstOrDefault(x => x.AccountRole == role);
            if (roleTaskStateSearch != null)
                return roleTaskStateSearch.TaskState;

            throw new BusinessLogicException(string.Format("Не задано состояние задач для поиска для роли {0}", role));
        }
    }
}
