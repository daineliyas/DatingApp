using API.Data;
using API.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly DataContext _datacontext;
        public UsersController(DataContext datacontext)
        {
            _datacontext = datacontext;
        }

        [HttpGet]
        public async Task <ActionResult<IEnumerable<AppUsers>>> GetUsers()
        {
            var users = await _datacontext.Users.ToListAsync();
            
            return users;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<AppUsers>> GetUsers(int id)
        {
            return await _datacontext.Users.FindAsync(id);
        }
    }
}