using System.Collections.Generic;
using Domain.Definitions;

namespace BusinessLogic.Services
{
    public class ActionDefinition
    {
        public AccountRole AccountRole { get; set; }
        public TaskState TaskState { get; set; }
        public IEnumerable<ActionNameAndNextState> TaskStates { get; set; }

        public ActionDefinition(AccountRole accountRole, TaskState taskState, IEnumerable<ActionNameAndNextState> taskStates)
        {
            AccountRole = accountRole;
            TaskState = taskState;
            TaskStates = taskStates;
        }
    }
}