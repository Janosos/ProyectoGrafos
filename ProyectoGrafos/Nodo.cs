using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoGrafos
{
    internal class Nodo
    {
        // Agregar otros valores
        public string Dato { get; set; }
        public List<int> Adyacentes { get; }

        public Nodo(string dato, List<int> adyacentes = null)
        {
            Dato = dato;
            if (adyacentes != null)
                Adyacentes = adyacentes;
            else Adyacentes = new List<int>();
        }

        public override string ToString()
        {
            string valor = "[" + Dato + "] -> [";
            for (int i = 0; i < Adyacentes.Count; i++)
            {
                valor += Adyacentes[i];
                if (i < Adyacentes.Count - 1)
                {
                    valor += ",";
                }
            }
            valor += "]";
            return valor;
        }
    }
}
