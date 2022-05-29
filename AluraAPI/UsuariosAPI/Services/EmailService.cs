
using System;
using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using MimeKit;
using UsuariosAPI.Models;

namespace UsuariosAPI.Services
{
    public class EmailService
    {
        private IConfiguration _configuration;

        public EmailService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void EnviarEmail(string[] destinatario, 
            string assunto, 
            int usuarioId, 
            string activationCode)
        {
            Mensagem mensagem = new(destinatario, assunto, usuarioId, activationCode);

            var emailMessage = CreateEmailBody(mensagem);
            Enviar(emailMessage);
        }

        private void Enviar(MimeMessage emailMessage)
        {
            using (var client = new SmtpClient())
            { 
                try
                {
                    client.Connect(_configuration.GetValue<string>("EmailSettings:SmtpServer"), 
                        _configuration.GetValue<int>("EmailSettings:Port"), 
                        true);
                    client.AuthenticationMechanisms.Remove("XOAUTH2");
                    client.Authenticate(_configuration.GetValue<string>("EmailSettings:From"),
                        _configuration.GetValue<string>("EmailSettings:Password"));
                    client.Send(emailMessage);
                }
                finally
                {
                    client.Disconnect(true);
                    client.Dispose();
                }
            }
        }

        private MimeMessage CreateEmailBody(Mensagem mensagem)
        {
            var emailMessage = new MimeMessage();
            emailMessage.From.Add(new MailboxAddress(_configuration.GetValue<string>("EmailSettings:From")));
            emailMessage.To.AddRange(mensagem.Destinatario);
            emailMessage.Subject = mensagem.Assunto;
            emailMessage.Body = new TextPart(MimeKit.Text.TextFormat.Text)
            {
                Text = mensagem.Conteudo
            };

            return emailMessage;
        }
    }
}