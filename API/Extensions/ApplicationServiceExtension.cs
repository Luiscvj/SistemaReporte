using Core.Interfaces;
using Infrastructure.Repository;
using Infrastructure.UnitOfWork;
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
    
}