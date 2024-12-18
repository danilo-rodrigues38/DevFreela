﻿using DevFreela.Core.Repositories;
using MediatR;

namespace DevFreela.Application.Commands.FinishProject
{
    public class FinishProjectCommandHandler : IRequestHandler<FinishProjectCommand, Unit>
    {
        private readonly IProjectRepository _projectRepository;

        public async Task<Unit> Handle ( FinishProjectCommand request, CancellationToken cancellationToken )
        {
            var project = await _projectRepository.GetByIdAsync(request.Id);

            project.Finish ( );

            await _projectRepository.SaveChengesAsync ( );

            return Unit.Value;
        }
    }
}
