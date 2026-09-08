using AQA_Makhortov.Interfaces.NotificationInterfaces;

namespace AQA_Makhortov.Services;

public class UserNotifier
{
    private readonly IEmailSender _sender;
    public UserNotifier(IEmailSender sender)
    {
        this._sender = sender;
    }

    public async Task Notify(int userId)
    {
        await _sender.SendEmailAsync("user@mail.com", $"Hello, user {userId}!");
    }
}