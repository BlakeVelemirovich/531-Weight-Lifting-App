namespace _531WorkoutApi.Exceptions;

public class DuplicateUsername : Exception
{
    public DuplicateUsername()
    {
        Message = "Username already exists";
    }

    public readonly string Message;
}