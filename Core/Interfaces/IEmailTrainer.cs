using System.Linq.Expressions;
using Core.Entities;

namespace Core.Interfaces;


public interface IEmailTrainer
{
    Task<EmailTrainer> ? GetByIdAsync(int id);
    Task<IEnumerable<EmailTrainer>> GetAllAsync();
    IEnumerable<EmailTrainer> Find(Expression<Func<EmailTrainer,bool>> expression);
    void Add(EmailTrainer entity);
    void AddRange(IEnumerable<EmailTrainer> entities);
    void Remove(EmailTrainer entity);
    void RemoveRange(IEnumerable<EmailTrainer> entities);
    void Update(EmailTrainer entity);
}