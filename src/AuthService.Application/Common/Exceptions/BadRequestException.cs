namespace AuthService.Application.Common.Exceptions;

/// <summary>
/// Exception thrown when a bad request is made
/// </summary>
public class BadRequestException : Exception
{
    /// <summary>
    /// Initializes a new instance of the <see cref="BadRequestException"/> class
    /// </summary>
    public BadRequestException(string message)
        : base(message)
    {
    }
}
