namespace GameManager;

    private Maze maze;
    private Player[] players;
    public GameManager()
    {

        players = new Player[2]
        {
            new Player("Jugador 1", 0, 0),
            new Player("Jugador 2", 0, 0)
        };
    }