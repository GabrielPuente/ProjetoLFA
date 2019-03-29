using ProjetoGrafos.DataStructure;
using System;
using System.Collections;
using System.Collections.Generic;

namespace Projeto1
{
    class RollBack
    {
        public void StepByStep()
        {
            Console.WriteLine("RollBack");

            string variaveis, alfabeto, regras, palavra, variavelInicial, texto;

            Console.Write("Variaveis: (A,B,C) ");
            variaveis = Console.ReadLine();
            Console.Write("Alfabeto: (a,b,c) ");
            alfabeto = Console.ReadLine();
            Console.Write("Regras: (S-XY,X-XaA,X-F) ");
            regras = Console.ReadLine();
            Console.Write("Variavel inicial: (S) ");
            variavelInicial = Console.ReadLine();
            Console.WriteLine("Palavra desejada: (baba)");
            palavra = Console.ReadLine();

            var existVariavel = false;

            foreach (var item in variaveis)
            {
                if (item == Convert.ToChar(variavelInicial))
                {
                    existVariavel = true;
                    break;
                }
            }

            Console.WriteLine("Falta implementar algumas partes");

            if (existVariavel)
            {
                var listaRegras = new List<Rule>();
                foreach (var item in regras.Split(','))
                    listaRegras.Add(new Rule(item.Split('-')[0], item.Split('-')[1]));

                texto = variaveis.Replace(",", "");
                Graph graph = new Graph();

                while (!texto.Equals(palavra))
                {
                    Queue queue = new Queue();
                    queue.Enqueue(texto);
                    
                    //Fazer todas as possibilidades de textos
                    //Fazer o passeio em largura e achar os passos
                }
            }
            else
            {
                Console.WriteLine("Nao existe varial para iniciar");
                Console.ReadLine();
            }
        }

        public class Rule
        {
            public Rule(string key, string value)
            {
                this.Key = key;
                this.Value = value;
            }
            public string Key { get; set; }
            public string Value { get; set; }
        }
    }
}