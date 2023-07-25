namespace API.Dtos;

public class TrainerDto
{
    public string Nombre { get; set; }
    public List<EmailTrainerDto> EmailTrainers { get; set; }
    public List<InsidenciasDto> Insidencias { get; set; }
}