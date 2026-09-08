using AQA_Makhortov.Interfaces.NotificationInterfaces;
using AQA_Makhortov.Services;
using FluentAssertions;

namespace AQA_Makhortov.AutoTests;

public class FakeEmailSender : IEmailSender                                                                                                                                                                                                                                                                      
{                                                                                                                                                                                                                                                                                                                
    public string To { get; private set; }                                                                                                                                                                                                                                                                       
    public string Text { get; private set; }                                                                                                                                                                                                                                                                     
                                                                                                                                                                                                                                                                                                   
    public Task SendEmailAsync(string to, string text)                                                                                                                                                                                                                                                           
    {                                                                                                                                                                                                                                                                                                            
        To = to;                                                                                                                                                                                                                                                                                                 
        Text = text;                                                                                                                                                                                                                                                                                             
        return Task.CompletedTask;                                                                                                                                                                                                                                                                               
    }                                                                                                                                                                                                                                                                                                            
}
public class UserNotifierTests
{
    [Test] 
    public async Task  Notify_SendsExpectedEmail()
    {
        var fake = new FakeEmailSender();
        var notifier = new UserNotifier(fake);

        await notifier.Notify(5);
        
        fake.To.Should().Be("user@mail.com");
        fake.Text.Should().Be("Hello, user 5!"); 
    }
}