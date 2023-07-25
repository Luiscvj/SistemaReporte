using System.Linq.Expressions;
using Core.Entities;
using Core.Interfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository;


public class CategoriaRepository : ICategoria
{
    protected SistemReporteContext _context;
    public CategoriaRepository(SistemReporteContext context)
    {
        
        _context = context;
    }




    public void AddCategory(Categoria entity)
    {
       _context.Set<Categoria>().Add(entity);
    }

    public void AddRangeCategory(IEnumerable<Categoria> entities)
    {
       _context.Set<Categoria>().AddRange(entities);
    }

    public IEnumerable<Categoria> Find(Expression<Func<Categoria, bool>> expression)
    {
        return _context.Set<Categoria>().Where(expression);
    }

    public async Task<IEnumerable<Categoria>> GetAllCategories()
    {
        return  await _context.Categorias
        .Include(c => c.Hardwares)
        .Include(c => c.Softwares)
        .Include(c => c.Insidencias).ToListAsync();
    }

    public async Task<Categoria> GetCategoryById(int id)
    {
        return  await _context.Categorias
        .Include(c => c.Hardwares)
        .Include(c => c.Softwares)
        .Include(c => c.Insidencias)
        .FirstOrDefaultAsync(c=> c.Id == id);
    }

    public void RemoveCategoriaByID(Categoria entity)
    {
        _context.Set<Categoria>().Remove(entity);
    }

    public void RemoveRangeCategories(IEnumerable<Categoria> entities)
    {
        _context.Set<Categoria>().RemoveRange(entities);
    }

    public void UpdateCategory(Categoria entity)
    {
        _context.Set<Categoria>().Update(entity);
    }
}