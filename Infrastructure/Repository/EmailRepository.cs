using System.Linq.Expressions;
using Core.Entities;
using Core.Interfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository;

public class EmailRepository : IEmail
{
    protected readonly SistemReporteContext _context;

    public EmailRepository(SistemReporteContext context){
        _context = context;
    }
    public void AddEmail(Email entitiy)
    {
       _context.Set<Email>().Add(entitiy);
    }

    public void AddEmailsRange(Email entities)
    {
        _context.Set<Email>().AddRange(entities);
    }

    public IEnumerable<Email> Find(Expression<Func<Email, bool>> expression)
    {
        return _context.Set<Email>().Where(expression);
    }

    public async Task<IEnumerable<Email>> GetAllEmails()
    {
       return await _context.Set<Email>().ToListAsync();
    }

    public async Task<Email> GetEmailById(int id)
    {
        return await _context.Set<Email>().FindAsync(id);
    }

    public void RemoveEmail(Email entity)
    {
        _context.Set<Email>().Remove(entity);
    }

    public void RemoveRangeEmails(IEnumerable<Email> entities)
    {
        _context.Set<Email>().RemoveRange(entities);
    }

    public void UpdateEmail(Email entitiy)
    {
        _context.Set<Email>().Update(entitiy);
    }
}