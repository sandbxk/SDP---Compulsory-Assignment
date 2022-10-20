using Application.DTOs;
using Domain;
using FluentValidation;

namespace Application.Validators;

public class BoxValidator : AbstractValidator<Box>
{
    public BoxValidator()
    {
        RuleFor(box => box.BoxDepth).GreaterThan(0);
        RuleFor(box => box.Height).GreaterThan(0);
        RuleFor(box => box.Width).GreaterThan(0);
        RuleFor(box => box.Weight).GreaterThan(0);
        RuleFor(box => box.Id).GreaterThan(0);
    }
    
}

public class PostBoxValidator : AbstractValidator<PostBoxDTO>
{
    public PostBoxValidator()
    {
        RuleFor(box => box.BoxDepth).GreaterThan(0);
        RuleFor(box => box.Height).GreaterThan(0);
        RuleFor(box => box.Width).GreaterThan(0);
        RuleFor(box => box.Weight).GreaterThan(0);
    }
    
}