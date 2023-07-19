namespace Core.Entities;

public class TipoInsidencia
{
    public int Id { get; set; }
    public string  NombreNivel { get; set; }
    public ICollection<Insidencia> Insidencias { get; set; }
}