using Application.Interfaces;
using Domain;

namespace Infrastructure;

public class BoxRepository : IBoxRepository
{
    
    //Use sqlKata to query the database
    public IEnumerable<Box> All()
    {
        throw new NotImplementedException();
    }

    public Box Create(Box t)
    {
        throw new NotImplementedException();
    }

    public Box Delete(long id)
    {
        throw new NotImplementedException(); //Return deleted box
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