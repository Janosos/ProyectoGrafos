using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoGrafos
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Grafo:");
            Grafo grafo = new Grafo();
            // Guardamos los indices correspondientes de cada nuevo nodo del grafo
            int a = grafo.AgregarNodo("Hola");
            int b = grafo.AgregarNodo("Adios");
            int c = grafo.AgregarNodo("Me voy", new List<int> { a, b });

            Nodo aux = new Nodo("Otro");
            int d = grafo.AgregarNodo(aux);
            grafo.AgregarArista(a, d);
            grafo.AgregarArista(c, d);

            Nodo aux2 = new Nodo("Otro mas", new List<int> { b, c, d });
            int e = grafo.AgregarNodo(aux2);
            grafo.AgregarArista(a, e);

            Console.WriteLine(grafo);

            Console.WriteLine("\nCon cambios:");
            grafo.EliminarArista(a, e);
            grafo.EliminarNodo(d);

            // La siguiente instruccion intenta agrega un valor ya existente y lanza una excepcion
            //grafo.AgregarNodo("Hola");

            Console.WriteLine(grafo);

            Console.ReadKey();
        }
    }
}
