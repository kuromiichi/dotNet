using System.Text.RegularExpressions;
using GestionEmpDepWPF.Models;

namespace GestionEmpDepWPF.Validators;

public class EmployeeValidator
{
    public static string ValidateEmployee(Employee employee)
    {
        if (string.IsNullOrWhiteSpace(employee.Dni))
            return "El DNI no puede estar vacío";
        Regex dniRegex = new("^[0-9]{8}[A-Z]$");
        if (!dniRegex.IsMatch(employee.Dni))
            return "El DNI debe tener 8 cifras y una letra mayúscula";
        if (string.IsNullOrWhiteSpace(employee.Name))
            return "El nombre no puede estar vacío";
        if (string.IsNullOrWhiteSpace(employee.Email))
            return "El correo no puede estar vacío";
        Regex correoRegex = new("^[^@]+@[^@]+$");
        if (!correoRegex.IsMatch(employee.Email))
            return "El correo debe ser válido";
        if (string.IsNullOrWhiteSpace(employee.Phone))
            return "El teléfono no puede estar vacío";
        Regex telefonoRegex = new("^\\+?[0-9]+$");
        if (!telefonoRegex.IsMatch(employee.Phone))
            return "El teléfono debe ser válido";
        if (string.IsNullOrWhiteSpace(employee.Position))
            return "El puesto no puede estar vacío";
        if (employee.DepartmentId <= 0)
            return "El ID del departamento no puede ser negativo";
        if (employee.DepartmentId is null)
            return "El departamento no puede estar vacío";
        return "OK";
    }
}