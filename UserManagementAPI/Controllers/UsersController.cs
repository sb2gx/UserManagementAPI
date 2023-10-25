using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Swashbuckle.AspNetCore.Annotations;
using UserManagementAPI.Data;
using UserManagementAPI.Models;
using UserManagementAPI.Models.Binding;
using UserManagementAPI.Models.View;

namespace UserManagementAPI.Controllers
{
    [EnableCors]
    [Route("api/[controller]")]
    [ApiController]
    [SwaggerResponse((int)HttpStatusCode.OK, "Return data about users", typeof(UserViewModel))]
    public class UsersController : ControllerBase
    {
        private readonly UserManagementContext _context;
        private readonly IMapper _mapper;

        public UsersController(UserManagementContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        /// <summary>
        /// Retrieves a all existing users from the datastore
        /// </summary>
        /// <remarks>Would require pagination</remarks>
        /// <response code="200">Users returned successfully</response>
        /// <response code="400">Request has missing/invalid values</response>
        /// <response code="500">Something is wrong at the server end of things</response>
        // GET: api/Users
        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetUsers()
        {
            if (_context.Users == null)
            {
                return NotFound();
            }
            return await _context.Users.ToListAsync();
        }

        /// <summary>
        /// Retrieves a user from the datastore using the user id key
        /// </summary>
        /// <response code="200">User returned successfully</response>
        /// <response code="400">Request has missing/invalid values</response>
        /// <response code="500">Something is wrong at the server end of things</response>
        // GET: api/Users/5
        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUser(int id)
        {
            if (_context.Users == null)
            {
                return NotFound();
            }
            var user = await _context.Users.FindAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            return user;
        }

        /// <summary>
        /// Searches for users from the datastore using the supplied searchstring
        /// </summary>
        /// <response code="200">Users returned successfully</response>
        /// <response code="400">Request has missing/invalid values</response>
        /// <response code="500">Something is wrong at the server end of things</response>
        // GET: api/Users?searchString=Test
        [HttpGet("search/{searchString}")]
        public async Task<ActionResult<IEnumerable<User>>> GetUsers(string searchString)
        {
            if (_context.Users == null)
            {
                return NotFound();
            }
            var users = await _context.Users.Where(u => (u.FirstName + u.LastName + u.Email + u.Phone).Contains(searchString)).ToListAsync();

            if (users == null)
            {
                return NotFound();
            }

            return users;
        }

        /// <summary>
        ///Update users data in the datastore using the id and data supplied
        /// </summary>
        /// <remarks>Would require pagination</remarks>
        /// <response code="200">Users returned successfully</response>
        /// <response code="400">Request has missing/invalid values</response>
        /// <response code="500">Something is wrong at the server end of things</response>
        // PUT: api/Users/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUser(int id, User user)
        {
            if (id != user.Id)
            {
                return BadRequest();
            }

            _context.Entry(user).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserExists(id))
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

        /// <summary>
        /// Create a new user 
        /// </summary>
        /// <response code="200">User successfully created</response>
        /// <response code="400">Request has missing/invalid values</response>
        /// <response code="500">Something is wrong at the server end of things</response>
        // POST: api/Users
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<User>> PostUser(UserBindingModel userModel)
        {
            if (_context.Users == null)
            {
                return Problem("Entity set 'UserManagementContext.Users'  is null.");
            }
            var user = new User(userModel.FirstName, userModel.LastName, userModel.Email, userModel.Phone, userModel.Gender, userModel.Nationality, userModel.DateOfBirth, userModel.Role);
            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUser", new { id = user.Id }, user);
        }

        /// <summary>
        /// Deletes users from the datastore with user id specified
        /// </summary>
        /// <remarks>Would require pagination</remarks>
        /// <response code="200">User deleted successfully</response>
        /// <response code="400">Request has missing/invalid values</response>
        /// <response code="500">Something is wrong at the server end of things</response>
        // DELETE: api/Users/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            if (_context.Users == null)
            {
                return NotFound();
            }
            var user = await _context.Users.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            _context.Users.Remove(user);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool UserExists(int id)
        {
            return (_context.Users?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
