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
           
            // Ajustar o índice para zero-indexado
            vertice--;

            bool encontrouAdjacentes = false;

            Console.WriteLine($"Vértices adjacentes ao vértice {vertice + 1}:");

            // Percorrer as colunas da linha correspondente ao vértice
            for (int j = 0; j < vertices; j++)
            {
                if (matrizAdj[vertice, j] != 0) // Verificar se existe uma aresta
                {
                    Console.Write($"({j + 1}, peso={matrizAdj[vertice, j]}) ");
                    encontrouAdjacentes = true;
                }
            }

            if (!encontrouAdjacentes)
            {
                Console.WriteLine("Não há vértices adjacentes.");
            }
            else
            {
                Console.WriteLine(); // Nova linha ao final da lista
            }
        }

        public override void ImprimirArestasIncidentesAoVertice(int vertice)
        {
            // Ajustar o índice para zero-indexado
            vertice--;
            
            Console.WriteLine($"Arestas incidentes ao vértice {vertice + 1}:");

            bool encontrouArestas = false;

            // Verificar arestas de entrada para o vértice
            for (int i = 0; i < vertices; i++)
            {
                if (matrizAdj[i, vertice] != 0) // Verificar se há uma aresta de entrada
                {
                    Console.WriteLine($"Aresta incidente: ({i + 1} -> {vertice + 1}, peso={matrizAdj[i, vertice]})");
                    encontrouArestas = true;
                }
            }

            // Verificar arestas de saída do vértice
            for (int j = 0; j < vertices; j++)
            {
                if (matrizAdj[vertice, j] != 0) // Verificar se há uma aresta de saída
                {
                    Console.WriteLine($"Aresta incidente: ({vertice + 1} -> {j + 1}, peso={matrizAdj[vertice, j]})");
                    encontrouArestas = true;
                }
            }

            if (!encontrouArestas)
            {
                Console.WriteLine("Não há arestas incidentes ao vértice.");
            }
        }

        public override void ImprimirVerticesIncidentesAresta(int origem, int destino)
        {

            // Ajustar os índices para zero-indexado
            origem--;
            destino--;

            Console.WriteLine($"Vértices incidentes à aresta ({origem + 1} -> {destino + 1}):");

            // Verificar se a aresta existe na matriz de adjacência
            if (matrizAdj[origem, destino] != 0)
            {
                Console.WriteLine($"Origem: {origem + 1}, Destino: {destino + 1}, Peso: {matrizAdj[origem, destino]}");
            }
            else
            {
                Console.WriteLine("A aresta especificada não existe no grafo.");
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
            verticeInicial--; // Ajustar para zero-indexado

            // Array para armazenar o nível de cada vértice (nível da raiz = 0)
            int[] niveis = new int[(int)vertices];
            int[] predecessores = new int[(int)vertices];

            // Inicializa os arrays manualmente
            for (int i = 0; i < vertices; i++)
            {
                niveis[i] = -1;          // Inicializa todos os níveis como não visitados
                predecessores[i] = -1;   // Inicializa todos os predecessores como -1 (sem predecessor)
            }

            // Fila para a BFS
            Queue<int> fila = new Queue<int>();
            niveis[verticeInicial] = 0; // Nível da raiz é 0
            fila.Enqueue(verticeInicial);

            Console.WriteLine("Árvore de busca em largura:");
            while (fila.Count > 0)
            {
                int verticeAtual = fila.Dequeue();

                // Processar os vértices adjacentes do vértice atual
                Console.WriteLine($"Vértice: {verticeAtual + 1}, Nível: {niveis[verticeAtual]}, Predecessor: {(predecessores[verticeAtual] == -1 ? "Nenhum" : (predecessores[verticeAtual] + 1).ToString())}");

                for (int vizinho = 0; vizinho < vertices; vizinho++)
                {
                    if (matrizAdj[verticeAtual, vizinho] != 0 && niveis[vizinho] == -1) // Verifica se há uma aresta e se não foi visitado
                    {
                        niveis[vizinho] = niveis[verticeAtual] + 1;
                        predecessores[vizinho] = verticeAtual;
                        fila.Enqueue(vizinho);
                    }
                }
            }

            Console.WriteLine("\nNíveis de cada vértice:");
            for (int i = 0; i < vertices; i++)
            {
                Console.WriteLine($"Vértice {i + 1}: Nível {niveis[i]}");
            }

            Console.WriteLine("\nPredecessores de cada vértice:");
            for (int i = 0; i < vertices; i++)
            {
                Console.WriteLine($"Vértice {i + 1}: Predecessor {(predecessores[i] == -1 ? "Nenhum" : (predecessores[i] + 1).ToString())}");
            }
        }
        public override void DFS(int verticeInicial)
        {
            int tempo = 0;

            // Inicializar os arrays dentro do método
            bool[] visitado = new bool[(int)vertices];
            int[] descoberta = new int[(int)vertices];
            int[] finalizacao = new int[(int)vertices];
            int[] predecessores = new int[(int)vertices];

            // Inicializar os predecessores com -1 (nenhum predecessor)
            for (int i = 0; i < vertices; i++)
            {
                predecessores[i] = -1;
            }

            // Chamada recursiva para DFS a partir do vértice inicial
            DFSRecursivoMatriz(verticeInicial - 1, ref tempo, visitado, descoberta, finalizacao, predecessores);

            // Imprimir os resultados
            Console.WriteLine("Vértice\tDescoberta\tFinalização\tPredecessor");
            for (int i = 0; i < vertices; i++)
            {
                Console.WriteLine($"{i + 1}\t{descoberta[i]}\t{finalizacao[i]}\t{(predecessores[i] == -1 ? "Nenhum" : (predecessores[i] + 1).ToString())}");
            }
        }
        private void DFSRecursivoMatriz(int v, ref int tempo, bool[] visitado, int[] descoberta, int[] finalizacao, int[] predecessores)
        {
            // Marcar o vértice como visitado
            visitado[v] = true;
            tempo++;
            descoberta[v] = tempo; // Momento de descoberta

            // Explorar os vizinhos em ordem crescente
            var vizinhos = new List<int>();
            for (int i = 0; i < vertices; i++)
            {
                if (matrizAdj[v, i] != 0) // Verifica se há uma aresta
                {
                    vizinhos.Add(i);
                }
            }

            vizinhos.Sort(); // Ordena os vizinhos pelo índice do vértice

            foreach (var vizinho in vizinhos)
            {
                if (!visitado[vizinho]) // Se o vértice ainda não foi visitado
                {
                    predecessores[vizinho] = v + 1; // O vértice v é o predecessor do vizinho
                    DFSRecursivoMatriz(vizinho, ref tempo, visitado, descoberta, finalizacao, predecessores);
                }
            }

            // Após visitar todos os vizinhos, marca a finalização
            tempo++;
            finalizacao[v] = tempo; // Momento de finalização
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

            // Ajuste para índice 0-based
            origem -= 1;
            destino -= 1;

            // Exibe as arestas adjacentes ao vértice de origem
            Console.WriteLine($"Arestas adjacentes:");

            for (int i = 0; i < vertices; i++)
            {
                if (matrizAdj[origem, i] != 0) // Se há uma aresta do vértice origem para o vértice i
                {
                    Console.WriteLine($"Vértice {origem + 1} -> Vértice {i + 1} com peso {matrizAdj[origem, i]}");
                }
            }
        }
    }

    
}
