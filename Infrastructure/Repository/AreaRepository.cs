using System.Linq;
using System.Linq.Expressions;
using Core.Entities;
using Core.Interfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository;


public class AreaRepository : IAreaInterface
{
    protected readonly SistemReporteContext _context;

    public AreaRepository(SistemReporteContext context){

        _context = context;
    }


    public void Add(Area entity)
    {
       _context.Set<Area>().Add(entity); 
    }

    public void AddRange(IEnumerable<Area> entities)
    {
        _context.Set<Area>().AddRange(entities);
    }

    public IEnumerable<Area> Find(Expression<Func<Area,bool>> expression)
    {
        return _context.Set<Area>().Where(expression);
    }

    public async Task<IEnumerable<Area>> GetAllAsync()
    {
        return await _context.Areas.Include(a => a.Lugares).ToListAsync();
                  
    }

    public  async Task<IEnumerable<Area>> GetAllByOrder()
    {
        var sel =   from area in _context.Areas
                where area.Lugares.Any(Lugar => Lugar.NroPuestos >= 25)
                select area;

         return await sel.ToListAsync();
          
        
                

    }

    public async  Task<Area>  GetByIdAsync(int id)
    {   //Le digo que me traiga  el area respectiva con sus lugares 
        return await _context.Areas
        .Include(a =>a.Lugares)
        .FirstOrDefaultAsync(a => a.Id == id);
    }

    public void Remove(Area entity)
    {
        _context.Set<Area>().Remove(entity);
    }

    public void RemoveRange(IEnumerable<Area> entities)
    {
        _context.Set<Area>().RemoveRange(entities);
    }

    public void Update(Area entity)
    {
       _context.Set<Area>().Update(entity); 
    }
}