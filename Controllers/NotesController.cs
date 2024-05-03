using ElevenNotesBackEnd.Data;
using ElevenNotesBackEnd.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ElevenNotesBackEnd.Controllers{
  [Route("api/[controller]")]
  [ApiController]
  public class NotesController:Controller{
    private readonly ElevenContext _Context;
    public NotesController(ElevenContext context)
    {
      _Context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Note>>> GetNotes()
    {
      return await _Context.Notes.ToListAsync();
    }
  }
}