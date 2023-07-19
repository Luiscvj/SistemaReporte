using Core.Entities;

namespace API.Dtos;

public class AreaDto
{
    public string Nombre { get; set; }
    public List<Lugar> Lugares { get; set; }
}