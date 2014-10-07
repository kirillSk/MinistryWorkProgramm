using System.Collections;
using System.Collections.Generic;
using System.Linq;
using BusinessLogic.Exceptions;
using BusinessLogic.Services;
using Domain.Definitions;

namespace BusinessLogic
{
    public class ActionDeterminant
    {
        private static readonly List<ActionDefinition> ActionDefinitions = new List<ActionDefinition>
        {
            new ActionDefinition(AccountRole.Ministr, TaskState.SendToMinistr, new List<ActionNameAndNextState>
                                                                                    {
                                                                                        new ActionNameAndNextState("Отправить секретарю", TaskState.BackToReferet),
                                                                                        new ActionNameAndNextState("Закрыть", TaskState.Close),
                                                                                    }),
            new ActionDefinition(AccountRole.Referent, TaskState.BackToReferet, new List<ActionNameAndNextState>
                                                                                    {
                                                                                        new ActionNameAndNextState("Отправить министру", TaskState.SendToMinistr),
                                                                                    })
        };

        public static IEnumerable<ActionNameAndNextState> Get(AccountRole role, TaskState state)
        {
            var actionDefinition = ActionDefinitions.SingleOrDefault(x=>x.AccountRole == role && x.TaskState == state);
            if (actionDefinition != null)
                return actionDefinition.TaskStates;

            throw new BusinessLogicException(string.Format("Не задано действий для роли {0} и состояния {1}", role, state));
        }
    }
}