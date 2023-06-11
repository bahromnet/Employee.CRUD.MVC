namespace Application.MVC.Commons.Models;

public class Result
{
    internal Result(bool succeded, IEnumerable<string> errors)
    {
        Succeded = succeded;
        Errors = errors.ToArray();
    }

    public bool Succeded { get; init; }
    public string[] Errors { get; init; }

    public static Result Succes()
    {
        return new Result(true, Array.Empty<string>());
    }

    public static Result Failure(IEnumerable<string> errors)
    {
        return new Result(false, errors);
    }

}
