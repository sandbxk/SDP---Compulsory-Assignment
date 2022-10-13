using Domain;

namespace Application.Interfaces;

public interface IRepository<T>
{
    IEnumerable<T> All();
    T Create(T t);
    T Delete(long id);
    IEnumerable<T> SearchByName(string tName);
    T Single(long id);
    T Update(long id, T model);
}

public interface IBoxRepository : IRepository<Box> { }