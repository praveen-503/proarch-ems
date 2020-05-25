﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
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
            var projectModel = await _context.Projects.FindAsync(id);

            if (projectModel == null)
            {
                return NotFound();
            }

            return projectModel;
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
            _context.Projects.Add(projectModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProjectModel", new { id = projectModel.Id }, projectModel);
        }

        // DELETE: api/Project/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ProjectModel>> DeleteProjectModel(int id)
        {
            var projectModel = await _context.Projects.FindAsync(id);
            if (projectModel == null)
            {
                return NotFound();
            }

            _context.Projects.Remove(projectModel);
            await _context.SaveChangesAsync();

            return projectModel;
        }

        private bool ProjectModelExists(int id)
        {
            return _context.Projects.Any(e => e.Id == id);
        }
    }
}
