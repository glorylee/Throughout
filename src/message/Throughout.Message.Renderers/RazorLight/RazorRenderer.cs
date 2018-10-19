using RazorLight;
using System;
using System.Threading.Tasks;
using Throughout.Message.Email.Interfaces;

namespace Microsoft.Extensions.DependencyInjection
{
    public class RazorRenderer : ITemplateRenderer
    {
        public async Task<string> ParseAsync<T>(string template, T model, bool isHtml = true)
        {
            var project = new InMemoryRazorLightProject();
            var engine = new RazorLightEngineBuilder().UseMemoryCachingProvider().Build();
            return await engine.CompileRenderAsync<T>(Guid.NewGuid().ToString(), template, model);
        }

        string ITemplateRenderer.Parse<T>(string template, T model, bool isHtml)
        {
            return ParseAsync(template, model, isHtml).GetAwaiter().GetResult();
        }
    }
}