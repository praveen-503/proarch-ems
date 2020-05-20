using System;
using System.Collections.Generic;
using System.Text;

namespace Proarch.Ems.Core.Domain.Common
{
    public interface ICreated
    {
        string CreatedBy { get; set; }
        DateTimeOffset CreatedAt { get; set; }
    }

    public interface IModified
    {
        string LastModifiedBy { get; set; }
        DateTimeOffset? LastModifiedAt { get; set; }
    }

    public interface ISoftDelete
    {
        bool IsDelete { get; set; }
    }

    public interface IAuditModel : ICreated, IModified, ISoftDelete
    {
    }
}
