using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Proarch.Ems.Core.Domain.Models;
using Proarch.Ems.Infrastructure.Data.Common;

namespace Proarch.Ems.Presentation.API.Controllers.UserStory
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserStoryController : ControllerBase
    {
        private readonly EmsDbContext _context;

        public UserStoryController(EmsDbContext context)
        {
            _context = context;
        }

        // GET: api/UserStory
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserStoryModel>>> GetUserStories()
        {
            return await _context.UserStories.ToListAsync();
        }

        // GET: api/UserStory/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UserStoryModel>> GetUserStoryModel(int id)
        {
            var userStoryModel = await _context.UserStories.FindAsync(id);

            if (userStoryModel == null)
            {
                return NotFound();
            }

            return userStoryModel;
        }

        // PUT: api/UserStory/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUserStoryModel(int id, UserStoryModel userStoryModel)
        {
            if (id != userStoryModel.Id)
            {
                return BadRequest();
            }

            _context.Entry(userStoryModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserStoryModelExists(id))
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

        // POST: api/UserStory
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<UserStoryModel>> PostUserStoryModel(UserStoryModel userStoryModel)
        {
            _context.UserStories.Add(userStoryModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUserStoryModel", new { id = userStoryModel.Id }, userStoryModel);
        }

        // DELETE: api/UserStory/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<UserStoryModel>> DeleteUserStoryModel(int id)
        {
            var userStoryModel = await _context.UserStories.FindAsync(id);
            if (userStoryModel == null)
            {
                return NotFound();
            }

            _context.UserStories.Remove(userStoryModel);
            await _context.SaveChangesAsync();

            return userStoryModel;
        }

        private bool UserStoryModelExists(int id)
        {
            return _context.UserStories.Any(e => e.Id == id);
        }
    }
}
