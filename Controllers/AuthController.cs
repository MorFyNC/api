using APIkvalik.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Win32;

namespace APIkvalik.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private AnimalArmiContext context;

        public AuthController(AnimalArmiContext _context)
        {
            context = _context;
        }

        [HttpPost("Auth")]
        public async Task<IActionResult> Auth([FromBody] auth_reg auth)
        {
            var bd_auth = await context.Users.FirstOrDefaultAsync(x => x.Login == auth.Login);
            if (bd_auth == null) return new NotFoundObjectResult("Неверный логин");
            if (bd_auth.Password == auth.Password) return new OkObjectResult(new role() { Id_role=bd_auth.IdRole.Value, Id_user=bd_auth.Id});
            return new ConflictObjectResult("Неверный пароль");
        }

        [HttpPost("Regist")]
        public async Task<IActionResult> Regist([FromBody] auth_reg regist)
        {
            var bd_regist = await context.Users.FirstOrDefaultAsync(x => x.Login == regist.Login);
            if (bd_regist != null) return new ConflictObjectResult("Такой логин уже существует");
            var user = await context.Users.AddAsync(new User() { Login = regist.Login, Password = regist.Password });
            await context.SaveChangesAsync();
            return new OkObjectResult(user.Entity.Id);
        }
        [HttpPost("Role")]
        public async Task<IActionResult> GiveRole([FromBody] role role)
        {
            var bd_regist = await context.Users.FirstOrDefaultAsync(x => x.Id == role.Id_user);
            bd_regist.IdRole = role.Id_role;
            await context.SaveChangesAsync();
            return Ok();
        }

        public class auth_reg
        {
            public string Login { get; set; }
            public string Password { get; set; }
        }
         
        public class role
        {
            public int Id_user { get; set; }
            public int Id_role { get; set; }
        }
    }
}
