using System.Linq.Expressions;
using Core.Entities;

namespace Core.Interfaces;

public interface ITipoHardware {

    Task<TipoHardware> GetTipoHardWareById(int id);
    Task<IEnumerable<TipoHardware>>GetAllTipoHardware();
    IEnumerable<TipoHardware> Find(Expression<Func<TipoHardware,bool>> expression);
    void AddTipoHardware(TipoHardware entity);
    void AddRangeTipoHardWare(IEnumerable<TipoHardware> entities);
    void Remove(TipoHardware entity);
    void RemoveRange(IEnumerable<TipoHardware> entities);
    void Update(TipoHardware entity);

    

}