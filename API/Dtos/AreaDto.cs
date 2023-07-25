using Core.Entities;

namespace API.Dtos;

public class AreaDto
{
    //En propiedades de navegacion con listas debo usar siemore su respectivo dto
    public string Nombre { get; set; }
    public List<LugarDto> Lugares { get; set; }
}