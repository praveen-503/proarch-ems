using Proarch.Ems.Core.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Proarch.Ems.Core.Domain.Models
{
    public class ClientModel : AuditModel
    {
        public ClientModel()
        {
            IsExisted = true;
        }
        public string Name { get; set; }

        public bool IsExisted { get; set; }
        public ICollection<ProjectModel> Projects { get; set; }
        public bool IsValid()
        {
            return string.IsNullOrEmpty(Name) == false;
        }
    }
   
}
