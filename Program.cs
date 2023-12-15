using GameControllerLib;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Xml;
class Program
{
	public static bool x = false;
	static void Main()
	{
		GameController game = new("bagPiece.txt");

		Player player1 = new(1, "dee");
		Player player2 = new(2, "lee");
		Player player3 = new(3, "bee");
		Player player4 = new(4, "zee");

		game.AddPlayer(player1, player2, player3, player4);

		// game.Move(game.PlayerTurn().id);

		foreach (var data in game.GetPlayerPiece())
		{
			Console.Write("Player " + data.Key.id + ", Pieces :");
			foreach (var x in data.Value)
			{
				Console.Write(x.pieceLetter);
			}
			Console.WriteLine(" ");
		}

		//PIECES DI BAG
		Console.Write($"{game.GetPieceOfBag().Count} pieces on bag : ");
		foreach (var xx in game.GetPieceOfBag())
		{
			Console.Write(xx.Value + ",");
		}
		Console.WriteLine("");
		Console.WriteLine("");

		// // BOARD
		// foreach (var x in game.GetBoard())
		// {
		// 	if (x.boardStatus.ToString() == "Filled" && x.boardY == 15)
		// 	{
		// 		Console.ForegroundColor = ConsoleColor.White;
		// 		Console.WriteLine("[{0} ] ", x.letter);
		// 		Console.ResetColor();
		// 	}
		// 	else if (x.boardStatus.ToString() == "Filled" && x.boardY != 15)
		// 	{
		// 		Console.ForegroundColor = ConsoleColor.White;
		// 		Console.Write("[{0} ] ", x.letter);
		// 		Console.ResetColor();
		// 	}
		// 	else if (x.boardStatus.ToString() == "DL" && x.boardY == 15)
		// 	{
		// 		Console.ForegroundColor = ConsoleColor.Cyan;
		// 		Console.WriteLine("[DL] ");
		// 		Console.ResetColor();
		// 	}
		// 	else if (x.boardStatus.ToString() == "TW" && x.boardY == 15)
		// 	{
		// 		Console.ForegroundColor = ConsoleColor.Red;
		// 		Console.WriteLine("[TW] ");
		// 		Console.ResetColor();
		// 	}
		// 	else if (x.boardY == 15)
		// 	{
		// 		Console.ForegroundColor = ConsoleColor.White;
		// 		Console.WriteLine("[  ] ");
		// 		Console.ResetColor();
		// 	}
		// 	else if (x.boardStatus.ToString() == "DL")
		// 	{
		// 		Console.ForegroundColor = ConsoleColor.Cyan;
		// 		Console.Write("[DL] ");
		// 		Console.ResetColor();
		// 	}
		// 	else if (x.boardStatus.ToString() == "TL")
		// 	{
		// 		Console.ForegroundColor = ConsoleColor.Blue;
		// 		Console.Write("[TL] ");
		// 		Console.ResetColor();
		// 	}
		// 	else if (x.boardStatus.ToString() == "DW")
		// 	{
		// 		Console.ForegroundColor = ConsoleColor.Magenta;
		// 		Console.Write("[DW] ");
		// 		Console.ResetColor();
		// 	}
		// 	else if (x.boardStatus.ToString() == "TW")
		// 	{
		// 		Console.ForegroundColor = ConsoleColor.Red;
		// 		Console.Write("[TW] ");
		// 		Console.ResetColor();
		// 	}
		// 	else if (x.boardStatus.ToString() == "Start")
		// 	{
		// 		Console.ForegroundColor = ConsoleColor.Magenta;
		// 		Console.Write("[XX] ");
		// 		Console.ResetColor();
		// 	}
		// 	else if (x.boardStatus.ToString() == "Empty")
		// 	{
		// 		Console.Write("[  ] ");
		// 	}

		// }
		game.ViewBoard();

		int choose = 0;
		foreach (var x in game.AvailablePiece())
		{
			Console.WriteLine($"choose number :{choose}, {x.pieceLetter}");
			choose++;
		}
		Console.WriteLine($"choose number :7, END TURN");
		string? selectedPiece = Console.ReadLine();
		int index = int.Parse(selectedPiece);
		if (index == 7)
		{
			
		}
		else if (index >= 0 && index < 7)
		{
			game.ChoosePiece(game.AvailablePiece()[index].pieceLetter);

			game.ViewBoard();
			Console.WriteLine("move pertama sudah di jalankan");
			Console.ReadLine();
		}




		// foreach (var x in game.GetDictionaries())
		// {
		// 	Console.WriteLine(x.GetName());
		// }

		// Console.WriteLine(game.AvailablePiece()[0].pieceLetter);
		// foreach (var x in game.AvailablePiece())
		// {
		// 	Console.Write(x.pieceLetter);
		// }
		// game.ChoosePiece(game.AvailablePiece()[0].pieceLetter);

		// foreach (var x in game.GetBoard())
		// {
		// 	Console.WriteLine($"{x.boardX},{x.boardY},{x.letter},{x.boardStatus}");
		// }







		// game.GetPlayerList();
		// game.PlayerTurn();
		// game.SwitchPLayer();
		// game.SwitchPLayer();
		// game.SwitchPLayer();
		// game.SwitchPlayer();
		// game.CreateBoard(15);

		//GET SCORE
		// string word = "hello";
		// int result = game.GetScore(word);
		// Console.WriteLine("word " + word + ",skor : " + result);

		// game.GetPieceOfBag();
		// game.GetRandom();
		// game.GetPieceOfBag();
		// game.GetBoard();
	}
}