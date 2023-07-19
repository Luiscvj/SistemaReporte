using System.Linq.Expressions;
using Core.Entities;
using Core.Interfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository;

public class TipoInsidenciaRepository : ITipoInsidencia
{

    private readonly SistemReporteContext _context;

    public TipoInsidenciaRepository(SistemReporteContext context)
    {
        _context = context;
    }
    public void Add(TipoInsidencia entity)
    {
        _context.Set<TipoInsidencia>().Add(entity);
    }

    public void AddRange(IEnumerable<TipoInsidencia> entities)
    {
       _context.Set<TipoInsidencia>().AddRange(entities);
    }

    public IEnumerable<TipoInsidencia> Find(Expression<Func<TipoInsidencia, bool>> expression)
    {
       return  _context.Set<TipoInsidencia>().Where(expression);
    }

    public async Task<IEnumerable<TipoInsidencia>> GetAllTipoInsidencias()
    {
        return await  _context.Set<TipoInsidencia>().ToListAsync();
    }

    public async Task<TipoInsidencia> GetTipoIById(int id)
    {
       return await _context.Set<TipoInsidencia>().FindAsync(id);
    }

    public void Remove(TipoInsidencia entity)
    {
        _context.Set<TipoInsidencia>().Remove(entity);
    }

    public void RemoveRange(IEnumerable<TipoInsidencia> entities)
    {
       _context.Set<TipoInsidencia>().RemoveRange(entities);
    }

    public void Update(TipoInsidencia entity)
    {
        _context.Set<TipoInsidencia>().Update(entity);
    }
}