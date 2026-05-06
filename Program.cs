namespace word_guessing_game;
using word_guessing_game.Services;

public static class Program
{
	public static void Main()
	{
		Game game = new Game();
		game.StartGame();
	}
}