namespace Core.Entities;


public class Lugar{
    public int Id { get; set; }
    public string ? Nombre { get; set; }
    public int NroPuestos { get; set; }
    public int IdArea {get; set; }
    public Area ? Area { get; set; }
    public ICollection<Puesto> ? Puestos{ get; set; }

}