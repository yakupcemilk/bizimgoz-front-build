using Bizimgoz.Monitoring.Entities.TelegramUsers;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
using Telegram.Bot;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace Bizimgoz.Monitoring.HelperServices.Telegram
{
    public class TelegramAppService : ApplicationService
    {
        private TelegramService _telegram;
        private IRepository<TelegramUser, long> _repository;

        public TelegramAppService(TelegramService telegram, IRepository<TelegramUser, long> repository)
        {
            _telegram = telegram;
            _repository = repository;
        }

        [HttpGet]
        public async Task SendMessage(string message)
        {
            var savedUsers = await _repository.GetListAsync();
            var unsavedUser = _telegram.users.Where(user => !savedUsers.Select(suser => suser.UserId).Contains(user.UserId));
            await _repository.InsertManyAsync(unsavedUser);
            var AllUsers = await _repository.GetListAsync();

            foreach (var user in AllUsers)
            {
                await _telegram.botClient.SendTextMessageAsync(user.UserId, message);
            }
        }
    }
}
