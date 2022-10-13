using Application.Interfaces;
using Domain;

namespace Infrastructure;

public class BoxRepository : IBoxRepository
{
    public IEnumerable<Box> All(int page, int maxRecords)
    {
        throw new NotImplementedException();
    }

    public Box Create(Box t)
    {
        throw new NotImplementedException();
    }

    public void Delete(long id)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<Box> SearchByName(string tName)
    {
        throw new NotImplementedException();
    }

    public Box Single(long id)
    {
        throw new NotImplementedException();
    }

    public Box Update(long id, Box model)
    {
        throw new NotImplementedException();
    }
}