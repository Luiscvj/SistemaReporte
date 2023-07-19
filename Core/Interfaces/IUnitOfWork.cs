namespace Core.Interfaces;

public interface IUnitOfWork
{   //Aca llamamos a cada interfaz  creada y las asignamos para solo lectura

    IAreaInterface Areas {get;}
    ICategoria Categorias {get;}
    IEmail Emails {get;}
    ITipoHardware TipoHardwares {get;}
    ITrainerInterface Trainers {get;}
    IHardware Hardwares {get;}
    IInsidencia Insidencias {get;}
    IPuesto Puestos {get;}
    ISoftware Softwares {get;}
    ITipoInsidencia TipoInsidencias {get;}
    


    Task<int> SaveAsync();

}