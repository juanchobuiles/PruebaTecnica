namespace Core.Exceptions
{
    public class AlreadyExistsException : ApplicationException
    {
        public AlreadyExistsException(string name , string value) : base($"{name} '{value}' ya existe.")
        {

        }
    }
}
