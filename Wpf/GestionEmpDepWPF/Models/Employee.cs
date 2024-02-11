using System.Windows.Media.Imaging;

namespace GestionEmpDepWPF.Models;

public class Employee(
    string dni,
    string name,
    string email,
    string phone,
    string photoUri,
    string position,
    long? departmentId) : ICloneable
{
    public string Dni { get; set; } = dni;
    public string Name { get; set; } = name;
    public string Email { get; set; } = email;
    public string Phone { get; set; } = phone;
    public string PhotoUri { get; set; } = photoUri;
    public string Position { get; set; } = position;
    public long? DepartmentId { get; set; } = departmentId;
    
    public object Clone() => MemberwiseClone();
}