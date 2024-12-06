using System;
using System.Collections.Generic;

namespace Trabalho_pratico
{
    internal class MatrizAdjacencia : Grafo
    {
        private int[,] matrizAdj;

        public MatrizAdjacencia(int vertices, int arestas) : base(vertices, arestas)
        {
            matrizAdj = new int[vertices, vertices];
            Construir();
        }

        public override void Construir()
        {
            for (int i = 0; i < arestas; i++)
            {
                Console.WriteLine($"Digite os detalhes da aresta {i + 1}:");
                Console.Write("Vértice de origem: ");
                int origem = int.Parse(Console.ReadLine()) - 1;
                Console.Write("Vértice de destino: ");
                int destino = int.Parse(Console.ReadLine()) - 1;
                Console.Write("Peso: ");
                int peso = int.Parse(Console.ReadLine());

                // Verificar se os índices estão dentro do intervalo
                if (origem >= 0 && origem < vertices && destino >= 0 && destino < vertices)
                {
                    matrizAdj[origem, destino] = peso;
                }
                else
                {
                    Console.WriteLine("Erro: os vértices inseridos estão fora do intervalo válido.");
                }
            }
        }

        public override void Imprimir()
        {
            Console.WriteLine("\nMatriz de Adjacência:");

            //cabeçalho
            Console.Write("   "); // Espaço inicial para alinhar os índices de coluna
            for (int j = 0; j < vertices; j++)
            {
                Console.Write($"{j + 1,4} "); // Adiciona um espaço para cada vértice
            }
            Console.WriteLine();

            // Linhas da matriz
            for (int i = 0; i < vertices; i++)
            {
                Console.Write($"{i + 1,2} ");
                for (int j = 0; j < vertices; j++)
                {
                    Console.Write($"{matrizAdj[i, j],4} ");
                }
                Console.WriteLine();
            }
        }



        public override void ImprimirVerticesAdjacentes(int vertice)
        {
            vertice--;
            List<int> adjac = new List<int>();
            int coluna = matrizAdj.GetLength(1);
            int linha = matrizAdj.GetLength(0);

            Console.WriteLine();
            Console.WriteLine("Vertice Adjacente ao Vertice : " + (vertice + 1));
            Console.WriteLine();

            for (int i = 0; i < linha; i++)
            {
                if (matrizAdj[vertice, i] != 0 && !adjac.Contains(i + 1))
                {
                    Console.WriteLine($"({i + 1})");
                    adjac.Add(i + 1);
                }
            }

            for (int i = 0; i < coluna; i++)
            {
                if (matrizAdj[i, vertice] != 0 && !adjac.Contains(i + 1))
                {
                    Console.WriteLine($"({i + 1})");
                    adjac.Add(i + 1);
                }
            }
        }

        public override void ImprimirArestasIncidentesAoVertice(int vertice)
        {
            vertice--;
            int coluna = matrizAdj.GetLength(1);
            int linha = matrizAdj.GetLength(0);

            Console.WriteLine();
            Console.WriteLine("Aresta Incidente ao Vertice : " + (vertice + 1));
            Console.WriteLine();

            for (int i = 0; i < linha; i++)
            {
                if (matrizAdj[vertice, i] != 0)
                {
                    Console.WriteLine($"({vertice + 1},{i + 1})");
                }
            }

            for (int i = 0; i < coluna; i++)
            {
                if (matrizAdj[i, vertice] != 0)
                {
                    Console.WriteLine($"({i + 1},{vertice + 1})");
                }
            }

        }

        public override void ImprimirVerticesIncidentesAresta(int origem, int destino)
        {
            Console.WriteLine();
            Console.WriteLine($"Vertice Incidente a Aresta : ({origem},{destino})");
            Console.WriteLine();

            if (matrizAdj[origem - 1, destino - 1] != 0)
            {
                Console.WriteLine($"({origem})");
                Console.WriteLine($"({destino})");
            }
            else
            {
                Console.WriteLine("Aresta não encontrada");
            }
        }

