﻿using Dapper;
using DevFreela.Core.DTOs;
using DevFreela.Core.Repositories;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace DevFreela.Infrastructure.Persistence.Repositories
{
    public class SkillRepository : ISkillRepository
    {
        private readonly string _connectionString;

        public SkillRepository ( IConfiguration configuration )
        {
            _connectionString = configuration.GetConnectionString("DevFreelaCs");
        }

        public async Task<List<SkillDTO>> GetAllAsync ( )
        {
            //Consulta ao BD usando o Dapper
            using (var sqlConnection = new SqlConnection ( _connectionString ))
            {
                sqlConnection.Open ( );

                var script = "SELECT Id, Description FROM Skills";

                var skills = await sqlConnection.QueryAsync<SkillDTO> ( script );

                return skills.ToList ( );

                //Consulta ao BD usando o EF Core
                //var skills = _dbContext.Skills;

                //var skillsViewModel = skills
                //    .Select(s => new SkillViewModel(s.Id, s.Description))
                //    .ToList();

                //return skillsViewModel;
            }
        }
    }
}
