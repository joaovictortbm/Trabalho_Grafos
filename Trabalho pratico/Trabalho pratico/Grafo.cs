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
        public abstract void ImprimirVerticesIncidentesAresta(int origem, int destino);
        public abstract void ImprimirGrauDoVertice(int vertice);
        public abstract void VerificarAdjacencia(int vertice1, int vertice2);
        public abstract void SubstituirPesoAresta(int origem, int destino, int novoPeso);
        public abstract void formatoDIMAC();
        public abstract void TrocarVertices(int vertice1, int vertice2);

        public abstract void BuscaEmLargura(int verticeInicial);
        public abstract void DFS(int verticeInicial);
        public abstract void Dijkstra(int origem, int destino);
        public abstract void FloydWarshall();
        public abstract void ImprimirArestasAdjacentesPorAresta(int origem, int destino);
    }
}
