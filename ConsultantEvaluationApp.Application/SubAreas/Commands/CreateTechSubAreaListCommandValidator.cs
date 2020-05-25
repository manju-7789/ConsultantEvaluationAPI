using ConsultantEvaluationApp.Application.Common.Interfaces;
using ConsultantEvaluationApp.Application.SubAreas.Queries.GetTechSubAreaList;
using FluentValidation;
using FluentValidation.Validators;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsultantEvaluationApp.Application.SubAreas.Commands
{
    class CreateTechSubAreaListCommandValidator : AbstractValidator<CreateTechSubAreaListCommand>
    {
        private readonly IApplicationDbContext _context;

        public CreateTechSubAreaListCommandValidator(IApplicationDbContext context)
        {
            _context = context;

            RuleFor(v => v.TechId).SetValidator(new MustHaveTechIdPropertyValidator());
            RuleFor(v => v.Name)
                .NotEmpty().WithMessage("Name is required.")
                .MaximumLength(50).WithMessage("Name must not exceed 50 characters.")
                .MustAsync(BeUniqueName).WithMessage("The specified name already exists.");
        }

        public async Task<bool> BeUniqueName(string name, CancellationToken cancellationToken)
        {
            return await _context.TechnologyAreas
                .AllAsync(l => l.Name != name);
        }

        public class MustHaveTechIdPropertyValidator : PropertyValidator
        {
            public MustHaveTechIdPropertyValidator()
                : base("Property {PropertyName} should not be an empty list.")
            {
            }

            protected override bool IsValid(PropertyValidatorContext context)
            {
                var list = context.PropertyValue as IList<TechSubAreaListVM>;
                return list != null && list.Any();
            }
        }
    }
}
