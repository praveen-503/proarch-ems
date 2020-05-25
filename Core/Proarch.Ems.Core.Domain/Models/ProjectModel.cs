using Proarch.Ems.Core.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Proarch.Ems.Core.Domain.Models
{
    public class ProjectModel: AuditModel
    {
        public string Name { get; set; }
        public int ClientId { get; set; }
        public ClientModel Client { get; set; }
        public IList<EmployeeProjectModel> EmployeeProjects { get; set; }

    }
}
