using System;
using NutricionApp.Controllers;
using NutricionApp.Models;
using NutricionApp.Tests;
using Xunit;

namespace NutricionApp.Tests.Controllers
{
    /// <summary>
    /// Tests unitarios para PerfilController.
    /// Cubre: ObtenerPerfil, GuardarPerfil, DistribucionDietas.
    /// </summary>
    public class PerfilControllerTests : IDisposable
    {
        private readonly TestDatabaseFactory _factory;
        private readonly PerfilController _controller;

        public PerfilControllerTests()
        {
            _factory    = new TestDatabaseFactory();
            _controller = new PerfilController(_factory.CreateContext());
        }

        // ── ObtenerPerfil ──────────────────────────────────────

        [Fact]
        public void ObtenerPerfil_UsuarioConPerfil_RetornaDatosCorrectos()
        {
            var perfil = _controller.ObtenerPerfil("Randy");
            Assert.NotNull(perfil);
            Assert.Equal("Randy", perfil.UserName);
            Assert.Equal(38, perfil.Edad);
            Assert.Equal(55, perfil.PesoKg);
        }

        [Fact]
        public void ObtenerPerfil_UsuarioSinPerfil_RetornaPerfilDefault()
        {
            // "admin" no tiene perfil en el seed
            var perfil = _controller.ObtenerPerfil("admin");
            Assert.NotNull(perfil);
            Assert.Equal("admin", perfil.UserName);
        }

        [Fact]
        public void ObtenerPerfil_DietaCorrecta()
        {
            var perfil = _controller.ObtenerPerfil("Joely");
            Assert.Equal(TipoDieta.Keto, perfil.Dieta);
        }

        [Fact]
        public void ObtenerPerfil_ObjetivoCorrect()
        {
            var perfil = _controller.ObtenerPerfil("Kevin");
            Assert.Equal(ObjetivoNutricional.GanarMasa, perfil.Objetivo);
        }

        // ── GuardarPerfil ──────────────────────────────────────

        [Fact]
        public void GuardarPerfil_NuevoPerfil_SeGuardaCorrectamente()
        {
            var nuevo = new Perfil("admin")
            {
                Edad     = 30,
                PesoKg   = 75,
                AlturaCm = 175,
                Objetivo  = ObjetivoNutricional.Mantener,
                Actividad = NivelActividad.Moderado,
                Dieta     = TipoDieta.Estandar
            };
            _controller.GuardarPerfil(nuevo);

            var recuperado = _controller.ObtenerPerfil("admin");
            Assert.Equal(30, recuperado.Edad);
            Assert.Equal(75, recuperado.PesoKg);
        }

        [Fact]
        public void GuardarPerfil_ActualizaPerfilExistente()
        {
            var perfil = _controller.ObtenerPerfil("Randy");
            perfil.PesoKg = 999;
            _controller.GuardarPerfil(perfil);

            var actualizado = _controller.ObtenerPerfil("Randy");
            Assert.Equal(999, actualizado.PesoKg);
        }

        [Fact]
        public void GuardarPerfil_CambiaDieta_SeRefleja()
        {
            var perfil = _controller.ObtenerPerfil("Randy");
            perfil.Dieta = TipoDieta.Keto;
            _controller.GuardarPerfil(perfil);

            var actualizado = _controller.ObtenerPerfil("Randy");
            Assert.Equal(TipoDieta.Keto, actualizado.Dieta);
        }

        // ── DistribucionDietas ─────────────────────────────────

        [Fact]
        public void DistribucionDietas_RetornaListaNoVacia()
        {
            var dist = _controller.DistribucionDietas();
            Assert.NotEmpty(dist);
        }

        [Fact]
        public void DistribucionDietas_ContieneTrestipos()
        {
            var dist = _controller.DistribucionDietas();
            // El seed tiene Estandar, Keto y Vegetariano
            Assert.Equal(3, dist.Count);
        }

        public void Dispose() => _factory.Dispose();
    }
}
