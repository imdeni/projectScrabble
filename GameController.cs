namespace GameControllerLib;
using System.Runtime.Serialization.Json;
using System.Text;
public class GameController
{

	#region GAMECONTROLLER
	private List<IPlayer> _players = new();
	private List<IPiece> _piece = new();
	private List<IBoard> _boardTile = new();
	private Dictionary<IBoard,string> _temporaryWord = new();
	private Dictionary<int, string> _pieceBag = new();
	private Dictionary<IPlayer, List<IPiece>> _playersPiece = new();
	private Random rand = new Random();
	int countTurn = 0;
	bool firstMove = false;
	public int sizeBoard = 15;
	public GameController(string filename)
	{
		CreateBoard(sizeBoard);
		CreatePieceOfBag(filename);
	}
	#endregion GAMECONTROLLER

	#region PLAYER
	public bool AddPlayer(params IPlayer[] players)
	{
		foreach (var i in players)
		{
			_players.Add(i);
			GeneratePieceOnStart(i);
		}
		return true;
	}


	public IPlayer GetPlayer(int index)
	{
		return _players[index];
	}
	public List<IPlayer> GetPlayerList()
	{
		return _players;
	}

	#endregion PLAYER

	#region CREATEBOARD
	public bool CreateBoard(int board)
	{
		for (int i = 1; i <= board; i++)
		{
			for (int j = 1; j <= board; j++)
			{
				Board boardTile = new Board(i, j);
				_boardTile.Add(boardTile);
			}
		}
		CreateBonus();
		return true;
	}
	public bool CreateBonus()
	{
		foreach (var x in _boardTile)
		{
			if (x.boardX == 8 && x.boardY == 8)
			{
				x.boardStatus = BoardStatus.Start;
			}
			else if ((x.boardX == 1 || x.boardX == 8 || x.boardX == 15) && (x.boardY == 1 || x.boardY == 8 || x.boardY == 15))
			{
				x.boardStatus = BoardStatus.TW;
			}
			else if ((x.boardX == 2 || x.boardX == 14) && (x.boardY == 2 || x.boardY == 14)
					|| (x.boardX == 3 || x.boardX == 13) && (x.boardY == 3 || x.boardY == 13)
					|| (x.boardX == 4 || x.boardX == 12) && (x.boardY == 4 || x.boardY == 12)
					|| (x.boardX == 5 || x.boardX == 11) && (x.boardY == 5 || x.boardY == 11))
			{
				x.boardStatus = BoardStatus.DW;
			}
			else if ((x.boardX == 2 || x.boardX == 6 || x.boardX == 10 || x.boardX == 14) && (x.boardY == 2 || x.boardY == 6 || x.boardY == 10 || x.boardY == 14))
			{
				x.boardStatus = BoardStatus.TL;
			}
			else if ((x.boardX == 1 || x.boardX == 4 || x.boardX == 12 || x.boardX == 15) && (x.boardY == 1 || x.boardY == 4 || x.boardY == 12 || x.boardY == 15)
					|| (x.boardX == 3 || x.boardX == 7 || x.boardX == 9 || x.boardX == 13) && (x.boardY == 3 || x.boardY == 7 || x.boardY == 9 || x.boardY == 13)
					|| (x.boardX == 4 || x.boardX == 8 || x.boardX == 12) && (x.boardY == 4 || x.boardY == 8 || x.boardY == 12)
					)
			{
				x.boardStatus = BoardStatus.DL;
			}
		}
		return true;
	}
	public List<IBoard> GetBoard()
	{
		return _boardTile;
	}

	#endregion CREATEBOARD

	#region TURN
	public int PlayerTurn()
	{
		return _players[countTurn].id;
	}

	public bool SwitchPlayer()
	{
		if (countTurn == _players.Count - 1)
		{
			countTurn = 0;
		}
		else
		{
			countTurn++;
		}
		return true;
	}
	#endregion TURN

	#region GETSCORE
	public int GetScore(string word)
	{
		word = word.ToLower();
		int score = 0;
		for (int i = 0; i < word.Length; i++)
		{
			if (word[i] == 'a' || word[i] == 'e' || word[i] == 'i' || word[i] == 'o' || word[i] == 'u' || word[i] == 'l' || word[i] == 'n' || word[i] == 'r' || word[i] == 's' || word[i] == 't')
			{
				score++;
			}
			else if (word[i] == 'd' || word[i] == 'g')
			{
				score += 2;
			}
			else if (word[i] == 'b' || word[i] == 'c' || word[i] == 'm' || word[i] == 'p')
			{
				score += 3;
			}
			else if (word[i] == 'f' || word[i] == 'h' || word[i] == 'v' || word[i] == 'w' || word[i] == 'y')
			{
				score += 4;
			}
			else if (word[i] == 'k')
			{
				score += 5;
			}
			else if (word[i] == 'j' || word[i] == 'x')
			{
				score += 8;
			}
			else if (word[i] == 'q' || word[i] == 'z')
			{
				score += 10;
			}
			else
			{
				score = 0;
				break;
			}
		}
		return score;
	}
	#endregion GETSCORE

