
using System;
using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Mvc;
using MimeKit;
using UsuariosAPI.Models;

namespace UsuariosAPI.Services
{
    public class EmailService
    {
        public void EnviarEmail(string[] destinatario, 
            string assunto, 
            int usuarioId, 
            string activationCode)
        {
            Mensagem mensagem = new(destinatario, assunto, usuarioId, activationCode);

            var emailMessage = CreateEmailBody(mensagem);
            Enviar(emailMessage);
        }

        private MimeMessage Enviar(MimeMessage emailMessage)
        {
            using (var client = new SmtpClient())
            {
                try
                {
                    client.Connect("Conexao a fazer");
                    client.Send(emailMessage);
                }
                catch
                {
                    throw;
                }
                finally
                {
                    client.Disconnect(true);
                    client.Dispose();
                }
            }
        }

        private object CreateEmailBody(Mensagem mensagem)
        {
            var emailMessage = new MimeMessage();
            emailMessage.From.Add(new MailboxAddress("ADICIONAR O REMETENTE"));
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