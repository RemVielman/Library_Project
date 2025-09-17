using System;
using System.Collections.Generic;
using System.Linq;

namespace Library_UDB
{
    public class Libreria
    {
        private readonly List<Libro> catalogo = new List<Libro>();

        // Agregar (acepta Libro o Revista)
        public void Agregar(Libro libro) => catalogo.Add(libro);

        // Buscar por título (parcial, case-insensitive)
        public List<Libro> BuscarPorTitulo(string texto)
        {
            if (string.IsNullOrWhiteSpace(texto)) return new List<Libro>(catalogo);
            return catalogo
                .Where(l => !string.IsNullOrEmpty(l.Titulo) &&
                            l.Titulo.IndexOf(texto, StringComparison.OrdinalIgnoreCase) >= 0)
                .ToList();
        }

        // Eliminar por índice
        public bool EliminarPorIndice(int indice)
        {
            if (indice < 0 || indice >= catalogo.Count) return false;
            catalogo.RemoveAt(indice);
            return true;
        }

        // Modificar por índice
        public bool Modificar(int indice, Libro nuevo)
        {
            if (indice < 0 || indice >= catalogo.Count) return false;
            catalogo[indice] = nuevo;
            return true;
        }

        // Listar todos
        public List<Libro> Listar() => new List<Libro>(catalogo);

        // Estadística simple: total, libros, revistas
        public (int total, int libros, int revistas) Estadisticas()
        {
            int total = catalogo.Count;
            int revistas = catalogo.OfType<Revista>().Count();
            int libros = total - revistas;
            return (total, libros, revistas);
        }
    }
}
