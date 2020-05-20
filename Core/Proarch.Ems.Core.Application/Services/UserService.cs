using Proarch.Ems.Core.Application.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Proarch.Ems.Core.Application.Services
{
    public interface IUserService : IService
    {
        string User { get; }
    }
}