        public override void ImprimirGrauDoVertice(int vertice)
        {
            int grauEntrada = 0;
            int grauSaida = 0;

            // Contar grau de saída (arestas saindo do vértice)
            for (int j = 0; j < vertices; j++)
            {
                if (matrizAdj[vertice - 1, j] != 0) // Se houver aresta, incrementa o grau de saída
                {
                    grauSaida++;
                }
            }
            // Contar grau de entrada (arestas chegando ao vértice)
            for (int i = 0; i < vertices; i++)
            {
                if (matrizAdj[i, vertice - 1] != 0) // Se houver aresta, incrementa o grau de entrada
                {
                    grauEntrada++;
                }
            }
            int grauTotal = grauEntrada + grauSaida;
            Console.WriteLine($"Vértice {vertice}:");
            Console.WriteLine($"Grau de entrada: {grauEntrada}");
            Console.WriteLine($"Grau de saída: {grauSaida}");
            Console.WriteLine($"Grau total: {grauTotal}");
        }

        public override void VerificarAdjacencia(int vertice1, int vertice2) // Testar 1
        {
            // Ajustar para índices baseados em 0
            vertice1--;
            vertice2--;

            // Verificar se existe uma aresta entre vertice1 e vertice2
            if (matrizAdj[vertice1, vertice2] != 0)
            {
                Console.WriteLine($"Os vértices {vertice1 + 1} e {vertice2 + 1} são adjacentes.");
            }
            else
            {
                Console.WriteLine($"Os vértices {vertice1 + 1} e {vertice2 + 1} não são adjacentes.");
            }
        }

        public override void SubstituirPesoAresta(int origem, int destino, int novoPeso)
        {
            // Ajustar para índices baseados em 0
            origem--;
            destino--;
            // Verificar se a aresta existe e substituir o peso
            if (matrizAdj[origem, destino] != 0)
            {
                matrizAdj[origem, destino] = novoPeso;
                Console.WriteLine($"Peso da aresta ({origem + 1} -> {destino + 1}) atualizado para {novoPeso}.");
            }
            else
            {
                Console.WriteLine($"Aresta ({origem + 1} -> {destino + 1}) não encontrada.");
            }
        }
        public override void formatoDIMAC()
        {
            // Imprime o número de vértices e arestas
            Console.WriteLine($"{vertices} {arestas}");

            // Percorre a matriz de adjacência para identificar as arestas
            for (int origem = 0; origem < vertices; origem++)
            {
                for (int destino = 0; destino < vertices; destino++)
                {
                    if (matrizAdj[origem, destino] != 0) // Considera apenas arestas existentes
                    {
                        Console.WriteLine($"{origem + 1} {destino + 1} {matrizAdj[origem, destino]}");
                    }
                }
            }
        }
        public override void TrocarVertices(int vertice1, int vertice2) // Testar 3
        {
            // Ajustar para índices baseados em 0
            vertice1--;
            vertice2--;
            // Trocar as arestas de saída (linhas da matriz)
            for (int i = 0; i < vertices; i++)
            {
                // Trocar as arestas que saem do vertice1 e vertice2
                int temp = matrizAdj[vertice1, i];
                matrizAdj[vertice1, i] = matrizAdj[vertice2, i];
                matrizAdj[vertice2, i] = temp;
            }

            // Trocar as arestas de entrada (colunas da matriz)
            for (int j = 0; j < vertices; j++)
            {
                // Trocar as arestas que chegam ao vertice1 e vertice2
                int temp = matrizAdj[j, vertice1];
                matrizAdj[j, vertice1] = matrizAdj[j, vertice2];
                matrizAdj[j, vertice2] = temp;
            }
            Console.WriteLine($"Vértices {vertice1 + 1} e {vertice2 + 1} trocados com sucesso.");
        }

        public override void BuscaEmLargura(int verticeInicial)
        {

        }
        public override void DFS(int verticeInicial)
        {

        }

