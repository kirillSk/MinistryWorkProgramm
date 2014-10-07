using System;
using Domain.Abstract;

namespace Domain
{
    public class Comment : ILog
    {
        public string Text { get; set; }
        public int ActorId { get; set; }
        public DateTime CreateAt { get; set; }

        public Comment()
        {
            
        }

        public Comment(string text, Account actor)
        {
            Text = text;
            ActorId = actor.Id;
            CreateAt = DateTime.Now;
        }
    }
}