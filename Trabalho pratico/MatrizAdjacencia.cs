using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trabalho_pratico
{
    internal class MatrizAdjacencia: Grafo
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



        public override void ImprimirVerticesAdjacentes(int aresta)
        {
        }

        public override void ImprimirArestasIncidentesAoVertice(int vertice)
        {
        }

    }
}
