﻿using System.Threading;
using System.Threading.Tasks;
using HR.Department.Core.Interfaces;
using MediatR;

namespace HR.Department.WebApi.Features.Position.Comands.CreatePosition
{
    public class CreatePositionCommandHandler : IRequestHandler<CreatePositionCommand>
    {
        private readonly IRepository<Core.Entities.Position> _repository;

        public CreatePositionCommandHandler(IRepository<Core.Entities.Position> repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(CreatePositionCommand request, CancellationToken cancellationToken)
        {
            await _repository.AddAsync(new Core.Entities.Position(
                request.Name,
                request.TypePositionId,
                request.Description), cancellationToken);

            await _repository.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
