namespace Core.Entities;

public class TipoHardware{
    public int Id { get; set; }
    public string ? Nombre { get; set; }
    public ICollection<Hardware> ? Hardwares { get; set; }

}