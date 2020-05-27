using Proarch.Ems.Core.Application.Common;
using Proarch.Ems.Core.Application.Repositories;
using Proarch.Ems.Core.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Proarch.Ems.Core.Application.Usecases
{
    public interface IProjectUsecase : IUsecase
    {
        Task<List<ProjectModel>> GetPoejctsAsync();
        Task<ProjectModel> GetProjectByIdAsync(int id);
        Task<int> CreateProjectAsync(ProjectModel projectModel);
        Task<bool> UpdateProjectAsync(ProjectModel projectModel);
        Task<bool> DeleteProjectAsync(int id);
    }

    internal class ProjectUsecase : IProjectUsecase
    {
        private readonly IProjectRepository _projectRepository;

        public ProjectUsecase(IProjectRepository projectRepository)
        {
            _projectRepository = projectRepository;
        }

        async Task<int> IProjectUsecase.CreateProjectAsync(ProjectModel project)
        {
            return await _projectRepository.CreateProjectAsync(project);
        }

        async Task<bool> IProjectUsecase.DeleteProjectAsync(int id)
        {
            return await _projectRepository.DeleteProjectAsync(id);
        }

        async Task<List<ProjectModel>> IProjectUsecase.GetPoejctsAsync()
        {
            return await _projectRepository.GetProjectsAsync();
        }

        async Task<ProjectModel> IProjectUsecase.GetProjectByIdAsync(int id)
        {
            return await _projectRepository.GetProjectByIdAsync(id);
        }

        async Task<bool> IProjectUsecase.UpdateProjectAsync(ProjectModel projectModel)
        {
            return await _projectRepository.UpdateProjectAsync(projectModel);
        }
    }
}
