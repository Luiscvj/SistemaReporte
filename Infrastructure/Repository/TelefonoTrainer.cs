
using System.Linq.Expressions;
using Core.Entities;
using Core.Interfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository;

public class TelefonoTrainerRepository : ITelefonoTrainer
{

    private readonly SistemReporteContext _context;

    public TelefonoTrainerRepository(SistemReporteContext context)
    {
        _context = context;
    }
    public void Add(TelefonoTrainer entity)
    {
        _context.Set<TelefonoTrainer>().Add(entity);
    }

    public void AddRange(IEnumerable<TelefonoTrainer> entities)
    {
       _context.Set<TelefonoTrainer>().AddRange(entities);
    }

    public IEnumerable<TelefonoTrainer> Find(Expression<Func<TelefonoTrainer, bool>> expression)
    {
       return  _context.Set<TelefonoTrainer>().Where(expression);
    }

    public async Task<IEnumerable<TelefonoTrainer>> GetAllAsync()
    {
        return await  _context.Set<TelefonoTrainer>().ToListAsync();
    }

    public async  Task<TelefonoTrainer>? GetByIdAsync(int id)
    {
        return await _context.Set<TelefonoTrainer>().FindAsync(id);
    }


    public void Remove(TelefonoTrainer entity)
    {
        _context.Set<TelefonoTrainer>().Remove(entity);
    }

    public void RemoveRange(IEnumerable<TelefonoTrainer> entities)
    {
       _context.Set<TelefonoTrainer>().RemoveRange(entities);
    }

    public void Update(TelefonoTrainer entity)
    {
        _context.Set<TelefonoTrainer>().Update(entity);
    }
}