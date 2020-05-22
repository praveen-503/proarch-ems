using System;
using System.Collections.Generic;
using System.Text;

namespace Proarch.Ems.Core.Domain.Common
{
    public interface ICreated
    {
        string CreatedBy { get; set; }
        DateTime CreatedAt { get; set; }
    }

    public interface IModified
    {
        string LastModifiedBy { get; set; }
        DateTime? LastModifiedAt { get; set; }
    }

    public interface ISoftDelete
    {
        bool IsDelete { get; set; }
    }

    public interface IAuditModel : ICreated, IModified, ISoftDelete
    {
    }
}
