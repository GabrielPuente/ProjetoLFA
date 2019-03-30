using Projeto2_LFA.DATA_STRUCTURE;
using System;

namespace AFD
{
    public class Afd
    {
        public static void Main(string[] args)
        {
            Graph graph = new Graph();
            string exp = Console.ReadLine() + "#";
            string aux = "", inicial = " inicial", final = " final";
            bool isOr = false;

            foreach (var item in exp)
            {
                if (item == '|')
                {
                    graph.AddExp(aux + inicial, aux + final, aux, isOr);
                    isOr = true;
                    aux = "";
                }
                else if (item == '.')
                {
                    graph.AddExp(aux + inicial, aux + final, aux, isOr);
                    isOr = false;
                    aux = "";
                }
                else if (item == '#')
                {
                    graph.AddExp(aux + inicial, aux + final, aux, isOr);
                    isOr = false;
                    aux = "";
                }
                else
                    aux += item;
            }
            graph.DefineFinalNode();

            Console.ReadLine();
        }
    }
}