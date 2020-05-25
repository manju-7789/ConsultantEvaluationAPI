using AutoMapper;
using ConsultantEvaluationApp.Application.SubAreas.Commands.CreateSubAreaFeedback;
using ConsultantEvaluationApp.Application.SubAreas.ViewModels;
using ConsultantEvaluatonApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsultantEvaluationApp.Application.SubAreas.Mapping
{
    public class SubAreaMappingProfile : Profile
    {
        public SubAreaMappingProfile()
        {
            CreateMap<SubAreaFeedback, SubAreaFeedbackVM>();


            CreateMap<SubAreaFeedbackVM, SubAreaFeedback>();

            CreateMap<CreateSubAreaFeedbackCommand, SubAreaFeedback>();

        }
    }
}
