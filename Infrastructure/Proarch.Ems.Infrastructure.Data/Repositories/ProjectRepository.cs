using Microsoft.EntityFrameworkCore;
using Proarch.Ems.Core.Application.Common;
using Proarch.Ems.Core.Application.Repositories;
using Proarch.Ems.Core.Domain.Models;
using Proarch.Ems.Infrastructure.Data.Common;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Proarch.Ems.Infrastructure.Data.Repositories
{
    internal class ProjectRepository : ExceptionHelper, IProjectRepository
    {
        private readonly EmsDbContext _context;

        public ProjectRepository(EmsDbContext context)
        {
            _context = context;
        }

        async Task<int> IProjectRepository.CreateProjectAsync(ProjectModel project)
        {
            var existProject = await _context.Projects.SingleOrDefaultAsync(e => e.Id == project.Id || e.Name == project.Name);
            if (existProject != null)
            {
                return 0;
            }
            _context.Projects.Add(project);
            await _context.SaveChangesAsync();
            return project.Id;

        }

        async Task<ProjectModel> IProjectRepository.GetProjectByIdAsync(int id)
        {
            return  await _context.Projects.FindAsync(id);
        }

        async Task<List<ProjectModel>> IProjectRepository.GetProjectsAsync()
        {
            return await _context.Projects.ToListAsync();
        }

        async Task<bool> IProjectRepository.UpdateProjectAsync(ProjectModel projectModel)
        {
            _context.Entry(projectModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProjectModelExists(projectModel.Id))
                {
                    return false;
                }
                else
                {
                    throw;
                }
            }

            return true;
        }

        private bool ProjectModelExists(int id)
        {
            var project = _context.Employees.SingleOrDefaultAsync(e => e.Id == id && e.IsDelete == false);
            if (project == null)
            {
                return false;
            }
            return true;
        }

        async Task<bool> IProjectRepository.DeleteProjectAsync(int Id)
        {
            var project = await _context.Projects.SingleOrDefaultAsync(e => e.Id == Id && e.IsDelete == false).ConfigureAwait(false);
            if (project != null)
            {
                project.IsDelete = true;
                _context.Entry(project).State = EntityState.Modified;

                try
                {
                    await _context.SaveChangesAsync().ConfigureAwait(false);
                }
                catch (DbUpdateConcurrencyException)
                {
                    return false;
                }

                return true;
            }
            return false;
        }
    }
}
