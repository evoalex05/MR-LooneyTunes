using System;
using System.Collections.Generic;
namespace 
public class Personaje
{
    public string Nombre { get; private set; }
    public int Velocidad { get; private set; } // Cantidad de casillas que puede moverse por turno
    private int tiempoEnfriamiento; // Tiempo de enfriamiento de la habilidad
    private int tiempoEnfriamientoActual; // Tiempo de enfriamiento actual
    private string habilidadActual; // Habilidad activa
    private bool congelado; // Indica si el jugador está congelado

    private int turnosCongelado; // Contador de turnos congelado
    public (int PosX, int PosY) PosicionActual { get; private set; } // Posición actual del jugador

    public (int PosX, int PosY) PosicionInicio { get; private set; } // Posición de inicio del jugador

    public Personaje(string nombre, int velocidad, string habilidad,(int, int)posicionInicio)
    {
        Nombre = nombre;
        Velocidad = velocidad;
        tiempoEnfriamientoActual = 0;

        if (habilidad == "Disparo" || habilidad == "DimensionBolsillo")
        {
            habilidadActual = habilidad;
        }
        else
        {
            throw new ArgumentException("Habilidad no válida. Debe ser 'Disparo' o 'DimensionBolsillo'.");
        }
        PosicionInicio = posicionInicio; // Establece la posición de inicio

        PosicionActual = posicionInicio; // Inicialmente, la posición actual es la de inicio

    }

    public void UsarHabilidad(Personaje objetivo)
    {
        if (tiempoEnfriamientoActual > 0)
        {
            Console.WriteLine($"{Nombre} no puede usar la habilidad '{habilidadActual}' porque está en enfriamiento ({tiempoEnfriamientoActual} turnos restantes).");
            return;
        }

        switch (habilidadActual)
        {
            case "Disparo":
                Disparo(objetivo);
                break;
            case "DimensionBolsillo":
                DimensionBolsillo();
                break;
        }

        tiempoEnfriamientoActual = ObtenerTiempoEnfriamiento(habilidadActual);
    }

    private void Disparo(Personaje objetivo)
    {
        // Suponiendo que el objetivo está a una casilla de distancia
        Console.WriteLine($"{Nombre} usa 'Disparo' en {objetivo.Nombre}. {objetivo.Nombre} vuelve al inicio.");
        
    }

    private void DimensionBolsillo()
    {
        Console.WriteLine($"{Nombre} usa 'DimensionBolsillo' y coloca una trampa en una casilla adyacente.");
    }

    public void FinTurno()
    {
        if (tiempoEnfriamientoActual > 0)
        {
            tiempoEnfriamientoActual--;
        }
        
        if (congelado)
        {
            turnosCongelado--;
            if (turnosCongelado <= 0)
            {
                congelado = false;
                Console.WriteLine($"{Nombre} ya no está congelado y puede moverse nuevamente.");
            }
        }
    }
    public void Congelar(int turnos)
    {
        congelado = true;
        turnosCongelado = turnos;
        Console.WriteLine($"{Nombre} está congelado y no puede moverse por {turnos} turno(s).");
    }

    private int ObtenerTiempoEnfriamiento(string habilidad)
    {
        switch (habilidad)
        {
            case "Disparo":
                return 7; // Tiempo de enfriamiento para Disparo
            case "DimensionBolsillo":
                return 3; // Puedes definir un tiempo de enfriamiento para DimensionBolsillo
            default:
                return 0;
        }
    }

    public void VolverAlInicio()
    {
        PosicionActual = PosicionInicio; // Regresa a la posición de inicio
        Console.WriteLine($"{Nombre} ha vuelto a la posición de inicio en ({PosicionInicio.PosX}, {PosicionInicio.PosY}).");
    }
    public void ImprimirEstado()
    {
        Console.WriteLine($"Personaje: {Nombre}, Velocidad: {Velocidad}, Habilidad: {habilidadActual}, Enfriamiento: {tiempoEnfriamientoActual}");
    }
    public void ReducirVelocidad(int cantidad)
    {
        Velocidad -= cantidad;
        if (Velocidad < 0) Velocidad = 0; // Asegúrando que la velocidad no sea negativa
        Console.WriteLine($"{Nombre} ahora tiene una velocidad de {Velocidad}.");
    }

    public bool PuedeMoverse()
    {
        return !congelado;
    }

}

public class FichaJugable
{
    private List<Personaje> personajes;

    public FichaJugable()
    {
        personajes = new List<Personaje>
        {
            //cambiar 0,0 por la posicion de inicio generada
            new Personaje("Bugs Bunny", 4, "DimensionBolsillo",(0,0)),
            new Personaje("Speedy Gonzales", 8, "DimensionBolsillo",(0,0)),
            new Personaje("Marciano", 3, "Disparo",(0,0)),
            new Personaje("Cabeza de Huevo Jr", 2, "DimensionBolsillo",(0,0)),
            new Personaje("Gallo Claudio", 3, "Disparo",(0,0)),
            new Personaje("Pato Lucas", 4, "DimensionBolsillo",(0,0))
        };
    }

    public void ImprimirPersonajes()
    {
        Console.WriteLine("Personajes disponibles:");
        foreach (var personaje in personajes)
        {
            personaje.ImprimirEstado();
        }
    }
}
