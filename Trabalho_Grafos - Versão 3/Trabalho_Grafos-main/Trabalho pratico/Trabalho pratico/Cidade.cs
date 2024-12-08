using System;
using System.Collections.Generic;

namespace Trabalho_pratico
{
    internal class Cidade
    {
        private int vertices;
        private int arestas;
        private List<Tuple<int, int, int, int>> trechos; // (A, B, T, R)

        public Cidade(int vertices, int arestas)
        {
            this.vertices = vertices;
            this.arestas = arestas;
            trechos = new List<Tuple<int, int, int, int>>();
        }

        // Método para construir o grafo com os trechos e seus custos
        public void Construir()
        {
            for (int i = 0; i < arestas; i++)
            {
                Console.WriteLine("Digite os detalhes da aresta" + i + 1);
                Console.Write("Cidade de origem: ");
                int origem = int.Parse(Console.ReadLine()) - 1; 
                Console.Write("Cidade de destino: ");
                int destino = int.Parse(Console.ReadLine()) - 1; 
                Console.Write("Tipo de transporte (0 para ônibus | 1 para avião): ");
                int tipoTransporte = int.Parse(Console.ReadLine());
                Console.Write("Custo do transporte: ");
                int custo = int.Parse(Console.ReadLine());

                // Armazenando o trecho no formato (A,B,T,R)
                trechos.Add(new Tuple<int, int, int, int>(origem, destino, tipoTransporte, custo));
            }
        }

        // Método para calcular o custo mínimo usando o algoritmo de Dijkstra
        public int Dijkstra(int start, int end, int tipoTransporte)
        {
            // Criação de lista de adjacências considerando o tipo de transporte
            int[] dist = new int[vertices];
            for (int i = 0; i < vertices; i++)
                dist[i] = int.MaxValue;
            dist[start] = 0;

            var priorityQueue = new List<Tuple<int, int>>(); // Lista para simular a PriorityQueue
            priorityQueue.Add(new Tuple<int, int>(start, 0));
            priorityQueue.Sort((a, b) => a.Item2.CompareTo(b.Item2)); // Ordena a lista pela prioridade (custo)

            while (priorityQueue.Count > 0)
            {
                var item = priorityQueue[0];
                priorityQueue.RemoveAt(0); // Remove o item de menor custo
                int u = item.Item1;

                foreach (var trecho in trechos)
                {
                    if (trecho.Item3 == tipoTransporte && trecho.Item1 == u)
                    {
                        int v = trecho.Item2;
                        int peso = trecho.Item4;

                        if (dist[u] + peso < dist[v])
                        {
                            dist[v] = dist[u] + peso;
                            priorityQueue.Add(new Tuple<int, int>(v, dist[v]));
                            priorityQueue.Sort((a, b) => a.Item2.CompareTo(b.Item2)); // Ordena 
                        }
                    }
                }
            }

            return dist[end];
        }

      
        public void ResolverDesafio()
        {
            // Usando Dijkstra para calcular o custo com ônibus 
            int custoOnibus = Dijkstra(0, vertices - 1, 0);

            // Usando Dijkstra para calcular o custo com avião 
            int custoAviao = Dijkstra(0, vertices - 1, 1);

            // Comparando os custos e retornando o mínimo
            int custoMinimo = Math.Min(custoOnibus, custoAviao);
            Console.WriteLine("Custo mínimo necessário:" + custoMinimo);
            
        }
    }
}