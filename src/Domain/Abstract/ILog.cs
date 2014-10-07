using System;

namespace Domain.Abstract
{
    public interface ILog
    {
        string Text { get; set; }
        int ActorId { get; set; }
        DateTime CreateAt { get; set; }
    }
}