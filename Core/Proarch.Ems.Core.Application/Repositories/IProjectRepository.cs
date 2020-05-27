using Proarch.Ems.Core.Application.Common;
using Proarch.Ems.Core.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Proarch.Ems.Core.Application.Repositories
{
    public interface IProjectRepository : IRepository
    {
        Task<List<ProjectModel>> GetProjectsAsync();
        Task<ProjectModel> GetProjectByIdAsync(int id);
        Task<int> CreateProjectAsync(ProjectModel project);
        Task<bool> UpdateProjectAsync(ProjectModel projectModel);
        Task<bool> DeleteProjectAsync(int Id);
    }
}
