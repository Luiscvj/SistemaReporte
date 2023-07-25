using AspNetCoreRateLimit;
using Core.Interfaces;
using Infrastructure.Repository;
using Infrastructure.UnitOfWork;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.Extensions.Options;

namespace API.Extensions;

public static class ApplicationServiceExtension{

    public static void ConfigureCors(this IServiceCollection services) =>
        services.AddCors(Options =>
        Options.AddPolicy("CorsPolicy",builder=>
            builder.AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader()
        ));
    
    public static void AddAplicationServices(this IServiceCollection services){
/*         services.AddScoped<ITrainerInterface,TrainerRepository>();
        services.AddScoped<ITipoHardware,TipoHardwareRepository>();
        services.AddScoped<ICategoria,CategoriaRepository>();
        services.AddScoped<IEmail,EmailRepository>(); */
        //Asocio todas las demas interfaces con su respectivo repositorio.


        //Ahora con mi unidad de trabajo unicamente asocio su respectiva interfaz

        //Mi unidad de gtrabajo me trae cada repositorio de forma dinamica, versatil y flexible cada asociacion de las interfaces de mis clases con 
        //sus respectivos repositorios.

        services.AddScoped<IUnitOfWork, UnitOfWork>();
    }



        public static void ConfigureRateLimiting(this IServiceCollection services)
    {
        services.AddMemoryCache();
        services.AddSingleton<IRateLimitConfiguration, RateLimitConfiguration>();
        services.AddInMemoryRateLimiting();
        services.Configure<IpRateLimitOptions>(Options => 
        {
            Options.EnableEndpointRateLimiting = true;
            Options.StackBlockedRequests = false;
            Options.HttpStatusCode = 429;
            Options.RealIpHeader = "X-Real-Ip";
            Options.GeneralRules = new List<RateLimitRule>
            {
                new RateLimitRule
                {
                    Endpoint = "*",
                    Period ="10s",
                    Limit = 2
                }
            };
        });
    }


    public static void ConsigureApiVersioning(this IServiceCollection services)
    {
        services.AddApiVersioning(options =>
        {
            options.DefaultApiVersion = new ApiVersion(1,0);
            options.AssumeDefaultVersionWhenUnspecified = true;
            options.ApiVersionReader = new QueryStringApiVersionReader("v");
        });
    }
    
}