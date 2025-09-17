using System;

namespace Library_UDB
{
    public class Libro
    {
        public string Titulo { get; set; }
        public string Autor { get; set; }
        public int AnioPublicacion { get; set; }

        public Libro() { }

        public Libro(string titulo, string autor, int anio)
        {
            Titulo = titulo;
            Autor = autor;
            AnioPublicacion = anio;
        }

        public virtual string MostrarInfo()
        {
            return $"Libro - Título: {Titulo}, Autor: {Autor}, Año: {AnioPublicacion}";
        }

        public override string ToString()
        {
            return $"{Titulo} ({AnioPublicacion})";
        }
    }
}
