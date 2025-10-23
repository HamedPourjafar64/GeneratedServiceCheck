namespace AuthService.Application.Common.Interfaces;

/// <summary>
/// Interface for accessing current user information
/// </summary>
public interface ICurrentUserService
{
    /// <summary>
    /// Gets the current user's ID
    /// </summary>
    string? UserId { get; }

    /// <summary>
    /// Gets the current user's name
    /// </summary>
    string? UserName { get; }

    /// <summary>
    /// Gets a value indicating whether the user is authenticated
    /// </summary>
    bool IsAuthenticated { get; }
}
