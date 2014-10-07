using System;
using System.Collections.Generic;
using System.Data;
using Domain.Abstract;
using Domain.Definitions;

namespace Domain
{
    public class Task : IEntity
    {
        public readonly IList<ILog> LogsAndHistory;

        public Task(string title, string content, string source, DateTime deadline, TaskState state)
        {
            Title = title;
            Content = content;
            Source = source;
            Deadline = deadline;
            State = state;

            CreateAt = DateTime.Now;
            LogsAndHistory = new List<ILog>();
        }

        public int Id { get; set; }

        public string Title { get; set; }
        public string Content { get; set; }
        public string Source { get; set; }

        public TaskState State { get; set; }
        public DateTime Deadline { get; set; }

        public int CurrentResponsibleId { get; set; }

        public DateTime CreateAt { get; set; }

        public void AddСomment(ILog logItem)
        {
            LogsAndHistory.Add(logItem);
        }

        public void SetState(TaskState state)
        {
            State = state;
        }
    }
}