using System.Linq.Expressions;
using Core.Entities;

namespace Core.Interfaces;


public interface ICategoria{
    Task<Categoria> GetCategoryById(int id);
    Task<IEnumerable<Categoria>> GetAllCategories();
    IEnumerable<Categoria> Find(Expression<Func<Categoria, bool>> expression);
    void AddCategory(Categoria entity);
    void AddRangeCategory(IEnumerable<Categoria> entities);
    void RemoveCategoriaByID(Categoria entity);
    void RemoveRangeCategories(IEnumerable<Categoria> entities);
    void UpdateCategory(Categoria entity);
}