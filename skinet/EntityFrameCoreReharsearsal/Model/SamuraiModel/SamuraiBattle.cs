namespace EntityFrameCoreReharsearsal.Model
{
  // Join table
    public class SamuraiBattle
  {
    public int SamuraiId { get; set; }
    public int BattleId { get; set; }
    public Samurai Samurai { get; set; }
    public Battle Battle { get; set; }
  }
}
