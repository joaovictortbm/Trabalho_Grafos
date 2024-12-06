using System;
using System.Collections.Generic;
using System.Linq;

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


        public override void ImprimirVerticesIncidentesAresta(int origem, int destino)
        {
            bool encontrouAresta = false;

            Console.WriteLine($"Vértices incidentes à aresta ({origem} -> {destino}):");

            // Verificar se a aresta existe na lista de adjacência
            foreach (var (dest, peso) in listaAdj[origem - 1])
            {
                if (dest == destino)
                {
                    encontrouAresta = true;
                    Console.WriteLine($"Origem: {origem}, Destino: {destino}");
                }
            }

            // Se a aresta não foi encontrada, exibe uma mensagem
            if (!encontrouAresta)
            {
                Console.WriteLine("A aresta especificada não existe no grafo.");
            }
        }

        public override void ImprimirGrauDoVertice(int vertice)
        {
            int grauEntrada = 0;
            int grauSaida = listaAdj[vertice - 1].Count;

            // Contar arestas que têm o vértice como destino (grau de entrada)
            for (int i = 0; i < vertices; i++)
            {
                foreach (var (destino, peso) in listaAdj[i])
                {
                    if (destino == vertice)
                    {
                        grauEntrada++;
                    }
                }
            }

            int grauTotal = grauEntrada + grauSaida;

            Console.WriteLine($"Vértice {vertice}:");
            Console.WriteLine($"Grau total: {grauTotal}");
        }

        public override void VerificarAdjacencia(int vertice1, int vertice2)
        {
            bool saoAdjacentes = false;

            // Verificar se existe uma aresta de vertice1 para vertice2
            foreach (var (destino, peso) in listaAdj[vertice1 - 1])
            {
                if (destino == vertice2)
                {
                    saoAdjacentes = true;
                    break;
                }
            }

            if (saoAdjacentes)
            {
                Console.WriteLine($"Os vértices {vertice1} e {vertice2} são adjacentes.");
            }
            else
            {
                Console.WriteLine($"Os vértices {vertice1} e {vertice2} não são adjacentes.");
            }
        }

        public override void SubstituirPesoAresta(int origem, int destino, int novoPeso)
        {
            bool encontrouAresta = false;

            // Localizar a aresta na lista de adjacência e substituir o peso
            for (int i = 0; i < listaAdj[origem - 1].Count; i++)
            {
                if (listaAdj[origem - 1][i].destino == destino)
                {
                    listaAdj[origem - 1][i] = (destino, novoPeso);
                    encontrouAresta = true;
                    break;
                }
            }

            if (encontrouAresta)
            {
                Console.WriteLine($"Peso da aresta ({origem} -> {destino}) atualizado para {novoPeso}.");
            }
            else
            {
                Console.WriteLine($"Aresta ({origem} -> {destino}) não encontrada.");
            }
        }

        public override void formatoDIMAC()
        {
            // Imprime o número de vértices e arestas
            Console.WriteLine($"{vertices} {arestas}");

            for (int origem = 0; origem < vertices; origem++)
            {
                foreach (var (destino, peso) in listaAdj[origem])
                {
                    // Imprime uma aresta por linha no formato "origem destino peso"
                    Console.WriteLine($"{origem + 1} {destino} {peso}");
                }
            }
        }

        public override void TrocarVertices(int vertice1, int vertice2)
        {
            // Ajustar para índices baseados em 0
            vertice1--;
            vertice2--;


            // Trocar as arestas de saída
            var ArestasSaidav1 = listaAdj[vertice1];
            listaAdj[vertice1] = listaAdj[vertice2];
            listaAdj[vertice2] = ArestasSaidav1;

            // Trocar as arestas de entrada
            for (int i = 0; i < vertices; i++)
            {
                // Atualizar referências ao vértice1
                for (int j = 0; j < listaAdj[i].Count; j++)
                {
                    if (listaAdj[i][j].destino == vertice1 + 1)
                    {
                        listaAdj[i][j] = (vertice2 + 1, listaAdj[i][j].peso);
                    }
                    else if (listaAdj[i][j].destino == vertice2 + 1)
                    {
                        listaAdj[i][j] = (vertice1 + 1, listaAdj[i][j].peso);
                    }
                }
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

                // Ordenar os vértices adjacentes numericamente antes de processá-los
                var adjacentesOrdenados = listaAdj[verticeAtual]
                    .OrderBy(a => a.destino)
                    .ToList();

                Console.WriteLine($"Vértice: {verticeAtual + 1}, Nível: {niveis[verticeAtual]}, Predecessor: {(predecessores[verticeAtual] == -1 ? "Nenhum" : (predecessores[verticeAtual] + 1).ToString())}");

                foreach (var (destino, peso) in adjacentesOrdenados)
                {
                    int vizinho = destino - 1; // Ajustar para zero-indexado
                    if (niveis[vizinho] == -1) // Se ainda não visitado
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
            DFSRecursivo(verticeInicial - 1, ref tempo, visitado, descoberta, finalizacao, predecessores);

            // Imprimir os resultados
            Console.WriteLine("Vértice\tDescoberta\tFinalização\tPredecessor");
            for (int i = 0; i < vertices; i++)
            {
                Console.WriteLine($"{i + 1}\t{descoberta[i]}\t{finalizacao[i]}\t{predecessores[i]}");
            }
        }

        private void DFSRecursivo(int v, ref int tempo, bool[] visitado, int[] descoberta, int[] finalizacao, int[] predecessores)
        {
            // Marcar o vértice como visitado
            visitado[v] = true;
            tempo++;
            descoberta[v] = tempo; // Momento de descoberta

            // Explorar os vizinhos em ordem crescente
            var vizinhos = new List<(int, int)>(listaAdj[v]);
            vizinhos.Sort((a, b) => a.Item1.CompareTo(b.Item1)); // Ordena os vizinhos pelo vértice de destino

            foreach (var (destino, peso) in vizinhos)
            {
                if (!visitado[destino - 1]) // Se o vértice ainda não foi visitado
                {
                    predecessores[destino - 1] = v + 1; // O vértice v é o predecessor de destino
                    DFSRecursivo(destino - 1, ref tempo, visitado, descoberta, finalizacao, predecessores);
                }
            }

            // Após visitar todos os vizinhos, marca a finalização
            tempo++;
            finalizacao[v] = tempo; // Momento de finalização
        }

        public override void Dijkstra(int origem, int destino)
        {
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

            distancias[origem - 1] = 0; // A distância da origem para ela mesma é 0

            // Fila de prioridade, usada para escolher o próximo vértice com a menor distância
            var fila = new SortedSet<(int distancia, int vertice)>();
            fila.Add((0, origem - 1)); // Adiciona o vértice de origem com distância 0

            while (fila.Count > 0)
            {
                // Pega o vértice com a menor distância
                var (distanciaAtual, verticeAtual) = fila.Min;
                fila.Remove(fila.Min);

                if (visitado[verticeAtual]) continue; // Se já foi visitado, ignora
                visitado[verticeAtual] = true;

                // Se atingiu o destino, podemos parar
                if (verticeAtual == destino - 1)
                    break;

                // Explorar os vizinhos do vértice atual
                foreach (var (vizinho, peso) in listaAdj[verticeAtual])
                {
                    if (visitado[vizinho - 1]) continue; // Se já foi visitado, ignora

                    // Verificar se encontramos um caminho mais curto
                    int novaDistancia = distanciaAtual + peso;
                    if (novaDistancia < distancias[vizinho - 1])
                    {
                        distancias[vizinho - 1] = novaDistancia;
                        predecessores[vizinho - 1] = verticeAtual + 1; // Atualiza o predecessor
                        fila.Add((novaDistancia, vizinho)); // Adiciona na fila de prioridades
                    }
                }
            }

            // Imprimir o caminho e a distância
            if (distancias[destino - 1] == int.MaxValue)
            {
                Console.WriteLine("Não existe caminho entre o vértice origem e o vértice destino.");
                return;
            }

            Console.WriteLine($"Distância do caminho mínimo de {origem} a {destino}: {distancias[destino - 1]}");

            // Reconstruir o caminho a partir dos predecessores
            var caminho = new Stack<int>();
            int v = destino - 1;
            while (v != -1)
            {
                caminho.Push(v + 1);
                v = predecessores[v] - 1;
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
            // Inicializar a matriz de distâncias
            int[,] distancias = new int[(int)vertices, (int)vertices];

            // Inicializar a matriz com os pesos das arestas
            // Colocamos infinita (int.MaxValue) para as arestas não diretas
            for (int i = 0; i < vertices; i++)
            {
                for (int j = 0; j < vertices; j++)
                {
                    if (i == j)
                        distancias[i, j] = 0; // Distância de um vértice para ele mesmo é 0
                    else
                        distancias[i, j] = int.MaxValue; // Inicialmente todas as distâncias são infinitas
                }
            }

            // Preencher a matriz com as distâncias diretas entre os vértices
            for (int i = 0; i < vertices; i++)
            {
                foreach (var (destino, peso) in listaAdj[i])
                {
                    distancias[i, destino - 1] = peso; // Atualizar a distância entre vértices adjacentes
                }
            }

            // Algoritmo de Floyd-Warshall
            for (int k = 0; k < vertices; k++) // Considerar cada vértice como intermediário
            {
                for (int i = 0; i < vertices; i++) // Vértice de origem
                {
                    for (int j = 0; j < vertices; j++) // Vértice de destino
                    {
                        // Verificar se o caminho via 'k' é mais curto do que o caminho direto
                        if (distancias[i, k] != int.MaxValue && distancias[k, j] != int.MaxValue &&
                            distancias[i, j] > distancias[i, k] + distancias[k, j])
                        {
                            distancias[i, j] = distancias[i, k] + distancias[k, j]; // Atualizar a distância
                        }
                    }
                }
            }

            // Imprimir a matriz de distâncias
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
            Console.WriteLine($"Arestas adjacentes ao vértice {origem + 1}:");
            foreach (var (adjacente, peso) in listaAdj[origem])
            {
                Console.WriteLine($"Vértice {origem + 1} -> Vértice {adjacente} com peso {peso}");
            }
        }











    }
}