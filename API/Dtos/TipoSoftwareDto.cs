namespace API.Dtos;

public class TipoSoftwareDto
{
    public string Nombre { get; set; }
    public List<SoftwareDto> Softwares { get; set; }
}