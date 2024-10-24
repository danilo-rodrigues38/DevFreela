﻿using Dapper;
using DevFreela.Infrastructure.Persistence;
using MediatR;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace DevFreela.Application.Commands.StartProject
{
    public class StartProjectCommandHandler : IRequestHandler<StartProjectCommand, Unit>
    {
        private readonly DevFreelaDbContext _dbContext;
        private readonly string _connectionString;

        public StartProjectCommandHandler(DevFreelaDbContext dbContext, IConfiguration configuration)
        {
            _dbContext = dbContext;
            _connectionString = configuration.GetConnectionString("DevFreelaCs");
        }

        public async Task<Unit> Handle ( StartProjectCommand request, CancellationToken cancellationToken )
        {
            //Buscando um projeto pelo Id no BD usando o EF Core
            var project = await _dbContext.Projects.SingleOrDefaultAsync(p => p.Id == request.Id);

            project.Start ( );

            //_dbContext.SaveChanges ( );


            //Atualizando o BD usando o Dapper
            using (var sqlConnection = new SqlConnection ( _connectionString ))
            {
                sqlConnection.Open ( );

                var script = "UPDATE Projects SET Status = @status, StartedAt = @startedat Where Id = @id";

                sqlConnection.Execute ( script, new { status = project.Status, startedat = project.StartedAt, request.Id } );
            }

            return Unit.Value;
        }
    }
}
