using System;
using System.Collections.Generic;
using System.Text;

namespace ConsultantEvaluationApp.Application.EvaluationProcess.ViewModels
{
    public class EvaluatorVM
    {
        public int EvaluatorId { get; set; }
        public string EvaluatorEmail { get; set; }
        public bool IsSubmitted { get; set; }
    }
}
