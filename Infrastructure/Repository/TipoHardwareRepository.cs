using System.Linq.Expressions;
using Core.Entities;
using Core.Interfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository;

    

public class TipoHardwareRepository : ITipoHardware
{


    protected readonly SistemReporteContext _context;

    public  TipoHardwareRepository(SistemReporteContext context)
    {
        _context = context;
    }

    public void AddRangeTipoHardWare(IEnumerable<TipoHardware> entities)
    {
       _context.Set<TipoHardware>().AddRange(entities);
    }

    public void AddTipoHardware(TipoHardware entity)
    {
        _context.Set<TipoHardware>().Add(entity);
    }

    public IEnumerable<TipoHardware> Find(Expression<Func<TipoHardware, bool>> expression)
    {
        return  _context.Set<TipoHardware>().Where(expression);
    }

    public async Task<IEnumerable<TipoHardware>> GetAllTipoHardware()
    {
         return  await _context.Set<TipoHardware>().ToListAsync();   
    }

    public async  Task<TipoHardware> GetTipoHardWareById(int id)
    {
        return await _context.Set<TipoHardware>().FindAsync(id);
    }

    public void Remove(TipoHardware entity)
    {
        _context.Set<TipoHardware>().Remove(entity);
    }

    public void RemoveRange(IEnumerable<TipoHardware> entities)
    {
        _context.Set<TipoHardware>().RemoveRange(entities);
    }

    public void Update(TipoHardware entity)
    {
        _context.Set<TipoHardware>().Update(entity);
    }
}