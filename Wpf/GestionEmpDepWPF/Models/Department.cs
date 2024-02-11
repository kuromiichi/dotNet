namespace GestionEmpDepWPF.Models;

public class Department(string name) : ICloneable
{
    public long Id { get; set; }
    public string Name { get; set; } = name;

    public override string ToString() => Name + " (" + Id + ")";

    public object Clone() => MemberwiseClone();
}