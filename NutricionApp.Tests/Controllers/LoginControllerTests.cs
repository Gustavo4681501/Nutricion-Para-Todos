using System;
using NutricionApp.Controllers;
using NutricionApp.Tests;
using Xunit;

namespace NutricionApp.Tests.Controllers
{
    /// <summary>
    /// Tests unitarios para LoginController.
    /// Actualizado para usar IUsuarioRepository (Patron Repository).
    /// Cubre: Login, Register, GetUser.
    /// </summary>
    public class LoginControllerTests : IDisposable
    {
        private readonly TestDatabaseFactory _factory;
        private readonly LoginController _controller;

        public LoginControllerTests()
        {
            _factory    = new TestDatabaseFactory();
            _controller = new LoginController(_factory.CreateUsuarioRepository());
        }

        // ── Login ──────────────────────────────────────────────

        [Fact]
        public void Login_CredencialesCorrectas_RetornaTrue()
        {
            bool resultado = _controller.Login("Randy", "123");
            Assert.True(resultado);
        }

        [Fact]
        public void Login_ContrasenaIncorrecta_RetornaFalse()
        {
            bool resultado = _controller.Login("Randy", "wrongpassword");
            Assert.False(resultado);
        }

        [Fact]
        public void Login_UsuarioNoExiste_RetornaFalse()
        {
            bool resultado = _controller.Login("UsuarioInventado", "123");
            Assert.False(resultado);
        }

        [Fact]
        public void Login_AdminCorrecto_RetornaTrue()
        {
            bool resultado = _controller.Login("admin", "admin123");
            Assert.True(resultado);
        }

        [Fact]
        public void Login_UsuarioInactivo_RetornaFalse()
        {
            _controller.Register("usuarioTest", "pass123");
            using var conn = _factory.CreateContext().OpenConnection();
            var cmd = conn.CreateCommand();
            cmd.CommandText = "UPDATE Usuarios SET IsActive=0 WHERE UserName='usuarioTest';";
            cmd.ExecuteNonQuery();

            bool resultado = _controller.Login("usuarioTest", "pass123");
            Assert.False(resultado);
        }

        // ── Register ───────────────────────────────────────────

        [Fact]
        public void Register_UsuarioNuevo_RetornaTrue()
        {
            bool resultado = _controller.Register("NuevoUsuario", "pass123");
            Assert.True(resultado);
        }

        [Fact]
        public void Register_UsuarioDuplicado_RetornaFalse()
        {
            _controller.Register("Duplicado", "pass123");
            bool resultado = _controller.Register("Duplicado", "otrapass");
            Assert.False(resultado);
        }

        [Fact]
        public void Register_UsuarioNuevo_PuedeHacerLoginDespues()
        {
            _controller.Register("NuevoTest", "miPass");
            bool login = _controller.Login("NuevoTest", "miPass");
            Assert.True(login);
        }

        // ── GetUser ────────────────────────────────────────────

        [Fact]
        public void GetUser_UsuarioExiste_RetornaUserCompleto()
        {
            var user = _controller.GetUser("Randy");
            Assert.NotNull(user);
            Assert.Equal("Randy", user.UserName);
        }

        [Fact]
        public void GetUser_AdminEsAdmin_RetornaIsAdminTrue()
        {
            var user = _controller.GetUser("admin");
            Assert.NotNull(user);
            Assert.True(user.IsAdmin);
        }

        [Fact]
        public void GetUser_UsuarioNormal_RetornaIsAdminFalse()
        {
            var user = _controller.GetUser("Randy");
            Assert.NotNull(user);
            Assert.False(user.IsAdmin);
        }

        [Fact]
        public void GetUser_UsuarioNoExiste_RetornaNull()
        {
            var user = _controller.GetUser("UsuarioQueNoExiste");
            Assert.Null(user);
        }

        public void Dispose() => _factory.Dispose();
    }
}
