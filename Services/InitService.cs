using Telegram.Bot;
using Telegram.Bot.Examples.WebHook.Services;
using Telegram.Bot.Types;
using Telegram.Bot.Services;

namespace TGBot_TW_Stock_Polling.Services
{
    public class InitService : IHostedService
    {
        private readonly ILogger<InitService> _logger;
        private readonly BrowserHandlers _browserHandlers;
        private readonly ITelegramBotClient _botClient;
        private readonly UpdateHandler _updateHandler;

        public InitService(
            ILogger<InitService> logger, 
            BrowserHandlers browserHandlers,
            ITelegramBotClient botClient,
            UpdateHandler updateHandler)
        {
            _logger = logger;
            _browserHandlers = browserHandlers;
            _botClient = botClient;
            _updateHandler = updateHandler;
        }

        public async Task StartAsync(CancellationToken cancellationToken)
        {
            await _browserHandlers.LunchesPlaywright();
            await SetupBotCommandsAsync();
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("Stopping InitService...");
            return Task.CompletedTask;
        }

        private async Task SetupBotCommandsAsync()
        {
            await _botClient.SetMyCommandsAsync(UpdateHandler.GetBotCommands());
        }
    }
}