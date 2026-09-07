using AQA_Makhortov.Interfaces.NotificationInterfaces;

namespace AQA_Makhortov.Services;

public class EmailSender : IEmailSender
{
    public Task SendEmailAsync(string to, string text)
    {
        Console.WriteLine($"Sending mail to {to}: {text}");
        return Task.CompletedTask;
    }
}