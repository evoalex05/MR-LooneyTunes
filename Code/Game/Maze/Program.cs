using System;

public class MazeGenerator
{
    private int size;
    private char[,] maze;
    private Random random = new Random();

    public MazeGenerator(int size)
    {
        this.size = size < 3 ? 3 : size;
        maze = new char[this.size + 2, this.size + 2]; // +2 para el borde de paredes

        // Inicializa el laberinto con paredes
        for (int i = 0; i < maze.GetLength(0); i++)
        {
            for (int j = 0; j < maze.GetLength(1); j++)
            {
                maze[i, j] = '█'; // Paredes (bloque sólido)
            }
        }
    }

    public char[,] GenerateMaze()
    {
        // Comienza el backtracking desde una celda aleatoria dentro del laberinto
        int startX = random.Next(1, size + 1);
        int startY = random.Next(1, size + 1);
        CarvePassages(startX, startY);
        return maze;
    }

    private void CarvePassages(int x, int y)
    {
        // Direcciones posibles: (dx, dy)
        var directions = new (int, int)[]
        {
            (2, 0), (-2, 0), (0, 2), (0, -2)
        };

        // Mezcla las direcciones para aleatoriedad
        Shuffle(directions);
        foreach (var (dx, dy) in directions)
        {
            int nx = x + dx;
            int ny = y + dy;
            
            // Verifica si la nueva posición está dentro de los límites
            
            if (nx > 0 && nx <= size && ny > 0 && ny <= size && maze[ny, nx] == '█')
            {
                // Crea un camino entre la celda actual y la nueva celda
                maze[y, x] = ' '; // Espacio vacío
                maze[ny, nx] = ' '; 
                maze[y + dy / 2, x + dx / 2] = ' '; // Elimina la pared entre las dos celdas
                CarvePassages(nx, ny); // Llama recursivamente
            }
        }
    }
    private void Shuffle((int, int)[] array)
    {
        for (int i = array.Length - 1; i > 0; i--)
        {
            int j = random.Next(0, i + 1);
            (array[i], array[j]) = (array[j], array[i]); // Intercambia
        }
    }
    public void PrintMaze()
    {
        for (int i = 0; i < maze.GetLength(0); i++)
        {
            for (int j = 0; j < maze.GetLength(1); j++)
            {
                Console.Write(maze[i, j]);
            }
            Console.WriteLine();
        }
    }
}
