using System;

namespace GameOfLife
{
    class Program
    {
        static void Main(string[] args)
        {
            // Simple Pattern
            Game myLifeGame = new Game(4, 4);
            myLifeGame.FlipGridCell(1, 1);
            myLifeGame.FlipGridCell(1, 2);
            myLifeGame.FlipGridCell(2, 1);
            myLifeGame.FlipGridCell(2, 2);
            myLifeGame.FlipGridCell(2, 3);
            myLifeGame.FlipGridCell(3, 3);
            myLifeGame.MaxGenerations = 4;
            myLifeGame.Init();


            // The Period 3 Oscillator pattern
            //Game myLifeGame = new Game(5, 3);
            //myLifeGame.ToggleGridCell(0, 1);
            //myLifeGame.ToggleGridCell(1, 0);
            //myLifeGame.ToggleGridCell(1, 1);
            //myLifeGame.ToggleGridCell(1, 2);
            //myLifeGame.ToggleGridCell(2, 0);
            //myLifeGame.ToggleGridCell(2, 2);
            //myLifeGame.ToggleGridCell(3, 0);
            //myLifeGame.ToggleGridCell(3, 1);
            //myLifeGame.ToggleGridCell(3, 2);
            //myLifeGame.ToggleGridCell(4, 1);
            //myLifeGame.MaxGenerations = 50;
            //myLifeGame.Init();

            Console.ReadKey();            
        }
    }
}
