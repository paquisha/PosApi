using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.OpenApi.Models;

namespace POS.API.Extentions
{
    public static class SwaggerExtensions
    {
        public static IServiceCollection AddSwagger(this IServiceCollection services)
        {
            var openApi = new OpenApiInfo
            {
                Title = "Apn Api",
                Version = "v1",
                Description = "Apn integration red activa",
                TermsOfService = new Uri("https://apensource.org/licenses/MIT"),
                Contact = new OpenApiContact
                {
                    Name = "Red Activa",
                    Email = "aprogramador12@transferunion.com",
                    Url = new Uri("https://redactiva.com/")
                },
                License = new OpenApiLicense
                {
                    Name = "Use under transferUnion",
                    Url = new Uri("https://redactiva.com/")
                }
            };

            services.AddSwaggerGen(x =>
            {
                x.SwaggerDoc("v1", openApi);

                var securityScheme = new OpenApiSecurityScheme
                {
                    Name = "Jwt Authentication",
                    Description = "Jwt Bearer Token",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.Http,
                    Scheme = "Bearer",
                    BearerFormat = "JWT",
                    Reference = new OpenApiReference
                    {
                        Id = JwtBearerDefaults.AuthenticationScheme,
                        Type = ReferenceType.SecurityScheme
                    }
                };
                x.AddSecurityDefinition(securityScheme.Reference.Id, securityScheme);
                x.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    { securityScheme, new string[]{ } }
                });
            });

            return services;
        }
    }
}
