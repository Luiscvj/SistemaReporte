using System.Linq.Expressions;
using Core.Entities;

namespace Core.Interfaces;

public interface IEmail
{
    Task<Email> GetEmailById(int id);
    Task<IEnumerable<Email>> GetAllEmails();
    IEnumerable<Email> Find(Expression<Func<Email,bool>> expression);
    void RemoveEmail(Email entity);
    void RemoveRangeEmails(IEnumerable<Email> entities);
    void UpdateEmail(Email entitiy);
    void AddEmail(Email entitiy);
    void AddEmailsRange(Email entities);

}