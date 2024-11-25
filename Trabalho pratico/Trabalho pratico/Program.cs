using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            }
            else
            {
                grafo = new ListaAdjacencia(vertices, arestas);
            }
            Console.Clear();
            Console.WriteLine("Grafo contruído");

            // Menu para interação do usuário
            int escolha = 1;
            while (escolha != 0)
            {             
                Console.WriteLine("1 - Imprimir grafo");
                Console.WriteLine("2 - Imprimir vértices adjacentes a um vertice v");
                Console.WriteLine("3 - Imprimir arestas incidentes a um vértice v");
                Console.WriteLine("4 - Imprimir os vértices incidentes a uma aresta a");
                Console.WriteLine("5 - Imprimir grau de um vértice v");
                Console.WriteLine("6 - Verificar se dois vértices são adjacentes");
                Console.WriteLine("7 - Substituir o peso de uma aresta a");
                Console.WriteLine("0 - Sair");
                Console.WriteLine("O que deseja fazer?");
                escolha = int.Parse(Console.ReadLine());
                if (escolha == 1) 
                {
                        grafo.Imprimir();
                        Console.WriteLine();
                }
                else if (escolha == 2)
                {
                    Console.WriteLine("Deseja encontrar os adjacentes de qual vertice?");
                    int vSelecionado = int.Parse(Console.ReadLine());
                    grafo.ImprimirVerticesAdjacentes(vSelecionado);
                    Console.WriteLine();
                }
                else if (escolha == 3)
                {
                    Console.WriteLine("Deseja encontrar as arestas incidentes de qual vertice?");
                    int verticeSelecionado = int.Parse(Console.ReadLine());
                    grafo.ImprimirArestasIncidentesAoVertice(verticeSelecionado);
                    Console.WriteLine();
                }
                else if (escolha == 4)
                {
                    Console.WriteLine("Insira o vértice de origem da aresta");
                    int vOrigem = int.Parse(Console.ReadLine());
                    Console.WriteLine("Insira o vértice de destino da aresta");
                    int vDestino = int.Parse(Console.ReadLine());
                    grafo.ImprimirVerticesIncidentesAresta(vOrigem, vDestino);
                }
                else if (escolha == 5)
                {
                    Console.WriteLine("Insira o vértice ");
                    int VConsultGrau = int.Parse(Console.ReadLine());
                    grafo.ImprimirGrauDoVertice(VConsultGrau);
                }
                else if (escolha == 6)
                {
                    Console.WriteLine("Insira o primeiro vértice" );
                    int v1 = int.Parse(Console.ReadLine());
                    Console.WriteLine("Insira o segundo vértice");
                    int v2 = int.Parse(Console.ReadLine());
                    grafo.VerificarAdjacencia(v1, v2);

                }
                else if (escolha == 7)
                {
                    Console.WriteLine("Informe o vertice de origem");
                    int vOrigem = int.Parse(Console.ReadLine());
                    Console.WriteLine("Informe o vertice de destino");
                    int vDestino = int.Parse(Console.ReadLine());
                    Console.WriteLine("Insira o novo peso");
                    int peso = int.Parse(Console.ReadLine());
                    grafo.SubstituirPesoAresta(vOrigem,vDestino, peso);

                }

            }


            Console.ReadLine();
        }

    }
}
