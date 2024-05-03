using ElevenNotesBackEnd.Data;
using Microsoft.AspNetCore.Mvc;

namespace ElevenNotesBackEnd.Controllers{
  public class NotesController:Controller{
    private readonly ElevenContext _Context;
    public NotesController(ElevenContext context)
    {
      _Context = context;
    }
<<<<<<< HEAD

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
=======
>>>>>>> d480b6be027f4d6ca84d0a09ad3ae7fdcf781c92
  }
}