namespace GestionEmpDepWPF.Errors;

public class GestionEmpDepWPFException : Exception
{
    public GestionEmpDepWPFException(string message) : base(message) { }

    public class EntityAlreadyExistsException(string message) : GestionEmpDepWPFException(message);

    public class EntityNotFoundException(string message) : GestionEmpDepWPFException(message);
    
    public class InvalidEntityException(string message) : GestionEmpDepWPFException(message);
}