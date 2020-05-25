using System;
using System.Collections.Generic;
using System.Text;

namespace ConsultantEvaluationApp.Application.SubAreas.ViewModels
{
    public class SubAreaFeedbackVM
    {
        public int Id { get; set; }
        public string FeedbackNotes { get; set; }
        public int EvaluatorId { get; set; }
        public int SubTechId { get; set; }
    }
}
