using Projeto2_LFA.graph;
using System;

namespace AFD
{
    public class Afd
    {
        public static void Main(string[] args)
        {
            string op = string.Empty;
            do
            {
                Console.WriteLine("Insira a expressao ou 'Q' para fechar");
                op = Console.ReadLine();

                if (op.Equals("Q"))
                    break;

                Expressao(op);
                Console.WriteLine("\n\n\nPara limpar a tela 'C' para fechar 'Q' ");
                op = Console.ReadLine();
                Console.Clear();

            } while (!op.Equals("Q"));
        }

        #region Show Grapf
        /// <summary>
        /// Exibir o grafo no console
        /// </summary>
        /// <param name="graph">Grafo</param>
        public static void ShowGrapf(Graph graph)
        {
            foreach (var node in graph.nodes)
            {
                foreach (var edge in node.Edges)
                {
                    Console.WriteLine($"{edge.From} --> {edge.To}");
                }
            }
        }

        #endregion

        #region Expressao
        /// <summary>
        /// Expressao insida
        /// </summary>
        /// <param name="exp">Expressao</param>
        public static void Expressao(string exp)
        {
            Graph graph = new Graph();
            exp += "#";
            string aux = "", inicial = " inicial", final = " final";
            foreach (var item in exp)
            {
                switch (item)
                {
                    case '|':
                        graph.AddExp(aux + inicial, aux + final, aux, true);
                        aux = "";
                        break;

                    case '.':
                        graph.AddExp(aux + inicial, aux + final, aux);
                        aux = "";
                        break;

                    case '#':
                        graph.AddExp(aux + inicial, aux + final, aux);
                        aux = "";
                        break;

                    default:
                        aux += item;
                        break;
                }
            }
            graph.DefineDestinoNode();
            ShowGrapf(graph);
        }

        #endregion
    }
}