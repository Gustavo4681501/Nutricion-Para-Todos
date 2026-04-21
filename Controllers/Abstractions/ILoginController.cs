namespace NutricionApp.Controllers.Abstractions
{
    /// <summary>
    /// Provides a contract for user authentication and registration operations.
    /// </summary>
    /// <remarks>Implementations of this interface should ensure secure handling of user credentials and
    /// enforce appropriate validation and security standards for login and registration processes.</remarks>
    public interface ILoginController
    {
        /// <summary>
        /// Authenticates a user by verifying the specified username and password.
        /// </summary>
        /// <remarks>This method checks the provided credentials against the stored user data. Ensure that
        /// the username and password meet the required security standards.</remarks>
        /// <param name="userName">The username of the user attempting to log in. This value cannot be null or empty.</param>
        /// <param name="password">The password associated with the specified username. This value cannot be null or empty.</param>
        /// <returns>true if the credentials are valid and the user is successfully authenticated; otherwise, false.</returns>
        bool Login(string userName, string password);

        /// <summary>
        ///Registers a new user account with the specified username and password.
        /// </summary>
        /// <remarks>This method may throw exceptions if the username is already taken or if the password
        /// does not meet the required criteria.</remarks>
        /// <param name="userName">The username for the new account. Must be unique and cannot be null or empty.</param>
        /// <param name="password">The password for the new account. Must meet complexity requirements and cannot be null or empty.</param>
        /// <returns>true if the registration is successful; otherwise, false.</returns>
        bool Register(string userName, string password);
    }
}
