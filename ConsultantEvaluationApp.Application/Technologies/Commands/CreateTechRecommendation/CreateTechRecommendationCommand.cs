﻿using ConsultantEvaluationApp.Application.EvaluationProcess.ViewModels;
using ConsultantEvaluationApp.Application.Technologies.Queries.GetTechnologiesList;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsultantEvaluationApp.Application.Technologies.Commands.CreateTechRecommendation
{
    public class CreateTechRecommendationCommand : IRequest<int>
    {
        public CreateTechRecommendationCommand()
        {

        }

        public string RecommendationNotes { get; set; }
        public int EvaluatorId { get; set; }
        public int TechId { get; set; }
       

    }
}
