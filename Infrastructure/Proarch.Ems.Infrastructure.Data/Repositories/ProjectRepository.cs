using Microsoft.EntityFrameworkCore;
using Proarch.Ems.Core.Application.Repositories;
using Proarch.Ems.Core.Domain.Models;
using Proarch.Ems.Infrastructure.Data.Common;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Proarch.Ems.Infrastructure.Data.Repositories
{
    internal class ProjectRepository : IProjectRepository
    {
        private readonly EmsDbContext _context;

        public ProjectRepository(EmsDbContext context)
        {
            _context = context;
        }
        async Task<List<ProjectModel>> IProjectRepository.GetProjectsAsync()
        {
            return await _context.Projects.ToListAsync();
        }
    }
}
