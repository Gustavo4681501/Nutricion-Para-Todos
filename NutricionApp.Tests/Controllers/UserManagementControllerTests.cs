using System;
using NutricionApp.Controllers;
using NutricionApp.Tests;
using Xunit;

namespace NutricionApp.Tests.Controllers
{
    /// <summary>
    /// Tests unitarios para UserManagementController.
    /// Actualizado para usar IUsuarioRepository (Patron Repository).
    /// Cubre: GetAll, ResetPassword, SetActive, EliminarUsuario.
    /// </summary>
    public class UserManagementControllerTests : IDisposable
    {
        private readonly TestDatabaseFactory      _factory;
        private readonly UserManagementController _controller;
        private readonly LoginController          _loginCtrl;

        public UserManagementControllerTests()
        {
            _factory    = new TestDatabaseFactory();
            var repo    = _factory.CreateUsuarioRepository();
            _controller = new UserManagementController(repo);
            _loginCtrl  = new LoginController(repo);
        }

        // ── GetAll ─────────────────────────────────────────────

        [Fact]
        public void GetAll_RetornaListaNoVacia()
        {
            var usuarios = _controller.GetAll();
            Assert.NotEmpty(usuarios);
        }

        [Fact]
        public void GetAll_ContieneAdmin()
        {
            var usuarios = _controller.GetAll();
            Assert.Contains(usuarios, u => u.UserName == "admin" && u.IsAdmin);
        }

        [Fact]
        public void GetAll_ContieneTodosLosUsuariosDelSeed()
        {
            var usuarios = _controller.GetAll();
            Assert.True(usuarios.Count >= 28);
        }

        // ── ResetPassword ──────────────────────────────────────

        [Fact]
        public void ResetPassword_NuevaContrasenaFunciona()
        {
            _controller.ResetPassword("Randy", "nuevaPass");
            bool loginNuevo = _loginCtrl.Login("Randy", "nuevaPass");
            Assert.True(loginNuevo);
        }

        [Fact]
        public void ResetPassword_ContrasenaAnteriorYaNoFunciona()
        {
            _controller.ResetPassword("Randy", "nuevaPass");
            bool loginViejo = _loginCtrl.Login("Randy", "123");
            Assert.False(loginViejo);
        }

        // ── SetActive ──────────────────────────────────────────

        [Fact]
        public void SetActive_Desactivar_UsuarioNoPuedeLogin()
        {
            _controller.SetActive("Randy", false);
            bool login = _loginCtrl.Login("Randy", "123");
            Assert.False(login);
        }

        [Fact]
        public void SetActive_Reactivar_UsuarioPuedeLoginNuevamente()
        {
            _controller.SetActive("Randy", false);
            _controller.SetActive("Randy", true);
            bool login = _loginCtrl.Login("Randy", "123");
            Assert.True(login);
        }

        [Fact]
        public void SetActive_Desactivar_ApareceLaFlagEnGetAll()
        {
            _controller.SetActive("Joely", false);
            var usuarios = _controller.GetAll();
            var joely = usuarios.Find(u => u.UserName == "Joely");
            Assert.NotNull(joely);
            Assert.False(joely.IsActive);
        }

        // ── EliminarUsuario ────────────────────────────────────

        [Fact]
        public void EliminarUsuario_UsuarioEliminado_NoApareceEnGetAll()
        {
            _controller.EliminarUsuario("test");
            var usuarios = _controller.GetAll();
            Assert.DoesNotContain(usuarios, u => u.UserName == "test");
        }

        [Fact]
        public void EliminarUsuario_UsuarioEliminado_NoPuedeLogin()
        {
            _controller.EliminarUsuario("test");
            bool login = _loginCtrl.Login("test", "123");
            Assert.False(login);
        }

        [Fact]
        public void EliminarUsuario_DecrementaConteoDeUsuarios()
        {
            int antes = _controller.GetAll().Count;
            _controller.EliminarUsuario("test");
            int despues = _controller.GetAll().Count;
            Assert.Equal(antes - 1, despues);
        }

        public void Dispose() => _factory.Dispose();
    }
}
