using System;
using System.Collections.Generic;

#nullable disable

namespace WebApi.Models
{
    public partial class ServiceWorker
    {
        public ServiceWorker()
        {
            Issues = new HashSet<Issue>();
        }

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }

        public virtual ICollection<Issue> Issues { get; set; }
    }
}
