using GestionEmpDepWPF.Errors;
using GestionEmpDepWPF.Models;

namespace GestionEmpDepWPF.Services;

public class DepartmentService : ICrudService<Department, long>
{
    private static long _nextId = 1;

    private readonly Dictionary<long, Department> _departments = new();

    private static long GetNextId() => _nextId++;

    public long Add(Department entity)
    {
        if (_departments.Any(d => d.Value.Name == entity.Name))
            throw new GestionEmpDepWPFException.EntityAlreadyExistsException("Department with name " + entity.Name +
                                                                             " already exists");

        entity.Id = GetNextId();
        _departments.Add(entity.Id, entity);
        return entity.Id;
    }

    public Department Get(long id)
        => _departments.GetValueOrDefault(id)
           ?? throw new GestionEmpDepWPFException.EntityNotFoundException("Department with id " + id + " not found");

    public List<Department> GetAll()
        => _departments.Values.ToList();

    public void Update(Department entity)
    {
        if (!_departments.ContainsKey(entity.Id))
            throw new GestionEmpDepWPFException.EntityNotFoundException(
                "Department with id " + entity.Id + " not found");

        if (_departments.Any(d => d.Value.Name == entity.Name && d.Value.Id != entity.Id))
            throw new GestionEmpDepWPFException.EntityAlreadyExistsException("Department with name " + entity.Name +
                                                                             " already exists");

        _departments[entity.Id] = entity;
    }

    public void Remove(long id)
    {
        if (!_departments.Remove(id))
            throw new GestionEmpDepWPFException.EntityNotFoundException("Department with id " + id + " not found");
    }
}