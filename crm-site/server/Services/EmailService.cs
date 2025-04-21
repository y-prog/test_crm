﻿using MailKit.Net.Smtp;
using MailKit.Security;
using MimeKit;
using server.Config;

namespace server.Services;

public interface IEmailService
{
    Task SendEmailAsync(string to, string subject, string body);
}

public class EmailService : IEmailService
{
    private readonly EmailSettings _settings;

    public EmailService(EmailSettings settings) => _settings = settings;

    public async Task SendEmailAsync(string to, string subject, string body)
    {
       /* var email = new MimeMessage()
            
        {
            From = { MailboxAddress.Parse(_settings.FromEmail) },
            To = { MailboxAddress.Parse(to) },
            Subject = subject,
            Body = new TextPart("html") { Text = body }
        };

        using var smtp = new SmtpClient();
        await smtp.ConnectAsync(_settings.SmtpServer, _settings.SmtpPort, SecureSocketOptions.StartTls);
        await smtp.AuthenticateAsync(_settings.FromEmail, _settings.Password);
        await smtp.SendAsync(email);
        await smtp.DisconnectAsync(true);
        */
       Console.WriteLine("[EmailService] Skipped sending email. (Mock mode active)");
       Console.WriteLine($"To: {to}, Subject: {subject}, Body: {body}");
       await Task.CompletedTask;
    }
}