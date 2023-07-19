namespace Core.Entities;

public class Insidencia
{
    public int Id { get; set; }
    public string Descripcion  { get; set; }
    public DateTime FechaReporte { get; set; }
    public int TipoInsidenciaId { get; set; }
    public TipoInsidencia TipoInsidencias { get; set; }
    public int PuestoId { get; set; }
    public Puesto Puestos { get; set; }
    public int CategoriaId { get; set; }
    public Categoria Categorias { get; set; }
    public int TrainerId { get; set; }
    public Trainer Trainers { get; set; }
}