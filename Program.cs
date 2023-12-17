using GameControllerLib;
class Program
{

	public static bool firstMove = false;
	static void Main()
	{
		GameController game = new("bagPiece.txt", 15);

		Player player1 = new(1, "dee");
		Player player2 = new(2, "lee");
		Player player3 = new(3, "bee");
		Player player4 = new(4, "zee");

		game.AddPlayer(player1, player2, player3, player4);

		game.SetBoardBonus(8, 8, "Start", 0);
		game.SetBoardBonus(1, 1, "TripleWord", 3);
		game.SetBoardBonus(1, 8, "TripleWord", 3);
		game.SetBoardBonus(1, 15, "TripleWord", 3);
		game.SetBoardBonus(8, 1, "TripleWord", 3);
		game.SetBoardBonus(8, 15, "TripleWord", 3);
		game.SetBoardBonus(15, 1, "TripleWord", 3);
		game.SetBoardBonus(15, 8, "TripleWord", 3);
		game.SetBoardBonus(15, 15, "TripleWord", 3);

		game.SetBoardBonus(2, 2, "DoubleWord", 2);
		game.SetBoardBonus(2, 14, "DoubleWord", 2);
		game.SetBoardBonus(14, 2, "DoubleWord", 2);
		game.SetBoardBonus(14, 14, "DoubleWord", 2);
		game.SetBoardBonus(3, 3, "DoubleWord", 2);
		game.SetBoardBonus(3, 13, "DoubleWord", 2);
		game.SetBoardBonus(13, 3, "DoubleWord", 2);
		game.SetBoardBonus(13, 13, "DoubleWord", 2);
		game.SetBoardBonus(4, 4, "DoubleWord", 2);
		game.SetBoardBonus(4, 12, "DoubleWord", 2);
		game.SetBoardBonus(12, 4, "DoubleWord", 2);
		game.SetBoardBonus(12, 12, "DoubleWord", 2);
		game.SetBoardBonus(5, 5, "DoubleWord", 2);
		game.SetBoardBonus(11, 5, "DoubleWord", 2);
		game.SetBoardBonus(5, 11, "DoubleWord", 2);
		game.SetBoardBonus(11, 11, "DoubleWord", 2);

		game.SetBoardBonus(2, 6, "TripleLetter", 2);
		game.SetBoardBonus(2, 10, "TripleLetter", 2);
		game.SetBoardBonus(6, 2, "TripleLetter", 2);
		game.SetBoardBonus(6, 6, "TripleLetter", 2);
		game.SetBoardBonus(6, 10, "TripleLetter", 2);
		game.SetBoardBonus(6, 14, "TripleLetter", 2);
		game.SetBoardBonus(10, 2, "TripleLetter", 2);
		game.SetBoardBonus(10, 6, "TripleLetter", 2);
		game.SetBoardBonus(10, 10, "TripleLetter", 2);
		game.SetBoardBonus(10, 14, "TripleLetter", 2);
		game.SetBoardBonus(14, 6, "TripleLetter", 2);
		game.SetBoardBonus(14, 10, "TripleLetter", 2);

		game.SetBoardBonus(1, 4, "DoubleLetter", 2);
		game.SetBoardBonus(1, 12, "DoubleLetter", 2);
		game.SetBoardBonus(4, 1, "DoubleLetter", 2);
		game.SetBoardBonus(12, 1, "DoubleLetter", 2);
		game.SetBoardBonus(15, 4, "DoubleLetter", 2);
		game.SetBoardBonus(15, 12, "DoubleLetter", 2);
		game.SetBoardBonus(4, 15, "DoubleLetter", 2);
		game.SetBoardBonus(12, 15, "DoubleLetter", 2);
		game.SetBoardBonus(3, 7, "DoubleLetter", 2);
		game.SetBoardBonus(3, 9, "DoubleLetter", 2);
		game.SetBoardBonus(13, 7, "DoubleLetter", 2);
		game.SetBoardBonus(13, 9, "DoubleLetter", 2);
		game.SetBoardBonus(7, 3, "DoubleLetter", 2);
		game.SetBoardBonus(7, 7, "DoubleLetter", 2);
		game.SetBoardBonus(7, 9, "DoubleLetter", 2);
		game.SetBoardBonus(9, 7, "DoubleLetter", 2);
		game.SetBoardBonus(9, 9, "DoubleLetter", 2);
		game.SetBoardBonus(9, 3, "DoubleLetter", 2);
		game.SetBoardBonus(7, 13, "DoubleLetter", 2);
		game.SetBoardBonus(9, 13, "DoubleLetter", 2);
		game.SetBoardBonus(9, 13, "DoubleLetter", 2);
		game.SetBoardBonus(4, 8, "DoubleLetter", 2);
		game.SetBoardBonus(8, 4, "DoubleLetter", 2);
		game.SetBoardBonus(8, 12, "DoubleLetter", 2);
		game.SetBoardBonus(12, 8, "DoubleLetter", 2);

		game.SetScore("A", 1);
		game.SetScore("E", 1);
		game.SetScore("I", 1);
		game.SetScore("O", 1);
		game.SetScore("U", 1);
		game.SetScore("L", 1);
		game.SetScore("N", 1);
		game.SetScore("R", 1);
		game.SetScore("S", 1);
		game.SetScore("T", 1);
		game.SetScore("D", 2);
		game.SetScore("G", 2);
		game.SetScore("B", 3);
		game.SetScore("C", 3);
		game.SetScore("M", 3);
		game.SetScore("P", 3);
		game.SetScore("F", 4);
		game.SetScore("H", 4);
		game.SetScore("V", 4);
		game.SetScore("W", 4);
		game.SetScore("Y", 4);
		game.SetScore("K", 5);
		game.SetScore("J", 8);
		game.SetScore("X", 8);
		game.SetScore("Q", 10);
		game.SetScore("Z", 10);
		game.SetScore(" ", 0);

		game.getPiece().ToList().ForEach(data => Console.Write($"[{data.pieceID},{data.pieceLetter},{data.pieceSkor}]"));

		game.GetPlayerList().ToList().ForEach(data => Console.WriteLine($"Player {data.id} : {data.name}, skor {data.skor}"));
		Console.WriteLine("");

		// string data = game.GetPlayer(0).ToString();
		// Console.WriteLine(data);

		Console.Write($"Pieces on bag {game.GetPieceOfBag().Count} : ");
		game.GetPieceOfBag().ToList().ForEach(data => Console.Write($"[{data.Key},{data.Value}]"));
		Console.WriteLine("");
		Console.WriteLine("");

		Console.Write($"Player pieces : ");
		game.GetPlayerPiece().ToList().ForEach(data => data.Value.ToList().ForEach(x => Console.Write($"[{data.Key.id},{x.pieceLetter},{x.pieceID}]")));
		Console.WriteLine("");
		Console.WriteLine("");

		while (game.StopTurn() == false)
		{
			game.ViewBoard();


			Console.Write("Available piece : ");
			game.AvailablePiece().ToList().ForEach(data => Console.Write($" {data.pieceLetter} "));
			Console.WriteLine();

			Console.WriteLine($"Turn : Player {game.PlayerTurn()}");

			game.AvailablePiece().ToList().ForEach(x => Console.WriteLine($"Letter {x.pieceLetter} (input {x.pieceID})"));
			Console.WriteLine($"Stop turn (input 200)");

			Console.Write($"Your input : ");
			int letter = int.Parse(Console.ReadLine());
			Console.WriteLine();

			game.GetInputLetter(letter);

			game.GetTemporaryWord().ToList().ForEach(x => Console.WriteLine($"letter {x.Value} set on [{x.Key.boardX},{x.Key.boardY}]"));
			game.GetScore();

			// game.GetBoard().ToList().ForEach(data => Console.WriteLine($"[{data.boardX},{data.boardY},{data.letter},{data.bonusBoard},{data.boardStatus}]"));

			game.GetPlayerList().ToList().ForEach(data => Console.WriteLine($"Player {data.id} : {data.name}, skor {data.skor}"));
			Console.WriteLine("");




		}

		// CHECK LIST OF _boardTile
		// game.GetBoard().ToList().ForEach(data => Console.WriteLine($"[{data.boardX},{data.boardY},{data.letter},{data.bonusBoard},{data.boardStatus}]"));

	}
}