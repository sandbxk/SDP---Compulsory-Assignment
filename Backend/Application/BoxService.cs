using Application.DTOs;
using Application.Interfaces;
using Domain;

namespace Application;

public class BoxService : IBoxService

{
    public List<Box> GetAllBoxes()
    {
        throw new NotImplementedException();
    }

    public Box CreateNewBox(PostBoxDTO dto)
    {
        throw new NotImplementedException();
    }

    public Box GetBoxById(int id)
    {
        throw new NotImplementedException();
    }

    public void RebuildDb()
    {
        throw new NotImplementedException();
    }

    public Box UpdateBox(int id, Box box)
    {
        throw new NotImplementedException();
    }

    public Box DeleteBox(int id)
    {
        throw new NotImplementedException();
    }
}