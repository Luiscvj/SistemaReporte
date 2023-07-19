using System.Linq.Expressions;
using Core.Entities;

namespace Core.Interfaces;

public interface ITipoInsidencia
{
    Task<TipoInsidencia> GetTipoIById(int id);
    Task<IEnumerable<TipoInsidencia>> GetAllTipoInsidencias();
    IEnumerable<TipoInsidencia>  Find(Expression<Func<TipoInsidencia, bool>> expression);
    void Remove(TipoInsidencia entity);
    void RemoveRange(IEnumerable<TipoInsidencia> entities);
    void Add(TipoInsidencia entity);
    void AddRange(IEnumerable<TipoInsidencia> entities);
    void Update(TipoInsidencia entity);
}