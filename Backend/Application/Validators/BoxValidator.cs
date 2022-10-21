using Application.DTOs;
using Domain;
using FluentValidation;

namespace Application.Validators;

public class BoxValidator : AbstractValidator<Box>
{
    public BoxValidator()
    {
        RuleFor(box => box.YLength).GreaterThan(0);
        RuleFor(box => box.ZHeight).GreaterThan(0);
        RuleFor(box => box.XWidth).GreaterThan(0);
        RuleFor(box => box.Weight).GreaterThan(0);
        RuleFor(box => box.Id).GreaterThan(0);
    }
    
}

public class PostBoxValidator : AbstractValidator<PostBoxDTO>
{
    public PostBoxValidator()
    {
        RuleFor(box => box.YLength).GreaterThan(0);
        RuleFor(box => box.ZHeight).GreaterThan(0);
        RuleFor(box => box.XWidth).GreaterThan(0);
        RuleFor(box => box.Weight).GreaterThan(0);
    }
    
}