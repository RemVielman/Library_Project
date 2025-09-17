using System;

namespace Library_UDB
{
    public class Revista : Libro
    {
        public int NumeroEdicion { get; set; }
        public string MesPublicacion { get; set; }

        public Revista() : base() { }

        public Revista(string titulo, string autor, int anio, int numeroEdicion, string mes)
            : base(titulo, autor, anio)
        {
            NumeroEdicion = numeroEdicion;
            MesPublicacion = mes;
        }

        public override string MostrarInfo()
        {
            return $"Revista - Título: {Titulo}, Autor: {Autor}, Año: {AnioPublicacion}, Edición: {NumeroEdicion}, Mes: {MesPublicacion}";
        }

        public override string ToString()
        {
            return $"{Titulo} - Ed. {NumeroEdicion} ({AnioPublicacion})";
        }
    }
}
