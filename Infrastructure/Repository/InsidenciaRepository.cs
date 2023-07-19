using System.Linq.Expressions;
using Core.Entities;
using Core.Interfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository;


public class InsidenciaRepository : IInsidencia
{       

    private readonly SistemReporteContext _context;

    public InsidenciaRepository(SistemReporteContext context)
    {
        _context = context;
    }
    
    public void AddInsidencia(Insidencia entity)
    {
        _context.Set<Insidencia>().Add(entity);
    }

    public void AddInsidenciasRange(Insidencia entities)
    {  
        _context.Set<Insidencia>().AddRange(entities);
    }

    public IEnumerable<Insidencia> Find(Expression<Func<Insidencia, bool>> expression)
    {
         return  _context.Set<Insidencia>().Where(expression);
    }

    public async Task<IEnumerable<Insidencia>> GetAllInsidencias()
    {
         return await  _context.Set<Insidencia>().ToListAsync();
    }

    public async Task<Insidencia> GetInsidenciaById(int id)
    {
          return await _context.Set<Insidencia>().FindAsync(id);
    }

    public void RemoveInsidencia(Insidencia entity)
    {
      _context.Set<Insidencia>().Remove(entity);
    }

    public void RemoveRangeInsidencias(IEnumerable<Insidencia> entities)
    {
        _context.Set<Insidencia>().RemoveRange(entities);
    }

    public void UpdateInsidencia(Insidencia entity)
    {
        _context.Set<Insidencia>().Update(entity);
    }
}