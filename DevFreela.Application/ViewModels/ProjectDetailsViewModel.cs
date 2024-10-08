﻿namespace DevFreela.Application.ViewModels
{
    public class ProjectDetailsViewModel
    {
        public ProjectDetailsViewModel ( int id, string title, string description, decimal totalCoust, DateTime? startedAt, DateTime? finishedAt, string clientFullName, string freelancerFullName )
        {
            Id = id;
            Title = title;
            Description = description;
            TotalCoust = totalCoust;
            StartedAt = startedAt;
            FinishedAt = finishedAt;
            ClientFullName = clientFullName;
            FreelanceFullName = freelancerFullName;
        }

        public int Id { get; private set; }
        public string Title { get; private set; }
        public string Description { get; private set; }
        public decimal TotalCoust { get; private set; }
        public DateTime? StartedAt { get; private set; }
        public DateTime? FinishedAt { get; private set; }
        public string ClientFullName { get; private set; }
        public string FreelanceFullName { get; private set; }
    }
}
