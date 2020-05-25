using ConsultantEvaluatonApp.Domain.Common;
using ConsultantEvaluatonApp.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsultantEvaluatonApp.Domain.Entities
{
    public class EvaluationProcess : AuditableEntity
    {

        public EvaluationProcess()
        {
            EvaluationTechnologies = new HashSet<EvaluationTechnology>();
            Evaluators = new HashSet<Evaluator>();
        }
        public int EvaluationId { get; set; }
        public string Title { get; set; }
        public string Owner { get; set; }
        public string Consultant { get; set; }
        public string Status { get; set; }

        public EvaluationStatus StatusType { get; set; }

        public ICollection<Evaluator> Evaluators { get; set; }

        public ICollection<EvaluationTechnology> EvaluationTechnologies { get; set; }


        //public bool Uncovered //domain driven 
        //{
        //    get
        //    {
        //        var latestPolicy = Policies.LastOrDefault();
        //        var premiumAmount = RemainingAmount * 0.01;



        //        return (latestPolicy == null || (RemainingTenure > 0 && (latestPolicy.EndDate <= DateTime.Now || latestPolicy.PremiumAmount < premiumAmount)));
        //    }
        //}
    }
}
