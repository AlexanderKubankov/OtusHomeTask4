using Api.Data;
using Api.Data.Models;
using Api.Infrastructure;
using Api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Api.Controllers
{
    [Route("users")]
    public class UserController : Controller
    {
        private readonly DataContext context;

        public UserController(DataContext context)
        {
            this.context = context;
        }

        [HttpGet("{id:int}")]
        public async Task<UserResponse> GetAsync(int id)
        {
            var user = await GetUserInternal(id);
            return user.ToUserResponse();
        }

        [HttpPost]
        public async Task<CreateUserResponse> PostAsync([FromBody] UserRequest request)
        {
            if (request == null)
            {
                throw new ArgumentNullException(nameof(request));
            }

            var user = new User();
            user.SetFrom(request);
            context.Add(user);
            await context.SaveChangesAsync();
            return user.ToCreateUserResponse();
        }

        [HttpPut("{id:int}")]
        public async Task PutAsync(int id, [FromBody] UserRequest request)
        {
            var user = await GetUserInternal(id);
            user.SetFrom(request);
            await context.SaveChangesAsync();
        }

        [HttpDelete("{id:int}")]
        public async Task DeleteAsync(int id)
        {
            var user = await GetUserInternal(id);
            context.Users.Remove(user);
            await context.SaveChangesAsync();
        }

        private async Task<User> GetUserInternal(int id)
        {
            var user = await context.Users.FirstOrDefaultAsync(x => x.Id == id);
            return user ?? throw new FileNotFoundException();
        }
    }
}
