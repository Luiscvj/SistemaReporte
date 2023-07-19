namespace Core.Entities;

public class Software {
    public int Id { get; set; }
    public string ? Descripcion { get; set; }
    public int TipoSoftwareId { get; set; }
    public TipoSoftware ? TipoSoftware { get; set; }
    public int PuestoId { get; set; }
    public Puesto ? Puesto {get; set; }
    public int CategoriaId { get; set; }
    public Categoria ? Categoria { get; set; }
}