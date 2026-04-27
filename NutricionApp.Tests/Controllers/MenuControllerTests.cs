using System;
using System.Collections.Generic;
using NutricionApp.Controllers;
using NutricionApp.Models;
using NutricionApp.Tests;
using Xunit;

namespace NutricionApp.Tests.Controllers
{
    /// <summary>
    /// Tests unitarios para MenuController.
    /// Actualizado para usar IMenuRepository (Patron Repository).
    /// Cubre: ObtenerPorUsuario, Guardar, Eliminar, AlimentoMasConsumido, TopUsuariosPorMenus.
    /// </summary>
    public class MenuControllerTests : IDisposable
    {
        private readonly TestDatabaseFactory _factory;
        private readonly MenuController      _controller;

        public MenuControllerTests()
        {
            _factory    = new TestDatabaseFactory();
            _controller = new MenuController(_factory.CreateMenuRepository());
        }

        private Menu CrearMenuConItems(string userName)
        {
            var menu = new Menu(userName, DateTime.Today);
            menu.Items = new List<ItemMenu>
            {
                new ItemMenu("Arroz blanco cocido", 200, 260, 5.4, 56.4, 0.6),
                new ItemMenu("Pechuga de pollo",    150, 247.5, 46.5, 0, 5.4)
            };
            return menu;
        }

        // ── ObtenerPorUsuario ──────────────────────────────────

        [Fact]
        public void ObtenerPorUsuario_SinMenus_RetornaListaVacia()
        {
            var menus = _controller.ObtenerPorUsuario("admin");
            Assert.Empty(menus);
        }

        [Fact]
        public void ObtenerPorUsuario_ConMenuGuardado_RetornaElMenu()
        {
            _controller.Guardar(CrearMenuConItems("Randy"));
            var menus = _controller.ObtenerPorUsuario("Randy");
            Assert.NotEmpty(menus);
        }

        // ── Guardar ────────────────────────────────────────────

        [Fact]
        public void Guardar_MenuConItems_SeGuardaCorrectamente()
        {
            _controller.Guardar(CrearMenuConItems("Luis"));
            var menus = _controller.ObtenerPorUsuario("Luis");
            Assert.Single(menus);
            Assert.Equal(2, menus[0].Items.Count);
        }

        [Fact]
        public void Guardar_VariosMenus_SeGuardanTodos()
        {
            _controller.Guardar(CrearMenuConItems("Ana"));
            _controller.Guardar(CrearMenuConItems("Ana"));
            var menus = _controller.ObtenerPorUsuario("Ana");
            Assert.Equal(2, menus.Count);
        }

        [Fact]
        public void Guardar_ItemsConCaloriasCorrectas()
        {
            _controller.Guardar(CrearMenuConItems("Jose"));
            var menus = _controller.ObtenerPorUsuario("Jose");
            Assert.Equal(260, menus[0].Items[0].Calorias);
        }

        // ── Eliminar ───────────────────────────────────────────

        [Fact]
        public void Eliminar_MenuExistente_SeElimina()
        {
            _controller.Guardar(CrearMenuConItems("Carlos"));
            var menus = _controller.ObtenerPorUsuario("Carlos");
            Assert.NotEmpty(menus);
            _controller.Eliminar("Carlos", menus[0].Id);
            var despues = _controller.ObtenerPorUsuario("Carlos");
            Assert.Empty(despues);
        }

        // ── AlimentoMasConsumido ───────────────────────────────

        [Fact]
        public void AlimentoMasConsumido_SinDatos_RetornaSinDatos()
        {
            var resultado = _controller.AlimentoMasConsumido(DateTime.Today.AddDays(-30), DateTime.Today);
            Assert.Equal("Sin datos", resultado);
        }

        [Fact]
        public void AlimentoMasConsumido_ConDatos_RetornaElMasConsumido()
        {
            var m1 = new Menu("Randy", DateTime.Today);
            m1.Items = new List<ItemMenu> { new ItemMenu("Arroz blanco cocido", 300, 390, 8.1, 84.6, 0.9) };
            var m2 = new Menu("Randy", DateTime.Today.AddDays(-1));
            m2.Items = new List<ItemMenu>
            {
                new ItemMenu("Arroz blanco cocido", 200, 260, 5.4, 56.4, 0.6),
                new ItemMenu("Banana", 100, 89, 1.1, 22.8, 0.3)
            };
            _controller.Guardar(m1);
            _controller.Guardar(m2);
            var resultado = _controller.AlimentoMasConsumido(DateTime.Today.AddDays(-7), DateTime.Today);
            Assert.Equal("Arroz blanco cocido", resultado);
        }

        // ── TopUsuariosPorMenus ────────────────────────────────

        [Fact]
        public void TopUsuariosPorMenus_SinMenus_RetornaVacio()
        {
            var top = _controller.TopUsuariosPorMenus(5);
            Assert.Empty(top);
        }

        [Fact]
        public void TopUsuariosPorMenus_ConDatos_OrdenadoDescendente()
        {
            _controller.Guardar(CrearMenuConItems("Randy"));
            _controller.Guardar(CrearMenuConItems("Randy"));
            _controller.Guardar(CrearMenuConItems("Randy"));
            _controller.Guardar(CrearMenuConItems("Ana"));
            var top = _controller.TopUsuariosPorMenus(5);
            Assert.Equal("Randy", top[0].UserName);
            Assert.Equal(3, top[0].Count);
        }

        public void Dispose() => _factory.Dispose();
    }
}
