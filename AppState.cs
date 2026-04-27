using System;
using NutricionApp.Models;

namespace NutricionApp
{
    /// <summary>
    /// Mantiene el estado de sesion del usuario por circuito Blazor.
    /// Reemplaza el manejo de estado que antes hacia el WinForms entre formularios.
    /// </summary>
    public class AppState
    {
        public User CurrentUser { get; private set; }
        public bool IsLoggedIn  => CurrentUser != null;
        public bool IsAdmin     => CurrentUser?.IsAdmin == true;

        public event Action OnChange;

        /// <summary>Establece el usuario actual y notifica a los componentes que el estado ha cambiado.</summary>
        public void SetUser(User user)
        {
            CurrentUser = user;
            NotifyStateChanged();
        }

        /// <summary>Cierra la sesión del usuario actual.</summary>
        public void Logout()
        {
            CurrentUser = null;
            NotifyStateChanged();
        }

        private void NotifyStateChanged() => OnChange?.Invoke();
    }
}
