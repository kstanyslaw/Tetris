using System;

namespace Tetris
{
    class Program
    {
        static void Main(string[] args)
        {
            Game.CreatePlayground();
            Game.Play();
            Console.Read();
        }
    }
}
