namespace Core.Entities;

public class TipoSoftware{
    public int Id { get; set; }
    public string ? Nombre { get; set; }
    public ICollection<Software> ? Softwares { get; set; }

}