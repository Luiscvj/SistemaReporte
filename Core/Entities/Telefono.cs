namespace Core.Entities;

public class Telefono {
    public int Id {get; set;}
    public string ? TipoTelefono {get; set;}
    public List<TelefonoTrainer> TelefonoTrainer {get;set;}
    public List<Trainer> ? Trainers {get;set;} 
}