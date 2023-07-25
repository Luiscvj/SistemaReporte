using Core.Entities;

namespace API.Dtos;


public class EmailDto
{
    public string TipoEmail { get; set; }
    public List<EmailTrainerDto> EmailTrainers { get; set; }
    
}