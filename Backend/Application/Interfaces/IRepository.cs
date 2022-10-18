﻿using Domain;

namespace Application.Interfaces;

public interface IRepository<T>
{
    IEnumerable<T> All();
    T Create(T t);
    bool Delete(int id);
    IEnumerable<T> SearchByName(string tName);
    T Single(long id);
    T Update(long id, T model);
    
    void BuildDB();
}

public interface IBoxRepository : IRepository<Box> { }