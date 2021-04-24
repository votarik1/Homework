using System;
using Greeting;

namespace Lesson8
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Как тебя зовут?");
            string name = Console.ReadLine();
            Hello.GreedOfficial(name);
            Hello.GreedNonofficial(name);
        }
    }
}
