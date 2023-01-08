using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace DotNetApiRestfulEjer9
{
    public class ConfigureSwaggerOptions : IConfigureNamedOptions<SwaggerGenOptions>
    {
        private readonly IApiVersionDescriptionProvider _provider;

        public ConfigureSwaggerOptions(IApiVersionDescriptionProvider provider)
        {
            _provider = provider;
        }

        private OpenApiInfo CreateVersionInfo(ApiVersionDescription description)
        {
            var info = new OpenApiInfo()
            {
                Title = "Ejercicio 9 DotNet",
                Version = description.ApiVersion.ToString(),
                Description = "This is my API Version control. ",
                Contact = new OpenApiContact()
                {
                    Email = "fedenahuelboldrini@gmail.com",
                    Name = "Federico Boldrini",
                }
            };
            if (description.IsDeprecated)
            {
                info.Description += "This API version has been deprecated";
            }
            return info;
        }





        public void Configure(string name, SwaggerGenOptions options)
        {
            Configure(options);
        }

        public void Configure(SwaggerGenOptions options)
        {
            foreach (var description in _provider.ApiVersionDescriptions)
            {
                options.SwaggerDoc(description.GroupName, CreateVersionInfo(description));
            }
        }
    }


}
