using System;
using System.Collections.Generic;
using System.Text;

namespace Proarch.Ems.Core.Domain.Common
{
    public abstract class Model
    {
        public int Id { get; set; }
        public byte[] RowVersion { get; set; }
    }
}
