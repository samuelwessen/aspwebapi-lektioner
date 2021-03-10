using System;
using System.Collections.Generic;

#nullable disable

namespace WebApi.Models
{
    public partial class Issue
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public int ServiceWorkerId { get; set; }
        public DateTime IssueDate { get; set; }
        public DateTime? ResovleDate { get; set; }
        public string IssueDescription { get; set; }
        public string IssueStatus { get; set; }

        public virtual Customer Customer { get; set; }
        public virtual ServiceWorker ServiceWorker { get; set; }
    }
}
