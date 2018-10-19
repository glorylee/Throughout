using Microsoft.Extensions.DependencyInjection.Extensions;
using System;
using System.Net.Mail;
using Throughout.Message.Email.Interfaces;
using Throughout.Message.Senders.EmailSenders.Smtp;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class EmailSmtpBuilderExtensions
    {
        public static EmailServicesBuilder AddSmtpSender(this EmailServicesBuilder builder, SmtpClient smtpClient)
        {
            builder.Services.TryAdd(ServiceDescriptor.Scoped<ISender>(x => new SmtpSender(smtpClient)));
            return builder;
        }

        public static EmailServicesBuilder AddSmtpSender(this EmailServicesBuilder builder, string host, int port) => AddSmtpSender(builder, new SmtpClient(host, port));

        public static EmailServicesBuilder AddSmtpSender(this EmailServicesBuilder builder, Func<SmtpClient> clientFactory)
        {
            builder.Services.TryAdd(ServiceDescriptor.Scoped<ISender>(x => new SmtpSender(clientFactory)));
            return builder;
        }
    }
}
