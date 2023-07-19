using System.Linq.Expressions;
using Core.Entities;

namespace Core.Interfaces;

public interface IInsidencia
{
    Task<Insidencia> GetInsidenciaById(int id);
    Task<IEnumerable<Insidencia>> GetAllInsidencias();
    IEnumerable<Insidencia> Find(Expression<Func<Insidencia,bool>> expression);
    void RemoveInsidencia(Insidencia entity);
    void RemoveRangeInsidencias(IEnumerable<Insidencia> entities);
    void UpdateInsidencia(Insidencia entity);
    void AddInsidencia(Insidencia entity);
    void AddInsidenciasRange(Insidencia entities);
}