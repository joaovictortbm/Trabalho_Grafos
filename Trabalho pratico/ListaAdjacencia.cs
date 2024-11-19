using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trabalho_pratico
{
    internal class ListaAdjacencia : Grafo
    {
        private List<(int destino, int peso)>[] listaAdj;

        public ListaAdjacencia(int vertices, int arestas) : base(vertices, arestas)
        {
            listaAdj = new List<(int, int)>[vertices];
            for (int i = 0; i < vertices; i++)
            {
                listaAdj[i] = new List<(int, int)>();
            }
            Construir();
        }

        public override void Construir()
        {
            for (int i = 0; i < arestas; i++)
            {
                Console.WriteLine($"Digite os detalhes da aresta {i + 1}:");
                Console.Write("Vértice de origem: ");
                int origem = int.Parse(Console.ReadLine());
                Console.Write("Vértice de destino: ");
                int destino = int.Parse(Console.ReadLine());
                Console.Write("Peso: ");
                int peso = int.Parse(Console.ReadLine());

                listaAdj[origem-1].Add((destino, peso));
            }
        }

        public override void Imprimir()
        {
            Console.WriteLine("\nLista de Adjacência:");
            for (int i = 0; i < vertices; i++)
            {
                Console.Write($"{i+1}: ");
                foreach (var (destino, peso) in listaAdj[i])
                {
                    Console.Write($"({destino}, peso={peso}) ");
                }
                Console.WriteLine();
            }
        }
        
        public override void ImprimirVerticesAdjacentes(int vertice)
        {
            if (listaAdj[vertice-1].Count == 0)
            {
                Console.WriteLine("Não há arestas adjacentes.");
                return;
            }
            Console.WriteLine($"(Vertices adjacentes ao vértice {vertice})");
            foreach (var (destino, peso) in listaAdj[vertice-1])
            {
                Console.Write($"({destino}, peso={peso}) ");
            }
        }

        public override void ImprimirArestasIncidentesAoVertice(int vertice)
        {

            // Vértice passado pelo usuário ajustano para zero-indexed
            vertice--; 

            Console.WriteLine($"(Arestas incidentes ao vértice {vertice + 1})");

            bool encontrouArestas = false;

            // Verificar arestas de saída do vértice
            for (int i = 0; i < vertices; i++)
            {
                // Arestas saindo do vértice (origem = vertice)
                foreach (var (destino, peso) in listaAdj[vertice])
                {
                    // Corrigir para verificar a saída de vertice
                    if (destino == i + 1)
                    {
                        Console.WriteLine($"Aresta incidente: ({vertice + 1} -> {destino}, peso={peso})");
                        encontrouArestas = true;
                    }
                }
            }

            // Verificar arestas de entrada para o vértice
            for (int i = 0; i < vertices; i++)
            {
                // Arestas indo para o vértice (destino = vertice)
                foreach (var (destino, peso) in listaAdj[i])
                {
                    if (destino == vertice + 1)  // Ajusta para verificar a chegada do vértice
                    {
                        Console.WriteLine($"Aresta incidente: ({i + 1} -> {vertice + 1}, peso={peso})");
                        encontrouArestas = true;
                    }
                }
            }

            if (!encontrouArestas)
            {
                Console.WriteLine("Não há arestas incidentes ao vértice.");
            }
        }



    }
}