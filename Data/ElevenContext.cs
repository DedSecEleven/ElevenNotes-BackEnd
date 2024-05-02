using ElevenNotesBackEnd.Models;
using Microsoft.EntityFrameworkCore;

namespace ElevenNotesBackEnd.Data{
  public class ElevenContext:DbContext{
    public ElevenContext(DbContextOptions<ElevenContext> options):base(options){
      
    }
    public DbSet<User> Users {get; set;}
    public DbSet<Note> Notes {get;set;} 
  }
}