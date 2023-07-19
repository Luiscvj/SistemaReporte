namespace Core.Entities;

public class Hardware{
    public int Id { get; set; }
    public string ? Descripcion {get;set;}
    public int TipoHardwareId {get;set;}
    public TipoHardware ? TipoHardware {get;set;}
    public int PuestoId {get;set;}
    public Puesto ? Puesto {get;set;}
    public int CategoriaId {get;set;}
    public Categoria ? Categoria {get;set;}  
}