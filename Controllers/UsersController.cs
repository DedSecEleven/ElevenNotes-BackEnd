using ElevenNotesBackEnd.Data;
using Microsoft.AspNetCore.Mvc;

namespace ElevenNotesBackEnd.Controllers{
  [Route("api/[Controller]")]
  [ApiController]
  public class UsersController:Controller{
    private readonly ElevenContext _Context;
    public UsersController(ElevenContext context){
      _Context=context;
    }
    
  }
}
