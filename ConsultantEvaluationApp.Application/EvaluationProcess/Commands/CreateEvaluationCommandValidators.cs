using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsultantEvaluationApp.Application.EvaluationProcess.Commands
{
    public class CreateEvaluationCommandValidators : AbstractValidator<CreateEvaluationCommand>
    {
        public CreateEvaluationCommandValidators()
        {
            RuleFor(v => v.Title).NotNull();
            RuleFor(v => v.Owner).NotNull();
            RuleFor(v => v.Consultant).NotEmpty();
            RuleFor(v => v.Status).NotEmpty();
           
        }
    }
}