	public Dictionary<int, string> CreatePieceOfBag(string filename)
	{
		int counter = 0;

		using (StreamReader reader = new StreamReader(filename))
		{
			string? line = string.Empty;
			while ((line = reader.ReadLine()) != null)
			{
				if (line != string.Empty)
				{
					string[] inputSplited = line.Split(',');

					foreach (string str in inputSplited)
					{
						_pieceBag.Add(counter, str);
						counter++;
					}
				}
			}
		}
		return _pieceBag;
	}
	public Dictionary<int, string> GetPieceOfBag()
	{
		return _pieceBag;
	}
	public bool GetRandom()
	{
		List<int> keyList = new List<int>(_pieceBag.Keys);
		int randomKey = keyList[rand.Next(keyList.Count)];
		Console.WriteLine(_pieceBag[randomKey] + "," + randomKey);
		_pieceBag.Remove(randomKey);
		return true;
	}
	public bool GeneratePieceOnStart(IPlayer player)
	{
		for (int ii = 0; ii < 7; ii++)
		{
			List<int> keyList = new List<int>(_pieceBag.Keys);
			int randomKey = keyList[rand.Next(keyList.Count)];

			Piece piece = new Piece(randomKey, _pieceBag[randomKey]);
			_piece.Add(piece);
			_pieceBag.Remove(randomKey);
		}
		_playersPiece.Add(player, new List<IPiece>(_piece));
		_piece.RemoveRange(0, _piece.Count());
		return true;
	}

	public Dictionary<IPlayer, List<IPiece>> GetPlayerPiece()
	{
		return _playersPiece;
	}

	public List<Dictionaries> GetDictionaries()
	{
		DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(List<Dictionaries>));
		List<Dictionaries> importDictionaries;
		using (FileStream stream2 = new FileStream("Dictionaries.json", FileMode.Open))
		{
			importDictionaries = (List<Dictionaries>)ser.ReadObject(stream2);
		}
		return importDictionaries;
	}

	// public bool Move(int player)
	// {
	// 	if (firstMove == false)
	// 	{

	// 		firstMove = true;
	// 	}
	// 	return true;
	// }

	public List<IPiece> AvailablePiece()
	{
		foreach (var data in GetPlayerPiece())
		{
			if (data.Key.id == PlayerTurn())
			{
				return data.Value;
			}
		}
		return null;
	}
	public void ChoosePiece(string letter)
	{
		if (firstMove == false)
		{
			foreach (var x in _boardTile)
			{
				if (x.boardX == 8 && x.boardY == 8)
				{
					Board b = new Board(8, 8);
					_temporaryWord.Add(b,letter);
					// foreach(var a in _temporaryWord)
					// {
					// 	Console.WriteLine(a.Value+" "+ a.Key.boardX+" "+a.Key.boardY);
					// }
					x.letter = letter;
					x.boardStatus = BoardStatus.Filled;
				}
			}
			firstMove = true;
		}else
		{
			
		}

	}
	
	public void ViewBoard()
	{
		// BOARD
			foreach (var x in GetBoard())
			{
				if (x.boardStatus.ToString() == "Filled" && x.boardY == 15)
				{
					Console.ForegroundColor = ConsoleColor.White;
					Console.WriteLine("[{0} ] ", x.letter);
					Console.ResetColor();
				}
				else if (x.boardStatus.ToString() == "Filled" && x.boardY != 15)
				{
					Console.ForegroundColor = ConsoleColor.White;
					Console.Write("[{0} ] ", x.letter);
					Console.ResetColor();
				}
				else if (x.boardStatus.ToString() == "DL" && x.boardY == 15)
				{
					Console.ForegroundColor = ConsoleColor.Cyan;
					Console.WriteLine("[DL] ");
					Console.ResetColor();
				}
				else if (x.boardStatus.ToString() == "TW" && x.boardY == 15)
				{
					Console.ForegroundColor = ConsoleColor.Red;
					Console.WriteLine("[TW] ");
					Console.ResetColor();
				}
				else if (x.boardY == 15)
				{
					Console.ForegroundColor = ConsoleColor.White;
					Console.WriteLine("[  ] ");
					Console.ResetColor();
				}
				else if (x.boardStatus.ToString() == "DL")
				{
					Console.ForegroundColor = ConsoleColor.Cyan;
					Console.Write("[DL] ");
					Console.ResetColor();
				}
				else if (x.boardStatus.ToString() == "TL")
				{
					Console.ForegroundColor = ConsoleColor.Blue;
					Console.Write("[TL] ");
					Console.ResetColor();
				}
				else if (x.boardStatus.ToString() == "DW")
				{
					Console.ForegroundColor = ConsoleColor.Magenta;
					Console.Write("[DW] ");
					Console.ResetColor();
				}
				else if (x.boardStatus.ToString() == "TW")
				{
					Console.ForegroundColor = ConsoleColor.Red;
					Console.Write("[TW] ");
					Console.ResetColor();
				}
				else if (x.boardStatus.ToString() == "Start")
				{
					Console.ForegroundColor = ConsoleColor.Magenta;
					Console.Write("[XX] ");
					Console.ResetColor();
				}
				else if (x.boardStatus.ToString() == "Empty")
				{
					Console.Write("[  ] ");
				}

			}
	}

}
