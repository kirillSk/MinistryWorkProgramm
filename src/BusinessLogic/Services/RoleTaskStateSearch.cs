using Domain.Definitions;

namespace BusinessLogic.Services
{
    public class RoleTaskStateSearch
    {
        public AccountRole AccountRole { get; set; }
        public TaskState TaskState { get; set; }

        public RoleTaskStateSearch(AccountRole accountRole, TaskState taskState)
        {
            AccountRole = accountRole;
            TaskState = taskState;
        }
    }
}