using System;
using Character;
using TheMaze;
namespace Trap;

public class Trampa
{
    public string Nombre { get; private set; }
    public int PosX { get; private set; }
    public int PosY { get; private set; }
    public bool IsActive { get; private set; } // Indica si la trampa está activa

    public Trampa(string nombre, int x, int y)
    {
        Nombre = nombre;
        PosX = x;
        PosY = y;
        IsActive = true; // La trampa está activa al ser creada
    }

    public void Activar(Personaje jugador)
    {
        if (IsActive)
        {
            Console.WriteLine($"¡{jugador.Nombre} ha caído en la trampa '{Nombre}' en ({PosX}, {PosY})!");

            switch (Nombre)
            {
                case "Congelamiento":
                    Congelamiento(jugador);
                    break;
                case "Bomba":
                    Bomba(jugador);
                    break;
                case "Paso Lento":
                    PasoLento(jugador);
                    break;
                default:
                    Console.WriteLine("Trampa desconocida.");
                    break;
            }

            IsActive = false; // Desactiva la trampa después de activarse
        }
        else
        {
            Console.WriteLine($"La trampa '{Nombre}' ya ha sido activada.");
        }
    }
    private void Congelamiento(Personaje jugador)
    {
        Console.WriteLine($"{jugador.Nombre} está congelado y no puede moverse en esta ronda.");
        jugador.Congelar(1); // Congela al jugador por 1 turno
    }

    private void Bomba(Personaje jugador)
    {
        Console.WriteLine($"{jugador.Nombre} ha caído en una bomba y regresa al inicio.");
        jugador.VolverAlInicio(); // Mueve al jugador a la posición de inicio            
    }

    private void PasoLento(Personaje jugador)
    {
        Console.WriteLine($"{jugador.Nombre} ha caído en una trampa de 'Paso Lento'. Su velocidad se reduce en 1.");
        jugador.ReducirVelocidad(1);
    }
    
}
public class Obstaculo
{
    private static Random random = new Random();
    public int PosX { get; private set; }
    public int PosY { get; private set; }
    public bool IsActive { get; private set; } // Indica si el obstáculo está activo
    public Obstaculo(int x, int y)
    {
        PosX = x;
        PosY = y;
        IsActive = true; // El obstáculo está activo al ser creado
    }

        public static char[,] AgregarObstaculos(MazeGenerator laberinto, int cantidadObstaculos)
        {

            char[,] maze = laberinto.GetMaze(); // Obtener la matriz del laberinto
            int filas = maze.GetLength(0);
            int columnas = maze.GetLength(1);
            int obstaculosAgregados = 0;

            while (obstaculosAgregados < cantidadObstaculos)
            {
                int x = random.Next(1, columnas - 1); // Evitar bordes
                int y = random.Next(1, filas - 1); // Evitar bordes

                // Verifica si la posición está vacía
                if (maze[x, y] == ' ')
                {
                    maze[x, y] = 'O'; // Coloca un obstáculo
                    obstaculosAgregados++;
                }
            }
            return maze;
        }
    /*
    public static MazeGenerator[,] AgregarObstaculos(MazeGenerator[,] laberinto1, int cantidadObstaculos)
    {
        int filas = laberinto1.GetLength(0);
        int columnas = laberinto1.GetLength(1);
        int obstaculosAgregados = 0;

        while (obstaculosAgregados < cantidadObstaculos)
        {
            int x = random.Next(1, columnas - 1); // Evitar bordes
            int y = random.Next(1, filas - 1); // Evitar bordes

            // Verifica si la posición está vacía
            if (laberinto1[y, x] == ' ')
            {
                laberinto1[y, x = 'X'; // Coloca un obstáculo
                obstaculosAgregados++;
            }
        }
        return laberinto1;
    }
    */
    
    public void Interactuar()
    {
        if (IsActive)
        {
            Console.WriteLine($"¡Interacción con el obstáculo en ({PosX}, {PosY})! Desaparecerá en 1 turno.");
            IsActive = false; // Desactiva el obstáculo
        }
        else
        {
            Console.WriteLine("El obstáculo ya ha desaparecido.");
        }
    }

    public void ImprimirEstado()
    {
        if (IsActive)
        {
            Console.WriteLine($"Obstáculo activo en ({PosX}, {PosY}).");
        }
        else
        {
            Console.WriteLine($"Obstáculo en ({PosX}, {PosY}) ha desaparecido.");
        }
    }
}


