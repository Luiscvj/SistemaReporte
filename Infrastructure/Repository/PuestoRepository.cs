
using System.Linq.Expressions;
using Core.Entities;
using Core.Interfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository;

public class PuestoRepository : IPuesto
{

    private readonly SistemReporteContext _context;

    public PuestoRepository(SistemReporteContext context)
    {
        _context = context;
    }
    public void Add(Puesto entity)
    {
        _context.Set<Puesto>().Add(entity);
    }

    public void AddRange(IEnumerable<Puesto> entities)
    {
       _context.Set<Puesto>().AddRange(entities);
    }

    public IEnumerable<Puesto> Find(Expression<Func<Puesto, bool>> expression)
    {
       return  _context.Set<Puesto>().Where(expression);
    }

    public async Task<IEnumerable<Puesto>> GetAllAsync()
    {
        return await  _context.Set<Puesto>().ToListAsync();
    }

    public async  Task<Puesto>? GetByIdAsync(int id)
    {
        return await _context.Set<Puesto>().FindAsync(id);
    }


    public void Remove(Puesto entity)
    {
        _context.Set<Puesto>().Remove(entity);
    }

    public void RemoveRange(IEnumerable<Puesto> entities)
    {
       _context.Set<Puesto>().RemoveRange(entities);
    }

    public void Update(Puesto entity)
    {
        _context.Set<Puesto>().Update(entity);
    }
}