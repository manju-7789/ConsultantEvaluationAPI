using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsultantEvaluationApp.Application.Technologies.Commands.CreateTechRecommendation
{
    public class CreateTechRecommendationCommandValidator : AbstractValidator<CreateTechRecommendationCommand>
    {
        public CreateTechRecommendationCommandValidator()
        {
            RuleFor(v => v.RecommendationNotes).NotNull().MaximumLength(150);
            RuleFor(v => v.EvaluatorId).NotNull();
            RuleFor(v => v.TechId).NotEmpty();
        }
    }
}
