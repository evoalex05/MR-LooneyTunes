using System;

public class Obstaculo
{
    public int PosX { get; private set; }
    public int PosY { get; private set; }
    public bool IsActive { get; private set; } // Indica si el obstáculo está activo

    public Obstaculo(int x, int y)
    {
        PosX = x;
        PosY = y;
        IsActive = true; // El obstáculo está activo al ser creado
    }

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


