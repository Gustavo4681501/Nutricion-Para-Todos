using System;
using System.Globalization;

namespace NutricionApp.Models
{
    public enum ObjetivoUsuario
    {
        Mantener,
        PerderGrasa,
        GanarMasa
    }

    public enum NivelActividad
    {
        Sedentario,
        LigeroActivo,
        Moderadamente,
        MuyActivo,
        ExtraActivo
    }

    public enum TipoDieta
    {
        Estandar,
        Keto,
        Vegetariano
    }

    public enum Sexo
    {
        Masculino,
        Femenino
    }

    public class Usuario
    {
        public int            Id             { get; set; }
        public string         Nombre         { get; set; }
        public string         Password       { get; set; }
        public int            Edad           { get; set; }
        public double         Peso           { get; set; }
        public double         Altura         { get; set; }
        public Sexo           Sexo           { get; set; }
        public ObjetivoUsuario Objetivo      { get; set; }
        public NivelActividad  NivelActividad { get; set; }
        public TipoDieta       TipoDieta     { get; set; }

        public Usuario() { }

        public Usuario(int id, string nombre, string password, int edad, double peso, double altura,
            Sexo sexo, ObjetivoUsuario objetivo, NivelActividad nivel, TipoDieta dieta)
        {
            Id             = id;
            Nombre         = nombre;
            Password       = password;
            Edad           = edad;
            Peso           = peso;
            Altura         = altura;
            Sexo           = sexo;
            Objetivo       = objetivo;
            NivelActividad = nivel;
            TipoDieta      = dieta;
        }

        public string ToCsv()
        {
            return string.Format("{0},{1},{2},{3},{4},{5},{6},{7},{8},{9}",
                Id, Nombre, Password, Edad, Peso, Altura, Sexo, Objetivo, NivelActividad, TipoDieta);
        }

        public static Usuario FromCsv(string linea)
        {
            var p = linea.Split(',');
            return new Usuario
            {
                Id             = int.Parse(p[0].Trim()),
                Nombre         = p[1].Trim(),
                Password       = p[2].Trim(),
                Edad           = int.Parse(p[3].Trim()),
                Peso           = double.Parse(p[4].Trim(), CultureInfo.InvariantCulture),
                Altura         = double.Parse(p[5].Trim(), CultureInfo.InvariantCulture),
                Sexo           = (Sexo)Enum.Parse(typeof(Sexo), p[6].Trim()),
                Objetivo       = (ObjetivoUsuario)Enum.Parse(typeof(ObjetivoUsuario), p[7].Trim()),
                NivelActividad = (NivelActividad)Enum.Parse(typeof(NivelActividad), p[8].Trim()),
                TipoDieta      = (TipoDieta)Enum.Parse(typeof(TipoDieta), p[9].Trim())
            };
        }

        public override string ToString() => Nombre;
    }
}
