namespace ElevenNotesBackEnd.Models{
  public class Note{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Content{get; set;}
    public int UserId { get; set; }
    public DateTime DateModified{get; set;}
  }
}