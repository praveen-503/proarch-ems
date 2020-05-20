using System;
using System.Collections.Generic;
using System.Text;

namespace Proarch.Ems.Core.Domain.Common
{
    public class AuditModel :Model , IAuditModel
    {
        public string CreatedBy { get; set; }
        public DateTimeOffset CreatedAt { get; set; }
        public string LastModifiedBy { get; set; }
        public DateTimeOffset? LastModifiedAt { get; set; }
        public bool IsDelete { get; set; }
    }
}
