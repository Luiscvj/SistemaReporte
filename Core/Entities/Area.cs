namespace Core.Entities;


public class Area{

    public int Id { get; set; }
    public string ? Nombre { get; set; }
    public List<Lugar> ?  Lugares { get; set; }
}