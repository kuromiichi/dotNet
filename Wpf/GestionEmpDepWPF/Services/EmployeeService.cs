using GestionEmpDepWPF.Errors;
using GestionEmpDepWPF.Models;
using GestionEmpDepWPF.Validators;

namespace GestionEmpDepWPF.Services;

public class EmployeeService : ICrudService<Employee, string>
{
    private readonly Dictionary<string, Employee> _employees = new();

    public string Add(Employee entity)
        => _employees.TryAdd(entity.Dni, entity)
            ? entity.Dni
            : throw new GestionEmpDepWPFException.EntityAlreadyExistsException("Employee with dni " + entity.Dni +
                                                                               " already exists");

    public Employee Get(string id)
        => _employees.GetValueOrDefault(id)
           ?? throw new GestionEmpDepWPFException.EntityNotFoundException("Employee with dni " + id + " not found");

    public List<Employee> GetAll() => _employees.Values.ToList();

    public void Update(Employee entity)
    {
        if (!_employees.ContainsKey(entity.Dni))
            throw new GestionEmpDepWPFException.EntityNotFoundException(
                "Employee with dni " + entity.Dni + " not found");

        string validation = EmployeeValidator.ValidateEmployee(entity);
        if (validation != "OK")
            throw new GestionEmpDepWPFException.InvalidEntityException(validation);

        _employees[entity.Dni] = entity;
    }

    public void Remove(string id)
    {
        if (!_employees.Remove(id))
            throw new GestionEmpDepWPFException.EntityNotFoundException("Employee with dni " + id + " not found");
    }
}