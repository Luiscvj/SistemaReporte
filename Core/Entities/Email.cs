namespace Core.Entities;


public class Email{
    public int Id { get; set; }
    public string ? TipoEmail {get; set;}
    public List<EmailTrainer> ? EmailTrainers{get;set;}
    public List<Trainer> Trainers {get; set;}
}