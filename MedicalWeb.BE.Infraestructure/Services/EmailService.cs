using Azure;
using Azure.Communication.Email;

namespace MedicalWeb.BE.Infraestructure.Services;

public class EmailService(EmailClient emailClient, string recipientEmail, string senderAddress) : IEmailService
{
    public async Task SendEmailAsync(IEmailInfo emailInfo, CancellationToken cancellationToken)
    {
        var recipientsList = new List<EmailAddress> { new EmailAddress(string.IsNullOrEmpty(recipientEmail) ? emailInfo.RecipientEmail : recipientEmail) };

        var emailMessage = new EmailMessage(
            senderAddress: senderAddress,
            content: new EmailContent(emailInfo.Subject)
            {
                Html = emailInfo.GetHtmlContent()
            },
            recipients: new EmailRecipients(recipientsList)
        );

        await emailClient.SendAsync(WaitUntil.Started, emailMessage, cancellationToken);
    }
}
