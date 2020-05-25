using AutoMapper;
using ConsultantEvaluationApp.Application.EvaluationProcess.ViewModels;
using ConsultantEvaluationApp.Application.Technologies.Commands.CreateTechRecommendation;
using ConsultantEvaluationApp.Application.Technologies.ViewModels;
using ConsultantEvaluatonApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsultantEvaluationApp.Application.Technologies.Mapping
{
   public class TechnologyMappingProfile : Profile
    {
        public TechnologyMappingProfile()
        {
            CreateMap<TechAreaRecommendation, TechnologyRecommendationVM>();
           

            CreateMap<TechnologyRecommendationVM, TechAreaRecommendation>();

            CreateMap<CreateTechRecommendationCommand, TechAreaRecommendation>();

        }
    }
}
