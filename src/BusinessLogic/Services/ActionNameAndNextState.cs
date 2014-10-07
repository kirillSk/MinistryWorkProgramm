using Domain.Definitions;

namespace BusinessLogic.Services
{
    public class ActionNameAndNextState
    {
        public string BtnTitle { get; set; }
        public TaskState TaskState { get; set; }

        public ActionNameAndNextState(string btnTitle, TaskState taskState)
        {
            BtnTitle = btnTitle;
            TaskState = taskState;
        }
    }
}