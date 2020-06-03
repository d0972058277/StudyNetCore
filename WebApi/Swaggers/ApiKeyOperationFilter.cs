using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Swaggers
{
    public class ApiKeyOperationFilter : IOperationFilter
    {
        public void Apply(OpenApiOperation operation, OperationFilterContext context)
        {
            var authorizeAttribute = context.MethodInfo.DeclaringType.GetCustomAttributes(false)
                .Union(context.MethodInfo.GetCustomAttributes(false))
                .OfType<AuthorizeAttribute>();

            if (!authorizeAttribute.Any()) return;

            var auth = new OpenApiSecurityRequirement {
                {
                    new OpenApiSecurityScheme {
                        Reference = new OpenApiReference {
                            Type = ReferenceType.SecurityScheme,
                            Id = JwtBearerDefaults.AuthenticationScheme },
                        Scheme = "Authorization",
                        Name = "Bearer",
                        In = ParameterLocation.Header,
                    },
                    new List<string>()
                }
            };

            if (operation.Security == null)
            {
                operation.Security = new List<OpenApiSecurityRequirement>();
            }

            operation.Security.Add(auth);
        }
    }
}
