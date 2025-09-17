using System;
using System.Collections.Generic;

namespace Library_UDB
{
    class Program
    {
        static void Main()
        {
            Libreria libreria = new Libreria();

            while (true)
            {
                Console.WriteLine("\n=== Gestión de Librería ===");
                Console.WriteLine("1) Agregar libro");
                Console.WriteLine("2) Agregar revista");
                Console.WriteLine("3) Buscar por título");
                Console.WriteLine("4) Eliminar por índice");
                Console.WriteLine("5) Listar todo");
                Console.WriteLine("6) Modificar por índice");
                Console.WriteLine("7) Estadísticas");
                Console.WriteLine("0) Salir");
                Console.Write("Elige una opción: ");
                string opcion = Console.ReadLine();

                switch (opcion)
                {
                    case "1":
                        AgregarLibro(libreria);
                        break;
                    case "2":
                        AgregarRevista(libreria);
                        break;
                    case "3":
                        Buscar(libreria);
                        break;
                    case "4":
                        Eliminar(libreria);
                        break;
                    case "5":
                        Listar(libreria);
                        break;
                    case "6":
                        Modificar(libreria);
                        break;
                    case "7":
                        Estadisticas(libreria);
                        break;
                    case "0":
                        Console.WriteLine("Saliendo... :)");
                        return;
                    default:
                        Console.WriteLine("Opción no válida, intenta de nuevo.");
                        break;
                }
            }
        }

        static void AgregarLibro(Libreria lib)
        {
            Console.Write("Título: ");
            string titulo = Console.ReadLine();
            Console.Write("Autor: ");
            string autor = Console.ReadLine();
            Console.Write("Año de publicación: ");
            int anio = ParseIntConsole();

            lib.Agregar(new Libro { Titulo = titulo, Autor = autor, AnioPublicacion = anio });
            Console.WriteLine("Libro agregado.");
        }

        static void AgregarRevista(Libreria lib)
        {
            Console.Write("Título: ");
            string titulo = Console.ReadLine();
            Console.Write("Autor: ");
            string autor = Console.ReadLine();
            Console.Write("Año de publicación: ");
            int anio = ParseIntConsole();
            Console.Write("Número de edición: ");
            int numEd = ParseIntConsole();
            Console.Write("Mes de publicación: ");
            string mes = Console.ReadLine();

            lib.Agregar(new Revista
            {
                Titulo = titulo,
                Autor = autor,
                AnioPublicacion = anio,
                NumeroEdicion = numEd,
                MesPublicacion = mes
            });
            Console.WriteLine("Revista agregada.");
        }

        static void Buscar(Libreria lib)
        {
            Console.Write("Texto a buscar en título: ");
            string texto = Console.ReadLine();
            var resultados = lib.BuscarPorTitulo(texto);
            if (resultados.Count == 0)
            {
                Console.WriteLine("No se encontraron coincidencias.");
                return;
            }

            Console.WriteLine($"Se encontraron {resultados.Count} resultado(s):");
            for (int i = 0; i < resultados.Count; i++)
            {
                Console.WriteLine($"[{i}] {resultados[i].MostrarInfo()}");
            }
        }

        static void Eliminar(Libreria lib)
        {
            var lista = lib.Listar();
            if (lista.Count == 0)
            {
                Console.WriteLine("La librería está vacía.");
                return;
            }

            Console.WriteLine("Elementos actuales:");
            for (int i = 0; i < lista.Count; i++)
            {
                Console.WriteLine($"[{i}] {lista[i].MostrarInfo()}");
            }
            Console.Write("Ingresa el índice a eliminar: ");
            int idx = ParseIntConsole();
            if (lib.EliminarPorIndice(idx))
                Console.WriteLine("Eliminado correctamente.");
            else
                Console.WriteLine("Índice inválido.");
        }

        static void Listar(Libreria lib)
        {
            var lista = lib.Listar();
            if (lista.Count == 0)
            {
                Console.WriteLine("La librería está vacía.");
                return;
            }
            Console.WriteLine("Contenido de la librería:");
            for (int i = 0; i < lista.Count; i++)
            {
                Console.WriteLine($"[{i}] {lista[i].MostrarInfo()}");
            }
        }

        static void Modificar(Libreria lib)
        {
            var lista = lib.Listar();
            if (lista.Count == 0)
            {
                Console.WriteLine("No hay elementos para modificar.");
                return;
            }
            Console.WriteLine("Elementos actuales:");
            for (int i = 0; i < lista.Count; i++)
            {
                Console.WriteLine($"[{i}] {lista[i].MostrarInfo()}");
            }
            Console.Write("Ingresa el índice a modificar: ");
            int idx = ParseIntConsole();
            if (idx < 0 || idx >= lista.Count)
            {
                Console.WriteLine("Índice inválido.");
                return;
            }

            Console.Write("Nuevo título: ");
            string titulo = Console.ReadLine();
            Console.Write("Nuevo autor: ");
            string autor = Console.ReadLine();
            Console.Write("Nuevo año de publicación: ");
            int anio = ParseIntConsole();

            // Si el elemento original era una Revista, pedimos edición y mes
            if (lista[idx] is Revista)
            {
                Console.Write("Nuevo número de edición: ");
                int numEd = ParseIntConsole();
                Console.Write("Nuevo mes de publicación: ");
                string mes = Console.ReadLine();

                var nuevaRevista = new Revista
                {
                    Titulo = titulo,
                    Autor = autor,
                    AnioPublicacion = anio,
                    NumeroEdicion = numEd,
                    MesPublicacion = mes
                };
                lib.Modificar(idx, nuevaRevista);
            }
            else
            {
                var nuevoLibro = new Libro
                {
                    Titulo = titulo,
                    Autor = autor,
                    AnioPublicacion = anio
                };
                lib.Modificar(idx, nuevoLibro);
            }

            Console.WriteLine("Modificación realizada.");
        }

        static void Estadisticas(Libreria lib)
        {
            var s = lib.Estadisticas();
            Console.WriteLine($"Total: {s.total}  |  Libros: {s.libros}  |  Revistas: {s.revistas}");
        }

        static int ParseIntConsole()
        {
            while (true)
            {
                string s = Console.ReadLine();
                if (int.TryParse(s, out int v)) return v;
                Console.Write("Entrada inválida. Ingresa un número: ");
            }
        }
    }
}

