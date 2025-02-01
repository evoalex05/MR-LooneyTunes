using System;
namespace Game.Trampa{
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
}
