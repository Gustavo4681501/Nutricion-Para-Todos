namespace NutricionApp.Models
{

    /// <summary>
    /// Represents a user account with a username and password.
    /// </summary>
    /// <remarks>The User class provides constructors for creating a user either by specifying the username
    /// and password directly or by initializing from a CSV data row. Ensure that the username and password meet any
    /// required security or validation standards before creating an instance.</remarks>
    public class User
    {
        /// <summary>
        /// Gets or sets the username associated with the account.
        /// </summary>
        /// <remarks>The username must be unique and cannot be null or empty. It is used for user
        /// authentication and identification within the system.</remarks>
        public string UserName { get; set; }

        /// <summary>
        /// Gets or sets the password used to authenticate the user during login.
        /// </summary>
        /// <remarks>The password should meet the application's security requirements, such as minimum
        /// length and complexity. Ensure that the password is handled securely and is not exposed in logs or error
        /// messages.</remarks>
        public string Password { get; set; }

        /// <summary>
        /// Initializes a new instance of the User class with the specified username and password.
        /// </summary>
        /// <param name="userName">The username associated with the user. This value cannot be null or empty.</param>
        /// <param name="password">The password for the user account. This value cannot be null or empty.</param>
        public User(string userName, string password)
        {
            UserName = userName;
            Password = password;
        }

        /// <summary>
        /// Initializes a new instance of the User class using the specified user data.
        /// </summary>
        /// <remarks>The userData array must contain at least two elements. If fewer elements are
        /// provided, an exception may occur due to invalid indexing.</remarks>
        /// <param name="userData">An array of strings that contains user information. The first element must be the username, and the second
        /// element must be the password.</param>
        public User(string[] userData)
        {
            UserName = userData[0];
            Password = userData[1];
        }
    }
}
