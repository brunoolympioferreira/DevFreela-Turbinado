using System;
using System.Collections.Generic;
using System.Text;
using DevFreela.Core.Entities;

namespace DevFreela.Application.ViewModels
{
    public class ProjectDetailsViewModel
    {
        public ProjectDetailsViewModel(int id, string title, string description, decimal totalCost, DateTime? startedAt, DateTime? finishedAt, string clientFullName, string freelancerFullName, List<ProjectComment> comments)
        {
            Id = id;
            Title = title;
            Description = description;
            TotalCost = totalCost;
            StartedAt = startedAt;
            FinishedAt = finishedAt;
            ClientFullName = clientFullName;
            FreelancerFullName = freelancerFullName;
            Comments = comments.Select(c => $"{c.User.FullName}: {c.Content}").ToList();
        }

        public int Id { get; private set; }
        public string Title { get; private set; }
        public string Description { get; private set; }
        public decimal TotalCost { get; private set; }
        public DateTime? StartedAt { get; private set; }
        public DateTime? FinishedAt { get; private set; }
        public string ClientFullName { get; private set; }
        public string FreelancerFullName { get; private set; }
        public List<string> Comments { get; private set; }
    }
}
