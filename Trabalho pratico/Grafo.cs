using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trabalho_pratico
{
    internal abstract class Grafo
    {
        protected double vertices;
        protected double arestas;

        public Grafo(int vertices, int arestas)
        {
            this.vertices = vertices;
            this.arestas = arestas;
        }

        public abstract void Construir();
        public abstract void Imprimir();
        public abstract void ImprimirVerticesAdjacentes(int aresta);
        public abstract void ImprimirArestasIncidentesAoVertice(int vertice);
        
    }
}
