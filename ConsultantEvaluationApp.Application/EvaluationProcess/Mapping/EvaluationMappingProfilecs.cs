using AutoMapper;
using ConsultantEvaluationApp.Application.EvaluationProcess.Commands;
using ConsultantEvaluationApp.Application.EvaluationProcess.ViewModels;
using ConsultantEvaluatonApp.Domain;
using ConsultantEvaluatonApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsultantEvaluationApp.Application.EvaluationProcess.Mapping
{
    public class EvaluationMappingProfilecs : Profile
    {
        public EvaluationMappingProfilecs()
        {
            CreateMap<ConsultantEvaluatonApp.Domain.Entities.EvaluationProcess, EvaluationProcessVM>();
            CreateMap<Evaluator, EvaluatorVM>();
            CreateMap<EvaluationTechnology, EvaluationTechnologyVM>();

            CreateMap<EvaluationProcessVM, ConsultantEvaluatonApp.Domain.Entities.EvaluationProcess>();
            CreateMap<EvaluatorVM, Evaluator>();
            CreateMap<EvaluationTechnologyVM, EvaluationTechnology>();

            CreateMap<CreateEvaluationCommand, ConsultantEvaluatonApp.Domain.Entities.EvaluationProcess>();

            CreateMap<CreateEvaluationCommand, Evaluator>();

            CreateMap<CreateEvaluationCommand, EvaluationTechnology>();


        }
    }
    
}
