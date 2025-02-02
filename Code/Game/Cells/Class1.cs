using System;
namespace Cells;
public class Cell
{
    public bool IsWall { get; private set; } // Indica si la celda es una pared
    public bool IsVisited { get; set; } // Indica si la celda ha sido visitada
    public (int X, int Y) Position { get; private set; } // Posición de la celda

    public Cell(bool isWall, (int X, int Y) position)
    {
        IsWall = isWall;
        IsVisited = false;
        Position = position;
    }
}

public class Cells
{
    private Cell[,] cells;

    public Cells(char[,] maze)
    {
        int height = maze.GetLength(0);
        int width = maze.GetLength(1);
        cells = new Cell[height, width];

        for (int i = 0; i < height; i++)
        {
            for (int j = 0; j < width; j++)
            {
                bool isWall = maze[i, j] == '█'; // Si es una pared
                cells[i, j] = new Cell(isWall, (j, i)); // Crear la celda
            }
        }
    }

    public Cell GetCell(int x, int y)
    {
        if (x < 0 || x >= cells.GetLength(1) || y < 0 || y >= cells.GetLength(0))
        {
            throw new ArgumentOutOfRangeException("Las coordenadas están fuera de los límites del laberinto.");
        }
        return cells[y, x];
    }

    public void PrintCells()
    {
        for (int i = 0; i < cells.GetLength(0); i++)
        {
            for (int j = 0; j < cells.GetLength(1); j++)
            {
                Console.Write(cells[i, j].IsWall ? '█' : ' '); // Imprimir pared o espacio vacío
            }
            Console.WriteLine();
        }
    }
}
