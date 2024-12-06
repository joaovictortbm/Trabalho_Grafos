using System;

namespace Trabalho_pratico
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Digite a quantidade de vértices: ");
            int vertices = int.Parse(Console.ReadLine());

            Console.Write("Digite a quantidade de arestas: ");
            int arestas = int.Parse(Console.ReadLine());

            // Calcular a densidade do grafo
            double densidade = (double)arestas / (double)(vertices * (vertices - 1));
            Grafo grafo;

            // Escolha da representação baseada na densidade
            if (densidade > 0.5)
            {
                grafo = new MatrizAdjacencia(vertices, arestas);
                Console.WriteLine("A representação escolhida é Matriz de adjacência");
            }
            else
            {
                grafo = new ListaAdjacencia(vertices, arestas);
            }
            
            Console.WriteLine("Grafo construído com sucesso!");

            // Menu para interação do usuário

            int escolha = -1;
            while (escolha != 0)
            {
                Console.WriteLine("\nEscolha uma das opções abaixo:");
                Console.WriteLine("1 - Imprimir grafo");
                Console.WriteLine("2 - Imprimir vértices adjacentes a um vértice");
                Console.WriteLine("3 - Imprimir arestas incidentes a um vértice");
                Console.WriteLine("4 - Imprimir os vértices incidentes a uma aresta");
                Console.WriteLine("5 - Imprimir grau de um vértice");
                Console.WriteLine("6 - Verificar se dois vértices são adjacentes");
                Console.WriteLine("7 - Substituir o peso de uma aresta");
                Console.WriteLine("8 - Imprimir grafo no formato DIMAC");
                Console.WriteLine("9 - Trocar dois vértices");
                Console.WriteLine("10 - Fazer busca em largura (BFS)");
                Console.WriteLine("11 - Fazer busca em profundidade (DFS)");
                Console.WriteLine("12 - Algoritmo de Dijkstra");
                Console.WriteLine("13 - Algoritmo de Floyd-Warshall");
                Console.WriteLine("14 - Imprimir arestas adjacentes a uma aresta");
                Console.WriteLine("0 - Sair");

                Console.Write("Escolha uma opção (0 para sair): ");
                escolha = int.Parse(Console.ReadLine());

                switch (escolha)
                {
                    case 1:
                        grafo.Imprimir();
                        break;

                    case 2:
                        Console.Write("Digite o vértice para encontrar seus adjacentes: ");
                        int vAdj = int.Parse(Console.ReadLine());
                        grafo.ImprimirVerticesAdjacentes(vAdj);
                        break;

                    case 3:
                        Console.Write("Digite o vértice para encontrar suas arestas incidentes: ");
                        int vIncidente = int.Parse(Console.ReadLine());
                        grafo.ImprimirArestasIncidentesAoVertice(vIncidente);
                        break;

                    case 4:
                        Console.Write("Digite o vértice de origem da aresta: ");
                        int vOrigem = int.Parse(Console.ReadLine());
                        Console.Write("Digite o vértice de destino da aresta: ");
                        int vDestino = int.Parse(Console.ReadLine());
                        grafo.ImprimirVerticesIncidentesAresta(vOrigem, vDestino);
                        break;

                    case 5:
                        Console.Write("Digite o vértice para consultar o grau: ");
                        int vGrau = int.Parse(Console.ReadLine());
                        grafo.ImprimirGrauDoVertice(vGrau);
                        break;

                    case 6:
                        Console.Write("Digite o primeiro vértice para verificar a adjacência: ");
                        int v1 = int.Parse(Console.ReadLine());
                        Console.Write("Digite o segundo vértice para verificar a adjacência: ");
                        int v2 = int.Parse(Console.ReadLine());
                        grafo.VerificarAdjacencia(v1, v2);
                        break;

                    case 7:
                        Console.Write("Digite o vértice de origem da aresta: ");
                        int vOrigemPeso = int.Parse(Console.ReadLine());
                        Console.Write("Digite o vértice de destino da aresta: ");
                        int vDestinoPeso = int.Parse(Console.ReadLine());
                        Console.Write("Digite o novo peso da aresta: ");
                        int novoPeso = int.Parse(Console.ReadLine());
                        grafo.SubstituirPesoAresta(vOrigemPeso, vDestinoPeso, novoPeso);
                        break;

                    case 8:
                        grafo.formatoDIMAC();
                        break;

                    case 9:
                        Console.Write("Digite o primeiro vértice para trocar: ");
                        int v1Troca = int.Parse(Console.ReadLine());
                        Console.Write("Digite o segundo vértice para trocar: ");
                        int v2Troca = int.Parse(Console.ReadLine());
                        grafo.TrocarVertices(v1Troca, v2Troca);
                        break;

                    case 10:
                        Console.Write("Digite o vértice de origem para a busca em largura (BFS): ");
                        int vBFS = int.Parse(Console.ReadLine());
                        grafo.BuscaEmLargura(vBFS);
                        break;

                    case 11:
                        Console.Write("Digite o vértice de origem para a busca em profundidade (DFS): ");
                        int vDFS = int.Parse(Console.ReadLine());
                        grafo.DFS(vDFS);
                        break;

                    case 12:
                        Console.Write("Digite o vértice de origem para o algoritmo de Dijkstra: ");
                        int origemDijkstra = int.Parse(Console.ReadLine());
                        Console.Write("Digite o vértice de destino para o algoritmo de Dijkstra: ");
                        int destinoDijkstra = int.Parse(Console.ReadLine());
                        grafo.Dijkstra(origemDijkstra, destinoDijkstra);
                        break;

                    case 13:
                        grafo.FloydWarshall();
                        break;

                    case 14:
                        Console.Write("Digite o vértice de origem da aresta: ");
                        int vOrigemAresta = int.Parse(Console.ReadLine());
                        Console.Write("Digite o vértice de destino da aresta: ");
                        int vDestinoAresta = int.Parse(Console.ReadLine());
                        grafo.ImprimirArestasAdjacentesPorAresta(vOrigemAresta, vDestinoAresta);
                        break;

                    case 0:
                        Console.WriteLine("Saindo...");
                        break;

                    default:
                        Console.WriteLine("Opção inválida. Tente novamente.");
                        break;
                }

                Console.WriteLine(); 
            }
        }
    }
}
