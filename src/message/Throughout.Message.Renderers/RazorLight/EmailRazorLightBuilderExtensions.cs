using Microsoft.Extensions.DependencyInjection.Extensions;
using Throughout.Message.Email.Interfaces;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class FluentEmailRazorBuilderExtensions
    {
        public static EmailServicesBuilder AddRazorRenderer(this EmailServicesBuilder builder)
        {
            builder.Services.TryAdd(ServiceDescriptor.Singleton<ITemplateRenderer, RazorRenderer>());
            return builder;
        }
    }
}
