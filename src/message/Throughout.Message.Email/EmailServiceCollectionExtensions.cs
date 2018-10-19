using System;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Throughout.Message.Email;
using Throughout.Message.Email.Interfaces;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class FluentEmailServiceCollectionExtensions
    {
        public static EmailServicesBuilder AddFluentEmail(this IServiceCollection services, string defaultFromEmail, string defaultFromName = "")
        {
            if (services == null) throw new ArgumentNullException(nameof(services));

            var builder = new EmailServicesBuilder(services);
            services.TryAdd(ServiceDescriptor.Transient<IEmail>(x =>
                new Email(x.GetService<ITemplateRenderer>(), x.GetService<ISender>(), defaultFromEmail, defaultFromName)
            ));
            services.TryAddTransient<IEmailFactory, EmailFactory>();
            return builder;
        }
    }

    public class EmailServicesBuilder
    {
        public IServiceCollection Services { get; private set; }

        internal EmailServicesBuilder(IServiceCollection services)
        {
            Services = services;
        }
    }
}