# Nutrición Para Todos

## Descripción del Proyecto
Nutrición Para Todos es una aplicación de escritorio desarrollada en C# que permite gestionar menús nutricionales mediante una interfaz gráfica intuitiva.  

El sistema implementa una arquitectura basada en separación de capas (Controllers, Models y Views), facilitando el mantenimiento, la escalabilidad y la organización del código.

------------------------------------------------------------------------------------------------------------------------------------------

## Objetivo
Desarrollar una aplicación que permita:
- Crear menús nutricionales
- Visualizar menús existentes
- Gestionar información de forma sencilla

------------------------------------------------------------------------------------------------------------------------------------------

## Arquitectura del Sistema

El proyecto está estructurado bajo un enfoque similar a MVC:

- Models: Representan la estructura de los datos
- Views: Interfaz gráfica (Windows Forms)
- Controllers: Lógica de negocio

------------------------------------------------------------------------------------------------------------------------------------------

Nutricion-Para-Todos/
│
├── Controllers/
│ ├── Abstractions/
│ └── AlimentoController.cs
│ └── LoginController.cs
│ └── MenuController.cs
│ └── PerfilController.cs
│
├── Data/
│ └── CSV/
│ └── alimentos.csv
│ └── menus.csv
│ └── perfiles.csv
│ └── usuarios.csv
│
├── Models/
│ └── Alimento.cs
│ └── Menus.cs
│ └── Perfil.cs
│ └── User.cs
│
├── Views/
│   ├── FrmAgregarAlimento.cs
│   ├── FrmAgregarAlimento.Designer.cs
│   ├── FrmAgregarAlimento.resx
│   │
│   ├── FrmAlimentos.cs
│   ├── FrmAlimentos.Designer.cs
│   ├── FrmAlimentos.resx
│   │
│   ├── FrmBienvenida.cs
│   ├── FrmBienvenida.Designer.cs
│   ├── FrmBienvenida.resx
│   │
│   ├── FrmCrearMenu.cs
│   ├── FrmCrearMenu.Designer.cs
│   │
│   ├── FrmEstadisticas.cs
│   ├── FrmEstadisticas.Designer.cs
│   ├── FrmEstadisticas.resx
│   │
│   ├── FrmLogin.cs
│   ├── FrmLogin.Designer.cs
│   ├── FrmLogin.resx
│   │
│   ├── FrmMenus.cs
│   ├── FrmMenus.Designer.cs
│   │
│   ├── FrmPerfil.cs
│   ├── FrmPerfil.Designer.cs
│   ├── FrmPerfil.resx
│   │
│   ├── FrmRegistro.cs
│   ├── FrmRegistro.Designer.cs
│
│
├── .gitignore
├── Manual de Usuario y Documentación Técnica.pdf
├── Readme.txt
├── NutricionApp.csproj
├── NutricionApp.csproj.user
├── NutricionApp.sln
├── Program.cs

------------------------------------------------------------------------------------------------------------------------------------------

## Tecnologías Utilizadas

- C#
- .NET
- Windows Forms
- Archivos CSV (persistencia de datos)
- Git & GitHub

------------------------------------------------------------------------------------------------------------------------------------------

## Uso del Sistema

Login

Permite el acceso al sistema.

**Gestión de Menús**
Visualizar menús existentes
Acceder a opciones de creación

**Crear Menú**
Ingresar datos
Guardar información
Persistencia en archivo CSV

## Persistencia de Datos

El sistema almacena la información en:
Data/CSV/menus.csv

Esto permite:

Guardado sencillo
Fácil lectura
Persistencia sin base de datos

------------------------------------------------------------------------------------------------------------------------------------------

## Decisiones de Diseño
Uso de arquitectura por capas para separación de responsabilidades
Implementación de CSV para simplificar la persistencia
Uso de Windows Forms para una interfaz rápida de desarrollar

------------------------------------------------------------------------------------------------------------------------------------------

## Resultados

El sistema cumple con:

Gestión básica de menús
Interfaz funcional
Persistencia de datos

------------------------------------------------------------------------------------------------------------------------------------------

## Aprendizajes

Durante el desarrollo se aplicaron conceptos como:

Arquitectura de software
Programación en C#
Manejo de archivos
Control de versiones con Git
Desarrollo de interfaces gráficas

------------------------------------------------------------------------------------------------------------------------------------------

## Mejoras Futuras

Integración con base de datos (MySQL o SQL Server)
Sistema de autenticación
Mejoras en la UI
API REST

------------------------------------------------------------------------------------------------------------------------------------------

## Autores
Gustavo Mata Avellan
Kevin Ramirez Soto