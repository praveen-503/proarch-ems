using System;
using System.Collections.Generic;
using System.Text;

namespace Proarch.Ems.Core.Application.Common
{
    public abstract class Entity
    {
        public int Id { get; set; }
        public byte[] RowVersion { get; set; }
    }
}
