namespace _531WorkoutApi.Exceptions;

public class PasswordMinimumReq : Exception
{
    public PasswordMinimumReq()
    {
        Message = "Password does not meet minimum requirements";
    }

    public readonly string Message;
}