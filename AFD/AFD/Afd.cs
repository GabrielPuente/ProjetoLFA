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
                Console.Clear();
                Console.WriteLine("Insira a expressao ou 'Q' para fechar");
                op = Console.ReadLine();

                if (op.Equals("Q") || op.Equals("q") )
                    break;

                Console.WriteLine("\n\n");
                Expressao(op);

                Console.WriteLine("\n\n\nPara limpar a tela 'C' para fechar 'Q' ");

                op = Console.ReadLine();

            } while (!op.Equals("Q") || !op.Equals("q"));
        }

        #region Expressao
        /// <summary>
        /// Expressao insirida
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

                    case '+':
                        graph.AddExpMais(aux + inicial, aux + final, aux);
                        aux = "";
                        break;

                    case '*':
                        graph.AddExpCline(aux + inicial, aux + final, aux);
                        aux = "";
                        break;

                    case '#':
                        if(!string.IsNullOrEmpty(aux))
                            graph.AddExp(aux + inicial, aux + final, aux);
                        aux = "";
                        break;

                    default:
                        aux += item;
                        break;
                }
            }
            graph.DefineFinalNode();
            ShowGrapf(graph);
        }
   
        #endregion

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
                    if (edge.To.isFinal)
                        Console.WriteLine($"{edge.From} ---{edge.Cost}--> {edge.To} - É final");

                    else
                        Console.WriteLine($"{edge.From} ---{edge.Cost}--> {edge.To}");
                }
            }
        }
        #endregion
    }
}