using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Projeto1
{
    public class Alphabet
    {
        public void AlphabetGo()
        {
            Console.WriteLine("AlphabetGo");

            string variaveis, alfabeto, regras, variavelInicial, texto, sequencia;

            Console.Write("Variaveis: (A,B,C) ");
            variaveis = Console.ReadLine();
            Console.Write("Alfabeto: (a,b,c) ");
            alfabeto = Console.ReadLine();
            Console.Write("Regras: (S-XY,X-XaA,X-F) ");
            regras = Console.ReadLine();
            Console.Write("Variavel inicial: (S) ");
            variavelInicial = Console.ReadLine();
            Console.Write("Sequencia de passos: (0,2,3,5) ");
            sequencia = Console.ReadLine();

            var existVariavel = false;

            foreach (var item in variaveis)
            {
                if (item == Convert.ToChar(variavelInicial))
                {
                    existVariavel = true;
                    break;
                }
            }

            if (existVariavel)
            {
                texto = variaveis.Replace(",", "");
                var lista = new List<Rule>();

                foreach (var item in regras.Split(','))
                    lista.Add(new Rule(item.Split('-')[0], item.Split('-')[1]));

                foreach (var step in sequencia)
                {
                    var rule = lista[step];
                    var textoOld = texto;
                    texto = new Regex(Regex.Escape(rule.Key)).Replace(texto, rule.Value, 1);
                    if (textoOld.Equals(texto))
                    {
                        Console.WriteLine("Comando invalido");
                        break;
                    }
                }

                texto = texto.Replace("?", "");

                foreach (var item in variaveis.Split(','))
                {
                    if (texto.Contains(item))
                    {
                        Console.WriteLine($"a palavra não pertence ao alfabeto \n");
                        break;
                    }
                }
                Console.WriteLine(texto);
                Console.ReadLine();
            }
            else
            {
                Console.WriteLine("Nao existe varial para iniciar");
                Console.ReadLine();
            }
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