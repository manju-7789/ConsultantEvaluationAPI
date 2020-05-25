using ConsultantEvaluationApp.Application.Common.Interfaces;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsultantEvaluationApp.Application.Technologies.Commands.CreateTechnologyList
{
    public class CreateTechnologyListCommandValidator : AbstractValidator<CreateTechnologyListCommand>
    {
        private readonly IApplicationDbContext _context;

        public CreateTechnologyListCommandValidator(IApplicationDbContext context)
        {
            _context = context;

            RuleFor(v => v.Name)
                .NotEmpty().WithMessage("Name is required.")
                .MaximumLength(50).WithMessage("Name must not exceed 50 characters.")
                .MustAsync(BeUniqueName).WithMessage("The specified title already exists.");
        }

        public async Task<bool> BeUniqueName(string name, CancellationToken cancellationToken)
        {
            return await _context.TechnologyAreas
                .AllAsync(l => l.Name != name);
        }
    }
}
