using Swashbuckle.AspNetCore.SwaggerGen;
using Microsoft.Extensions.Options;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.OpenApi.Models;

namespace ApiVersionControl
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
                Title = "My .Net Api restful",
                Version = description.ApiVersion.ToString(),
                Description = "This is my first API Version control. ",
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


        public void Configure(SwaggerGenOptions options)
        {

            // add Swagger Documentation for each API version we have
            foreach (var description in _provider.ApiVersionDescriptions)
            {
                options.SwaggerDoc(description.GroupName, CreateVersionInfo(description));
            }
        }


        public void Configure(string name, SwaggerGenOptions options)
        {
            Configure(options);
        }

    }
}
