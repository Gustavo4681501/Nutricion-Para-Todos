using System;
using System.Collections.Generic;
using System.IO;
using NutricionApp.Controllers.Abstractions;
using NutricionApp.Models;

namespace NutricionApp.Controllers
{
    /// <summary>
    /// Provides methods for authenticating users and registering new accounts, managing user data stored in a CSV file.
    /// </summary>
    /// <remarks>The controller loads user information from the specified CSV file upon initialization and
    /// persists changes when new users are registered. Usernames must be unique; attempts to register an existing
    /// username will fail. This class is not thread-safe.</remarks>
    public class LoginController : ILoginController
    {
        private readonly List<User> _users;
        private readonly string _filePath;

        /// <summary>
        /// Initializes a new instance of the LoginController class using the specified file path for user data storage
        /// and retrieval.
        /// </summary>
        /// <remarks>The constructor loads user information from the specified file upon initialization.
        /// Ensure that the file exists and is accessible to prevent exceptions during loading.</remarks>
        /// <param name="filePath">The path to the file containing user data. This parameter cannot be null or empty.</param>
        public LoginController(string filePath)
        {
            _filePath = filePath;
            _users    = LoadUsers();
        }

        /// <summary>
        /// Validates the specified user credentials against the registered users and indicates whether authentication
        /// is successful.
        /// </summary>
        /// <remarks>This method performs a direct comparison of the provided credentials with those
        /// stored in the user collection. It does not implement security measures such as password hashing or account
        /// lockout. Use only in trusted or demonstration scenarios.</remarks>
        /// <param name="userName">The user name of the account to authenticate. This value cannot be null or empty.</param>
        /// <param name="password">The password associated with the specified user name. This value cannot be null or empty.</param>
        /// <returns>true if the credentials match a registered user; otherwise, false.</returns>
        public bool Login(string userName, string password)
        {
            foreach (var user in _users)
            {
                if (user.UserName == userName && user.Password == password)
                    return true;
            }

            return false;
        }

        /// <summary>
        /// Registers a new user with the specified username and password if the username does not already exist.
        /// </summary>
        /// <remarks>This method checks for existing users to ensure that each username is unique. User
        /// data is persisted after successful registration.</remarks>
        /// <param name="userName">The username for the new user. Must be unique and cannot be null or empty.</param>
        /// <param name="password">The password for the new user. Cannot be null.</param>
        /// <returns>true if the registration is successful; otherwise, false if the username already exists.</returns>
        public bool Register(string userName, string password)
        {
            foreach (var user in _users)
            {
                if (user.UserName == userName)
                    return false;
            }

            _users.Add(new User(userName, password));
            SaveUsers();
            return true;
        }


        /// <summary>
        /// Loads a collection of users from the configured file path.
        /// </summary>
        /// <remarks>The method expects the file to be in CSV format, with the first line containing
        /// headers and each subsequent line representing a user. Only lines with at least two comma-separated values
        /// are processed. Ensure the file format matches the expected structure to avoid errors when creating User
        /// objects.</remarks>
        /// <returns>A list of User objects parsed from the file. Returns an empty list if the file does not exist or contains no
        /// user data.</returns>
        private List<User> LoadUsers()
        {
            var list = new List<User>();

            if (!File.Exists(_filePath))
                return list;

            var lines = File.ReadAllLines(_filePath);

            for (int i = 1; i < lines.Length; i++)
            {
                var parts = lines[i].Split(',');
                if (parts.Length >= 2)
                    list.Add(new User(parts));
            }

            return list;
        }

        /// <summary>
        /// Saves the current list of users to a CSV file, preserving the header row.
        /// </summary>
        /// <remarks>If the specified file already exists, the method reads its contents to maintain the
        /// existing header. If the file does not exist, a default header of 'UserName,Password' is used. The method
        /// writes each user's username and password as a new row in the CSV file.</remarks>
        private void SaveUsers()
        {
            var lines = File.Exists(_filePath)
                ? File.ReadAllLines(_filePath)
                : new string[0];

            string header = lines.Length > 0 ? lines[0] : "UserName,Password";

            var rows = new List<string> { header };

            foreach (var user in _users)
                rows.Add(string.Format("{0},{1}", user.UserName, user.Password));

            File.WriteAllLines(_filePath, rows);
        }
    }
}