        public override void Dijkstra(int origem, int destino)
        {
            // Ajustar para índices baseados em 0
            origem--;
            destino--;

            // Inicializar distâncias e predecessores
            int[] distancias = new int[(int)vertices];
            int[] predecessores = new int[(int)vertices];
            bool[] visitado = new bool[(int)vertices];

            // Inicializando as distâncias e predecessores
            for (int i = 0; i < vertices; i++)
            {
                distancias[i] = int.MaxValue; // Distância inicial como infinita
                predecessores[i] = -1;       // Sem predecessores inicialmente
            }

            distancias[origem] = 0; // A distância da origem para ela mesma é 0

            // Fila de prioridade, usada para escolher o próximo vértice com a menor distância
            var fila = new SortedSet<(int distancia, int vertice)>();
            fila.Add((0, origem)); // Adiciona o vértice de origem com distância 0

            while (fila.Count > 0)
            {
                // Pega o vértice com a menor distância
                var (distanciaAtual, verticeAtual) = fila.Min;
                fila.Remove(fila.Min);

                if (visitado[verticeAtual]) continue; // Se já foi visitado, ignora
                visitado[verticeAtual] = true;

                // Se atingiu o destino, podemos parar
                if (verticeAtual == destino)
                    break;

                // Explorar os vizinhos do vértice atual
                for (int vizinho = 0; vizinho < vertices; vizinho++)
                {
                    // Se não houver aresta entre os vértices, ignora
                    if (matrizAdj[verticeAtual, vizinho] == 0) continue;

                    if (visitado[vizinho]) continue; // Se já foi visitado, ignora

                    // Verificar se encontramos um caminho mais curto
                    int novaDistancia = distanciaAtual + matrizAdj[verticeAtual, vizinho];
                    if (novaDistancia < distancias[vizinho])
                    {
                        distancias[vizinho] = novaDistancia;
                        predecessores[vizinho] = verticeAtual; // Atualiza o predecessor
                        fila.Add((novaDistancia, vizinho)); // Adiciona na fila de prioridades
                    }
                }
            }

            // Imprimir o caminho e a distância
            if (distancias[destino] == int.MaxValue)
            {
                Console.WriteLine("Não existe caminho entre o vértice origem e o vértice destino.");
                return;
            }

            Console.WriteLine($"Distância do caminho mínimo de {origem + 1} a {destino + 1}: {distancias[destino]}");

            // Reconstruir o caminho a partir dos predecessores
            var caminho = new Stack<int>();
            int v = destino;
            while (v != -1)
            {
                caminho.Push(v + 1);
                v = predecessores[v];
            }

            // Imprimir o caminho
            Console.Write("Caminho: ");
            while (caminho.Count > 0)
            {
                Console.Write(caminho.Pop());
                if (caminho.Count > 0) Console.Write(" -> ");
            }
            Console.WriteLine();
        }
        public override void FloydWarshall()
        {
            // Inicializar a matriz de distâncias com os valores da matriz de adjacência
            int[,] distancias = new int[(int)vertices, (int)vertices];

            // Preencher a matriz com os pesos das arestas
            for (int i = 0; i < vertices; i++)
            {
                for (int j = 0; j < vertices; j++)
                {
                    if (i == j)
                        distancias[i, j] = 0; // Distância de um vértice para ele mesmo é 0
                    else if (matrizAdj[i, j] != 0)
                        distancias[i, j] = matrizAdj[i, j]; // Distância entre vértices adjacentes
                    else
                        distancias[i, j] = int.MaxValue; // Arestas não existentes têm distância infinita
                }
            }

            // Algoritmo de Floyd-Warshall
            for (int k = 0; k < vertices; k++) // Vértice intermediário
            {
                for (int i = 0; i < vertices; i++) // Vértice de origem
                {
                    for (int j = 0; j < vertices; j++) // Vértice de destino
                    {
                        // Verificar se o caminho via 'k' é mais curto que o caminho direto
                        if (distancias[i, k] != int.MaxValue && distancias[k, j] != int.MaxValue &&
                            distancias[i, j] > distancias[i, k] + distancias[k, j])
                        {
                            distancias[i, j] = distancias[i, k] + distancias[k, j]; // Atualizar a distância
                        }
                    }
                }
            }

            // Imprimir a matriz de distâncias mínimas entre todos os pares de vértices
            Console.WriteLine("Matriz de distâncias mínimas entre todos os pares de vértices:");
            for (int i = 0; i < vertices; i++)
            {
                for (int j = 0; j < vertices; j++)
                {
                    if (distancias[i, j] == int.MaxValue)
                        Console.Write("INF "); // Representar infinito
                    else
                        Console.Write($"{distancias[i, j]} ");
                }
                Console.WriteLine();
            }
        }
         public override void ImprimirArestasAdjacentesPorAresta(int origem, int destino)
        {
            int coluna = matrizAdj.GetLength(1);
            int linha = matrizAdj.GetLength(0);

            Console.WriteLine();
            Console.WriteLine("Aresta Adjacente a Aresta : " + (origem));
            Console.WriteLine();

            for (int i = 0; i < linha; i++)
            {
                if (matrizAdj[origem - 1, i] != 0)
                {
                    Console.WriteLine($"({origem},{i+1})");
                }
            }

            for (int i = 0; i < coluna; i++)
            {
                if (matrizAdj[i, origem - 1] != 0)
                {
                    Console.WriteLine($"({i+1},{origem})");
                }
            }
        }
    }

    
}
