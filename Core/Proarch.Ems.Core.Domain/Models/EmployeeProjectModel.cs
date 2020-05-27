using Proarch.Ems.Core.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Proarch.Ems.Core.Domain.Models
{
    public class EmployeeProjectModel : AuditModel
    {
        public int EmployeeId { get; set; }
        public EmployeeModel Employee { get; set; }

        public int ProjectId { get; set; }
        public ProjectModel Project { get; set; }

    }
}
