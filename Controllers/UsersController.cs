using ElevenNotesBackEnd.Data;
using ElevenNotesBackEnd.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ElevenNotesBackEnd.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class UsersController : Controller
  {
    private readonly ElevenContext _Context;
    public UsersController(ElevenContext context)
    {
      _Context = context;
    }

    // Listar Usuarios
    [HttpGet]
    public async Task<ActionResult<IEnumerable<User>>> GetUser()
    {
      return await _Context.Users.ToListAsync();
    }

    
  }
}
