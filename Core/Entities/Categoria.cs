namespace Core.Entities;

public class Categoria {
    public int Id {get; set;}
    public string ? Nombre {get; set;}
    public ICollection<Hardware> ? Hardwares {get; set;}
    public ICollection<Software> ? Softwares {get; set;}
    public ICollection<Insidencia> Insidencias { get; set; }
}
