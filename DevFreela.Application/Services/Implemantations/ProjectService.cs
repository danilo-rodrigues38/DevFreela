﻿using DevFreela.Application.InputModels;
using DevFreela.Application.Services.Interfaces;
using DevFreela.Application.ViewModels;
using DevFreela.Core.Entities;
using DevFreela.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace DevFreela.Application.Services.Implemantations
{
    public class ProjectService : IProjectService
    {
        private readonly DevFreelaDbContext _dbContext;

        public ProjectService(DevFreelaDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public int Create ( NewProjectInputModel inputModel )
        {
            var project = new Project(inputModel.Title, inputModel.Description, inputModel.IdCliente, inputModel.IdFreelancer, inputModel.TotalCost);

            _dbContext.Projects.Add(project);
            _dbContext.SaveChanges ( );

            return project.Id;
        }

        public void CreateComment ( CreateCommentInputModel inputModel )
        {
            var commnet = new ProjectComment(inputModel.Content, inputModel.IdProject, inputModel.IsUser);

            _dbContext.ProjectComments.Add(commnet);

            _dbContext.SaveChanges ( );
        }

        public void Delelte ( int id )
        {
            var project = _dbContext.Projects.SingleOrDefault(p => p.Id == id);

            project.Cancel();

            _dbContext.SaveChanges ( );
        }

        public void Finish ( int id )
        {
            var project = _dbContext.Projects.SingleOrDefault(p => p.Id == id);

            project.Finish();

            _dbContext.SaveChanges ( );
        }

        public List<ProjectViewModel> GetAll ( string query )
        {
            var projects = _dbContext.Projects;

            var projectsViewModel = projects
                .Select(p => new ProjectViewModel (p.Id, p.Title, p.CreateAt))
                .ToList();

            return projectsViewModel;
        }

        public ProjectDetailsViewModel GetById ( int id )
        {
            var project = _dbContext.Projects
                .Include(p => p.Client)
                .Include(p => p.Freelancer)
                .SingleOrDefault (p => p.Id == id);

            if (project == null) return null;

            var projectDetailsViewModel = new ProjectDetailsViewModel(
                project.Id,
                project.Title,
                project.Description,
                project.TotalCost,
                project.StartedAt,
                project.FinishedAt,
                project.Client.FullName,
                project.Freelancer.FullName
                );

            return projectDetailsViewModel;
        }

        public void Start ( int id )
        {
            var project = _dbContext.Projects.SingleOrDefault(p => p.Id == id);

            project.Start();

            _dbContext.SaveChanges ( );
        }

        public void Update ( UpdateProjectInputModel inputModel )
        {
            var project = _dbContext.Projects.SingleOrDefault(p => p.Id == inputModel.Id);

            project.Update(inputModel.Title, inputModel.Description, inputModel.TotalCost);

            _dbContext.SaveChanges ( );
        }
    }
}
