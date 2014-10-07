using System;
using System;
using Domain.Abstract;

namespace Domain
{
    public class Log : ILog
    {
        public string Text { get; set; }
        public int ActorId { get; set; }
        public DateTime CreateAt { get; set; }

        public Log()
        {
            
        }

        public Log(string text, Account actor)
        {
            Text = text;
            ActorId = actor.Id;
            CreateAt = DateTime.Now;
        }
    }
}