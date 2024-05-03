using ElevenNotesBackEnd.Data;
using ElevenNotesBackEnd.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ElevenNotesBackEnd.Controllers{
  [Route("api/[Controller]")]
  [ApiController]
  public class UsersController:Controller{
    private readonly ElevenContext _Context;
    public UsersController(ElevenContext context){
      _Context=context;
    }

    // Listar Usuarios
    [HttpGet]
    public async Task<ActionResult<IEnumerable<User>>> GetUser()
    {
      return await _Context.Users.ToListAsync();
    }

    // Detalles de un usuario
    [HttpGet("{id}")]
    public async Task<ActionResult<User>> GetUser(int id)
    {
      var user = await _Context.Users.FindAsync(id);
      if (user == null)
      {
        return NotFound();
      }
      return user;
    }

    // Crear un usuario
    [HttpPost]
    public async Task<ActionResult<User>> CreateUser(User user)
    {
      _Context.Users.Add(user);
      await _Context.SaveChangesAsync();
      return CreatedAtAction("GetPerson",new {id=user.Id}, user);
    }

    // Eliminar un usuario
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteUser(int id) {
      var user = await _Context.Users.FindAsync(id);
      if(user==null){
        return NotFound();
      }
      _Context.Users.Remove(user);
      await _Context.SaveChangesAsync();
      return NoContent();
    }
  }
}
