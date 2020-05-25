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
    }

    internal class ProjectUsecase : IProjectUsecase
    {
        private readonly IProjectRepository _projectRepository;

        public ProjectUsecase(IProjectRepository projectRepository)
        {
            _projectRepository = projectRepository;
        }
        async Task<List<ProjectModel>> IProjectUsecase.GetPoejctsAsync()
        {
            return await _projectRepository.GetProjectsAsync();
        }
    }
}
