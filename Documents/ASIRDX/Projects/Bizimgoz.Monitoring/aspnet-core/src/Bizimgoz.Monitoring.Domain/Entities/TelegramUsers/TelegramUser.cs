using System;
using Volo.Abp.Domain.Entities;

namespace Bizimgoz.Monitoring.Entities.TelegramUsers
{
    public class TelegramUser : AggregateRoot<long>
    {
        public long UserId { get; set; }
        public string Username { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Bio { get; set; }
    }
}
