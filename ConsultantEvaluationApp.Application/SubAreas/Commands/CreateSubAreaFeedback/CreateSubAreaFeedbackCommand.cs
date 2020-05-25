using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsultantEvaluationApp.Application.SubAreas.Commands.CreateSubAreaFeedback
{
    public class CreateSubAreaFeedbackCommand : IRequest<int>
    {
        public CreateSubAreaFeedbackCommand()
        {

        }

        public string FeedbackNotes { get; set; }
        public int EvaluatorId { get; set; }
        public int SubTechId { get; set; }


    }
}
