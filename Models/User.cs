namespace NutricionApp.Models
{
    /// <summary>
    /// Representa una cuenta de usuario del sistema.
    /// Iteracion 2: agrega IsAdmin e IsActive para el rol de administrador.
    /// </summary>
    public class User
    {
        public string UserName { get; set; }
        public string Password { get; set; }

        /// <summary>Indica si el usuario tiene privilegios de administrador.</summary>
        public bool IsAdmin  { get; set; }

        /// <summary>Indica si la cuenta esta activa.</summary>
        public bool IsActive { get; set; } = true;

        public User(string userName, string password)
        {
            UserName = userName;
            Password = password;
            IsActive = true;
        }

        /// <summary>Constructor compatible con el formato CSV de la iteracion 1.</summary>
        public User(string[] userData)
        {
            UserName = userData[0];
            Password = userData[1];
            IsActive = true;
        }
    }
}
