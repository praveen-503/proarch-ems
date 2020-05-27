using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Proarch.Ems.Core.Application.Usecases;
using Proarch.Ems.Core.Domain.Models;
using Proarch.Ems.Infrastructure.Data.Common;

namespace Proarch.Ems.Presentation.API.Controllers.Project
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectController : ControllerBase
    {
        private readonly EmsDbContext _context;
        private readonly IProjectUsecase _projectUsecase;

        public ProjectController(EmsDbContext context,IProjectUsecase projectUsecase)
        {
            _context = context;
            _projectUsecase = projectUsecase;
        }

        // GET: api/Project
        [HttpGet]
        public async Task<ActionResult> GetProjects()
        {
            var projects = await _projectUsecase.GetPoejctsAsync().ConfigureAwait(true);
            if(projects == null)
            {
                return NotFound();
            }
            return Ok(projects);
        }

        // GET: api/Project/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ProjectModel>> GetProjectModel(int id)
        {
            var project = await _projectUsecase.GetProjectByIdAsync(id).ConfigureAwait(true);

            if (project == null)
            {
                return NotFound();
            }

            return project;
        }

        // PUT: api/Project/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProjectModel(int id, ProjectModel projectModel)
        {
            if (id != projectModel.Id)
            {
                return BadRequest();
            }
            var isProjectUpdated = await _projectUsecase.UpdateProjectAsync(projectModel).ConfigureAwait(true);
            
            _context.Entry(projectModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProjectModelExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Project
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<ProjectModel>> PostProjectModel(ProjectModel projectModel)
        {
            var projectID = await _projectUsecase.CreateProjectAsync(projectModel).ConfigureAwait(true);
            if (projectID == 0)
            {
                return BadRequest("Project is already existed with Id or Name");
            }
            return CreatedAtAction("GetProjectModel", new { id = projectID }, projectModel);
        }

        // DELETE: api/Project/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ProjectModel>> DeleteProjectModel(int id)
        {
            var isDeleted = await _projectUsecase.DeleteProjectAsync(id).ConfigureAwait(true);
            if (!isDeleted)
            {
                return NotFound();
            }
            return Ok();
        }

        private bool ProjectModelExists(int id)
        {
            return _context.Projects.Any(e => e.Id == id);
        }
    }
}
