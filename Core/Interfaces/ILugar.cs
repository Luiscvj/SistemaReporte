using System.Linq.Expressions;
using Core.Entities;

namespace Core.Interfaces;


public interface ILugar
{
    Task<Lugar> ? GetByIdAsync(int id);
    Task<IEnumerable<Lugar>> GetAllAsync();
    IEnumerable<Lugar> Find(Expression<Func<Lugar,bool>> expression);
    void Add(Lugar entity);
    void AddRange(IEnumerable<Lugar> entities);
    void Remove(Lugar entity);
    void RemoveRange(IEnumerable<Lugar> entities);
    void Update(Lugar entity);
}