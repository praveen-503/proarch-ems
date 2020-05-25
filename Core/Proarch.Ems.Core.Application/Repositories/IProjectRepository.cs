using Proarch.Ems.Core.Application.Common;
using Proarch.Ems.Core.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Proarch.Ems.Core.Application.Repositories
{
    public interface IProjectRepository : IRepository
    {
        Task<List<ProjectModel>> GetProjectsAsync();
    }
}
