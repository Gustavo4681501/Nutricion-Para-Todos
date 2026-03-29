using NutricionApp.Models;

namespace NutricionApp.Controllers.Abstractions
{
    /// <summary>
    /// Defines methods for retrieving and saving user profile information, ensuring consistent access and modification
    /// of user profiles.
    /// </summary>
    /// <remarks>Implementations of this interface should handle validation and persistence of profile data.
    /// This contract allows for flexible management of user profiles across different storage mechanisms or business
    /// rules.</remarks>
    public interface IPerfilController
    {
        /// <summary>
        /// Retrieves the profile associated with the specified user name.
        /// </summary>
        /// <remarks>Ensure that the user name provided is valid and corresponds to an existing user
        /// profile to avoid null returns.</remarks>
        /// <param name="userName">The user name for which the profile is to be retrieved. This parameter cannot be null or empty.</param>
        /// <returns>A Perfil object representing the user's profile. Returns null if no profile is found for the specified user
        /// name.</returns>
        Perfil ObtenerPerfil(string userName);

        /// <summary>
        /// Saves the specified user profile to the data store.
        /// </summary>
        /// <remarks>Ensure that the profile data adheres to the required format and constraints before
        /// calling this method.</remarks>
        /// <param name="perfil">The user profile to be saved. This parameter cannot be null and must contain valid profile data.</param>
        void GuardarPerfil(Perfil perfil);
    }
}
