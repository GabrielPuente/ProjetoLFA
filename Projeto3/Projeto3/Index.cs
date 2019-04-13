using System;

namespace AFNToAFD
{
    class Index
    {
        static void Main(string[] args)
        {
            while (true)
            {
                var convert = new ConvertTo();

                convert.StartConvert();

                Console.Write("\nAperte qualquer letra para recomeçar.");
                Console.ReadKey();
                Console.Clear();
            }
        }
    }
}
