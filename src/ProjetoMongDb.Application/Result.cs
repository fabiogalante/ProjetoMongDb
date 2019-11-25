using Flunt.Notifications;
using System.Collections.Generic;

namespace ProjetoMongDb.Application
{
    public class Result:Notifiable
    {
        protected Result()
        {
        }

        protected Result(ICollection<Notification> notifications)
        {
            this.AddNotifications(notifications);
        }

        public void AddNotification(string error)
        {
            this.AddNotification(null, error);
        }

        public ErrorCode? Error { get; set; }
    }
}
