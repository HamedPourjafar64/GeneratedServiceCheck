namespace AuthService.Application.Common.Models;

/// <summary>
/// Represents the result of an operation
/// </summary>
public class Result<T>
{
    /// <summary>
    /// Gets or sets a value indicating whether the operation succeeded
    /// </summary>
    public bool Succeeded { get; set; }

    /// <summary>
    /// Gets or sets the result data
    /// </summary>
    public T? Data { get; set; }

    /// <summary>
    /// Gets or sets the error messages
    /// </summary>
    public string[] Errors { get; set; } = Array.Empty<string>();

    /// <summary>
    /// Creates a successful result
    /// </summary>
    public static Result<T> Success(T data)
    {
        return new Result<T> { Succeeded = true, Data = data };
    }

    /// <summary>
    /// Creates a failed result
    /// </summary>
    public static Result<T> Failure(params string[] errors)
    {
        return new Result<T> { Succeeded = false, Errors = errors };
    }
}
