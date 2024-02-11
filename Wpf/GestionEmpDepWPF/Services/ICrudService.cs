namespace GestionEmpDepWPF.Services;

public interface ICrudService<T, TId>
{
    public TId Add(T entity);
    public T Get(TId id);
    public List<T> GetAll();
    public void Update(T entity);
    public void Remove(TId id);
}