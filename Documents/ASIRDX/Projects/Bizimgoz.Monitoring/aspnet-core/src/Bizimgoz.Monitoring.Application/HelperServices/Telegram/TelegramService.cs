using Bizimgoz.Monitoring.Entities.TelegramUsers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Exceptions;
using Telegram.Bot.Polling;
using Telegram.Bot.Types;
using Volo.Abp.DependencyInjection;

namespace Bizimgoz.Monitoring.HelperServices.Telegram
{
    public class TelegramService : ISingletonDependency
    {
        public TelegramBotClient botClient;
        public List<TelegramUser> users = new List<TelegramUser>();

        public TelegramService()
        {
            botClient = new TelegramBotClient("6604430139:AAGgvsz51RVh_7l4lAa5513Sv-jbv50XkmY");
            StartReceiver();
        }

        public async Task StartReceiver()
        {
            var cancelToken = new CancellationTokenSource().Token;
            var options = new ReceiverOptions() { AllowedUpdates = { } };
            await botClient.ReceiveAsync(OnMessage, ErrorMessage, options, cancelToken);
        }

        private async Task OnMessage(ITelegramBotClient client, Update update, CancellationToken token)
        {
            if (update.Message is Message message)
            {
                if (!users.AsEnumerable().Select(x => x.UserId).Contains(message.Chat.Id))
                    users.Add(new TelegramUser
                    {
                        UserId = message.Chat.Id,
                        Bio = message.Chat.Bio == null ? "null" : message.Chat.Bio,
                        FirstName = message.Chat.FirstName == null ? "null" : message.Chat.FirstName,
                        LastName = message.Chat.LastName == null ? "null" : message.Chat.LastName,
                        Username = message.Chat.Username == null ? "null" : message.Chat.Username
                    });
                await botClient.SendTextMessageAsync(message.Chat.Id, $"Hello {message.Chat.FirstName}!");
            }
        }

        private async Task ErrorMessage(ITelegramBotClient client, Exception exception, CancellationToken token)
        {
            if (exception is ApiRequestException requestException)
            {
                await botClient.SendTextMessageAsync("", exception.Message.ToString());
            }
        }
    }
}
