using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoGrafos
{
    internal class Grafo
    {
        public List<Nodo> Nodos;

        public Grafo() { 
            Nodos = new List<Nodo>();
        }

        // Agrega un nodo y retorna el indice en el que se encuentra en base 0
        public int AgregarNodo(Nodo nodo)
        {
            if (BuscarNodo(nodo.Dato) != -1)
                throw new Exception("El nodo ya existe");
            Nodos.Add(nodo);
            return Nodos.Count - 1;
        }

        public int AgregarNodo(string dato, List<int> conexiones = null)
        {
            if (BuscarNodo(dato) != -1)
                throw new Exception("El nodo ya existe");
            Nodo nodo = new Nodo(dato, conexiones);
            return AgregarNodo(nodo);
        }

        public void AgregarArista(int origen, int destino)
        {
            if (origen > Nodos.Count - 1 || destino > Nodos.Count - 1)
                throw new Exception("Origen o destino fuera del grafo");
            if (destino < 0 || origen < 0)
                throw new Exception("Ninguno de los argumentos puede ser menor a 0");

            // Busca que no exista ya una arista al elemento
            foreach (int ady in Nodos[origen].Adyacentes)
                if (destino == ady)
                    return;
            Nodos[origen].Adyacentes.Add(destino);
        }

        public void EliminarArista(int origen, int destino)
        {
            if (origen > Nodos.Count - 1 || destino > Nodos.Count - 1)
                throw new Exception("Origen o destino fuera del grafo");
            if (destino < 0 || origen < 0)
                throw new Exception("Ninguno de los argumentos puede ser menor a 0");
            List<int> aux = Nodos[origen].Adyacentes;
            for (int i = 0; i < aux.Count; i++)
            {
                if (aux[i] == destino)
                {
                    aux.RemoveAt(i);
                    return;
                }
            }
        }

        public void EliminarNodo(int origen)
        {
            if (Nodos.Count == 0)
                throw new Exception("No hay nodos para eliminar");
            if (origen > Nodos.Count - 1 || origen < 0)
                throw new Exception("Fuera de rango");
            // Eliminamos de la lista
            Nodos.RemoveAt(origen);

            // Buscamos referencias en los otros nodos y las eliminamos
            for(int i = 0;i < Nodos.Count;i++)
            {
                List<int> aux = Nodos[i].Adyacentes;
                for (int j = 0; j < aux.Count; j++)
                    if (aux[j] == origen)
                        aux.RemoveAt(j);
            }
        }

        public int BuscarNodo(string dato)
        {
            for (int i = 0; i < Nodos.Count; i++)
            {
                string aux = Nodos[i].Dato;
                if (aux == dato)
                    return i;
            }
            return -1;
        }

        public override string ToString()
        {
            int i = 0;
            string str = "";
            foreach (Nodo nodo in Nodos)
            {
                str += i + ": " + nodo.ToString() + "\n";
                i++;
            }

            return str;
        }
    }
}
