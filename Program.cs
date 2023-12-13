using GameControllerLib;
class Program
{
	static void Main()
	{
		GameController game = new("bagPiece.txt",15);
		Player player1 = new(1, "dee");
		Player player2 = new(2, "lee");
		Player player3 = new(3, "bee");
		Player player4 = new(4, "zee");


		game.AddPlayer(player1, player2, player3, player4);
		game.GetPlayerList();
		game.PlayerTurn();
		// game.SwitchPLayer();
		// game.SwitchPLayer();
		// game.SwitchPLayer();
		game.SwitchPlayer();
		// game.CreateBoard(15);
		
		//GET SCORE
		// string word = "hello";
		// int result = game.GetScore(word);
		// Console.WriteLine("word " + word + ",skor : " + result);
		
		// game.GetPieceOfBag();
		// game.GetRandom();
		// game.GetPieceOfBag();
	}
}