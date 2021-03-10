using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorApp.Models
{
    public class IssueViewModel
    {
        public int Id { get; set; }
        public CustomerViewModel Customer { get; set; }
        public ServiceWorkerViewModel ServiceWorker { get; set; }
        public DateTime IssueDate { get; set; }
        public DateTime? ResovleDate { get; set; }
        public string IssueStatus { get; set; }
    }
}
