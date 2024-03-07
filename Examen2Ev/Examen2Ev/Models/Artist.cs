namespace Examen2Ev.Models;

public class Artist
{
    public string Name { get; set; }
    public int Id { get; set; }

    public override string ToString() => Name;
}