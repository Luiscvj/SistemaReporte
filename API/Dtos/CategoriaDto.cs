namespace API.Dtos;

public class CategoriaDto
{
    public string Nombre { get; set; }
    public List<HardwareDto> HardwareDtos { get; set; }
    public List<SoftwareDto> SoftwareDtos{ get; set; }
    public List<InsidenciaCategoriaDto> InsidenciaCategoriaDtos { get; set; }
}