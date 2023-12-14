namespace GameControllerLib;

public class GameController
{

	#region GAMECONTROLLER
	private List<IPlayer> _players = new();
	private List<IPiece> _piece = new();
	private List<IBoard> _boardTile = new();
	private Dictionary<int, string> _pieceBag = new();
	private Dictionary<IPlayer, List<IPiece>> _playersPiece = new();
	private Random rand = new Random();
	int countTurn = 0;
	public GameController(string filename, int sizeBoard)
	{
		CreatePieceOfBag(filename);
		CreateBoard(sizeBoard);
		// GetPieceOfBag();
	}
	#endregion GAMECONTROLLER

	#region PLAYER
	public bool AddPlayer(params IPlayer[] players)
	{
		Console.Write("Adding players : ");
		foreach (var i in players)
		{
			_players.Add(i);
			Console.Write(i+" ");
			GeneratePieceOnStart(i);
		}
		Console.WriteLine("");
		
		GetPlayerPiece();
		return true;
	}


	public IPlayer GetPlayer(int index)
	{
		return _players[index];
	}

	public bool GetPlayerList()
	{
		Console.WriteLine("");
		Console.Write("Get list of player = ");
		for (int player = 0; player < _players.Count; player++)
		{
			Console.Write("[" + _players[player] + "] ");
		}
		Console.WriteLine("");
		Console.WriteLine("");
		return true;
	}
	#endregion PLAYER

	#region CREATEPIECE
	public bool CreatePiece()
	{
		int counter = 0;
		Console.Write("Generate piece = ");
		for (char c = 'A'; c <= 'Z'; c++)
		{
			Piece piece = new Piece(counter, c.ToString());
			_piece.Add(piece);
			Console.Write("[" + _piece[counter] + "] ");
			counter++;
		}
		Console.WriteLine("");
		Console.WriteLine("");
		return true;
	}
	#endregion CREATEPIECE

	#region CREATEBOARD
	public bool CreateBoard(int board)
	{
		for (int i = 1; i <= board; i++)
		{
			for (int j = 1; j <= board; j++)
			{
				Board boardTile = new Board(i, j);
				_boardTile.Add(boardTile);
				// if (i==8 && j==8){
				//     Console.Write("[  X  ] ");
				// }else if(j==board){
				//     Console.WriteLine("[ "+i+","+j+"] ");
				// }else if(i<=9){
				//     Console.Write("[ "+i+","+j+" ] ");
				// }else{
				//     Console.Write("["+i+","+j+" ] ");
				// }
			}
		}
		Console.WriteLine("Board generated");
		GetBoard();
		return true;
	}
	public bool GetBoard()
	{
		foreach (var i in _boardTile)
		{
			// Console.Write("[{0},{1}]", i.boardX, i.boardY);
			if (i.boardX == 8 && i.boardY == 8)
			{
				Console.Write("[ X  ] ");
			}
			else if (i.boardY == 15)
			{
				Console.WriteLine("[{0},{1}] ", i.boardX, i.boardY);
			}
			else if (i.boardX <= 9)
			{
				Console.Write("[ {0},{1}] ", i.boardX, i.boardY);
			}
			else
			{
				Console.Write("[{0},{1}] ", i.boardX, i.boardY);
			}
		}
		return true;
	}
	#endregion CREATEBOARD

	#region TURN
	public IPlayer PlayerTurn()
	{
		Console.WriteLine("Player turn = [" + _players[countTurn] + "]");
		return _players[countTurn];
	}

	public bool SwitchPlayer()
	{
		Console.WriteLine("Switch player turn");
		if (countTurn == _players.Count - 1)
		{
			countTurn = 0;
		}
		else
		{
			countTurn++;
		}
		PlayerTurn();
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
			Console.WriteLine("Pieces on bag generated");
		}
		GetPieceOfBag();
		return _pieceBag;
	}
	public Dictionary<int, string> GetPieceOfBag()
	{
		Console.Write($"{_pieceBag.Count} piece on bag : ");
		foreach (var data in _pieceBag)
		{
			Console.Write("[{0}]", data.Value);
		}
		Console.WriteLine("");
		return _pieceBag;
	}
	public bool GetRandom()
	{
		List<int> keyList = new List<int>(_pieceBag.Keys);
		// Random rand = new Random();
		int randomKey = keyList[rand.Next(keyList.Count)];
		// return _pieceBag[randomKey];
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
	
	public bool GetPlayerPiece()
	{
		Console.WriteLine("Distribute Pieces to Players :");
		foreach (var data in _playersPiece)
		{
			Console.Write(data.Key + " ");
			// Console.WriteLine(data.Key + ", "+data.Value[27].pieceLetter+" ");
			foreach (var x in data.Value)
			{
				Console.Write(x.pieceLetter);
			}
			Console.WriteLine(" ");
		}
		return true;
	}
}
