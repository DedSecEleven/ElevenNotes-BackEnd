using ElevenNotesBackEnd.Data;
using Microsoft.AspNetCore.Mvc;

namespace ElevenNotesBackEnd.Controllers{
  public class NotesController:Controller{
    private readonly ElevenContext _Context;
    public NotesController(ElevenContext context)
    {
      _Context = context;
    }
  }
}