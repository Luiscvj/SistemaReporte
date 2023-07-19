namespace Core.Entities;

public class Puesto{
    public int Id { get; set; }
    public int IdLugar { get; set; }
    public Lugar ? Lugar   { get; set; }
    public ICollection<Software> ? Softwares {get;set;}
    public ICollection<Hardware> ? Hardwares {get;set;}
    public ICollection<Insidencia> Insidencias { get; set; }
}