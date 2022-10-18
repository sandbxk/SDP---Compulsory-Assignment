using Application.DTOs;
using Application.Interfaces;
using AutoMapper;
using Domain;
using FluentValidation;

namespace Application;

public class BoxService : IBoxService
{
    
    private readonly IBoxRepository _boxRepository;
    private readonly IMapper _mapper;
    private readonly IValidator<PostBoxDTO> _postBoxValidator;
    private readonly IValidator<Box> _boxValidator;

    public BoxService(
        IBoxRepository boxRepository, 
        IMapper mapper, 
        IValidator<PostBoxDTO> postBoxValidator, 
        IValidator<Box> boxValidator)
    {
        _boxRepository = boxRepository;
        _mapper = mapper;
        _postBoxValidator = postBoxValidator;
        _boxValidator = boxValidator;
    }

    public List<Box> GetAllBoxes()
    {
        return _boxRepository.All().ToList();
    }

    public Box CreateNewBox(PostBoxDTO dto)
    {
        var validation = _postBoxValidator.Validate(dto);
        if (!validation.IsValid)
            throw new ValidationException(validation.ToString());

        return _boxRepository.Create(_mapper.Map<Box>(dto));
    }

    public Box GetBoxById(int id)
    {
        return _boxRepository.Single(id);
    }

    public void RebuildDb()
    {
        _boxRepository.BuildDB();
    }
    

    public Box UpdateBox(int id, Box box)
    {
        if (id != box.Id)
            throw new ValidationException("ID in body and route are different");
        var validation = _boxValidator.Validate(box);
        if (!validation.IsValid)
            throw new ValidationException(validation.ToString());
        return _boxRepository.Update(id, box);
    }

    public bool DeleteBox(int id)
    {
        return _boxRepository.Delete(id);
    }
}