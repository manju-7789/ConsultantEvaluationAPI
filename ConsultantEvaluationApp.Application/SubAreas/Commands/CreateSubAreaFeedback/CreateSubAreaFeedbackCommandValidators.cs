using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsultantEvaluationApp.Application.SubAreas.Commands.CreateSubAreaFeedback
{
    public class CreateSubAreaFeedbackCommandValidators : AbstractValidator<CreateSubAreaFeedbackCommand>
    {
        public CreateSubAreaFeedbackCommandValidators()
        {
            RuleFor(v => v.FeedbackNotes).NotNull().MaximumLength(150);
            RuleFor(v => v.EvaluatorId).NotNull();
            RuleFor(v => v.SubTechId).NotEmpty();
        }
    }
}
