using ElevenNotesBackEnd.Data;
using ElevenNotesBackEnd.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ElevenNotesBackEnd.Controllers{
  [Route("api/[Controller]")]
  [ApiController]
  public class NotesController:Controller{
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
    // Crear un usuario
    [HttpPost]
    public async Task<ActionResult<Note>> CreateNotes(Note note)
    {
      _Context.Notes.Add(note);
      await _Context.SaveChangesAsync();
      return CreatedAtAction("GetNotes", new { id = note.Id }, note);
    }

    // Eliminar un usuario
    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteNote(int id)
    {
      var note = await _Context.Notes.FindAsync(id);
      if (note == null)
      {
        return NotFound();
      }
      _Context.Notes.Remove(note);
      await _Context.SaveChangesAsync();
      return NoContent();
    }

    //Actualizar 
    [HttpPut("{id}")]
    public async Task<ActionResult<Note>> UpdateNote(Note notica, int id){
      // _Context.Notes.Update(notica);

      _Context.Entry(notica).State = EntityState.Modified;
      await _Context.SaveChangesAsync();
      return notica;
    }
  }
}