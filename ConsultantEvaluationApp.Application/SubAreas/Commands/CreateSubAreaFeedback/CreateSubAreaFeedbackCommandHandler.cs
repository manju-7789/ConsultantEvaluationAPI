using AutoMapper;
using ConsultantEvaluationApp.Application.Common.Interfaces;
using ConsultantEvaluatonApp.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsultantEvaluationApp.Application.SubAreas.Commands.CreateSubAreaFeedback
{
   public class CreateSubAreaFeedbackCommandHandler : IRequestHandler<CreateSubAreaFeedbackCommand, int>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public CreateSubAreaFeedbackCommandHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<int> Handle(CreateSubAreaFeedbackCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<SubAreaFeedback>(request);

            _context.SubAreaFeedbacks.Add(entity);
            await _context.SaveChangesAsync(cancellationToken);
            return entity.Id;
        }
    }
}
