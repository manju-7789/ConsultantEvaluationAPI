using AutoMapper;
using ConsultantEvaluationApp.Application.Common.Interfaces;
using ConsultantEvaluatonApp.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsultantEvaluationApp.Application.Technologies.Commands.CreateTechRecommendation
{
   public class CreateTechRecommendationCommandHandler : IRequestHandler<CreateTechRecommendationCommand, int>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public CreateTechRecommendationCommandHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<int> Handle(CreateTechRecommendationCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<TechAreaRecommendation>(request);

            _context.TechAreaRecommendations.Add(entity);
            await _context.SaveChangesAsync(cancellationToken);
            return entity.Id;
        }
    }
}
