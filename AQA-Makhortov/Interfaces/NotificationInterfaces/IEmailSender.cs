namespace AQA_Makhortov.Interfaces.NotificationInterfaces;

public interface IEmailSender
{
    Task SendEmailAsync(string to, string text);
}