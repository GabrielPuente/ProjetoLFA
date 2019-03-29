using System;

namespace Projeto1
{
    class Exec
    {
        static void Main(string[] args)
        {
            Console.WriteLine($"Oque deseja fazer ? \n 1 - Fazer o alfabeto   2 - Caminho de volta");
            var op = Console.ReadLine();

            if (Convert.ToInt32(op) == 1)
            {
                var alphabet = new Alphabet();
                alphabet.AlphabetGo();
            }
            else if (Convert.ToInt32(op) == 2)
            {
                var rollBack = new RollBack();
                rollBack.StepByStep();
            }
            Console.WriteLine("Programa finalizado");
            Console.ReadLine();
        }
    }
}