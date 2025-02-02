using System;
using TheMaze;
using Cells;
using GameManager;

namespace GameNamespace
{
    class Program
    {
        static void Main(string[] args)
        {
            // Inicializar el generador de laberintos
            MazeGenerator mazeGenerator = new MazeGenerator(10);
            char[,] maze = mazeGenerator.GenerateMaze();
            mazeGenerator.PrintMaze();

            // Inicializar las celdas a partir del laberinto generado
            Cells.Cells cells = new Cells.Cells(maze);

            // Inicializar el GameManager
            GameManager.GameManager gameManager = new GameManager.GameManager(cells);
            gameManager.IniciarJuego();
        }
    }
}