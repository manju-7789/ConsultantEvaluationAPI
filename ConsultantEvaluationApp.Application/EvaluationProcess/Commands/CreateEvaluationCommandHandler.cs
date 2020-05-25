using AutoMapper;
using ConsultantEvaluationApp.Application.Common.Interfaces;
using ConsultantEvaluatonApp.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsultantEvaluationApp.Application.EvaluationProcess.Commands
{
    public class CreateEvaluationCommandHandler : IRequestHandler<CreateEvaluationCommand, int>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public CreateEvaluationCommandHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<int> Handle(CreateEvaluationCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<ConsultantEvaluatonApp.Domain.Entities.EvaluationProcess>(request);

            _context.EvaluationProcesses.Add(entity);
            await _context.SaveChangesAsync(cancellationToken);
            return entity.EvaluationId;
        }
    }
}
