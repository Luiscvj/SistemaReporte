namespace Core.Entities;

public class Trainer{
    public int Id {get;set; }
    public string ? Nombre {get;set;}
    public List<EmailTrainer> ? EmailTrainers{get;set;}
    public List<Email> ? Emails {get;set;}
    public List<TelefonoTrainer> ? TelefonoTrainers {get;set;}
    public List<Telefono> ? Telefonos {get;set;}
    public ICollection<Insidencia> Insidencias { get; set; }

}