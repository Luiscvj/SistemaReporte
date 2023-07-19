using System.Linq.Expressions;
using Core.Entities;
using Core.Interfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository;

public class TrainerRepository : ITrainerInterface
{
    protected readonly SistemReporteContext _context;

    public TrainerRepository(SistemReporteContext context){
        _context = context;

    }

    public void Add(Trainer entity)
    {           //Set se usa para traer las entidades del grupo T especificado.
                //Esta palabra viene de SET de entidades, es decir un set de CD's un SET de puntos un SET de entidades
        _context.Set<Trainer>().Add(entity);
    }

    public void AddRange(IEnumerable<Trainer> entities)
    {
        _context.Set<Trainer>().AddRange(entities);
    }

    public IEnumerable<Trainer> Find(Expression<Func<Trainer, bool>> expression)
    {
        return  _context.Set<Trainer>().Where(expression);
    }

    public async Task<IEnumerable<Trainer>> GetAllAsync()
    {
        return  await _context.Set<Trainer>().ToListAsync();
    }

    public  async Task<Trainer>? GetByIdAsync(int id)
    {
        return await _context.Set<Trainer>().FindAsync(id);
    }

    public void Remove(Trainer entity)
    {
        _context.Set<Trainer>().Remove(entity);
    }

    public void RemoveRange(IEnumerable<Trainer> entities)
    {
        _context.Set<Trainer>().RemoveRange(entities);
    }

    public void Update(Trainer entity)
    {
        _context.Set<Trainer>().Update(entity);
    }
}