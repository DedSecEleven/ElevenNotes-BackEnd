using ElevenNotesBackEnd.Data;
using ElevenNotesBackEnd.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ElevenNotesBackEnd.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class NotesController : Controller
  {
    private readonly ElevenContext _Context;
    public NotesController(ElevenContext context)
    {
      _Context = context;
    }

    // Listar Notas
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Note>>> GetNotes()
    {
      return await _Context.Notes.ToListAsync();
    }
    // Detalles de una nota
    [HttpGet("{id}")]
    public async Task<ActionResult<Note>> GetNote(int id)
    {
      var note = await _Context.Notes.FindAsync(id);
      if (note == null)
      {
        return NotFound();
      }
      return note;
    }
  }
}