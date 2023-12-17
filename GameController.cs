namespace GameControllerLib;
using System.Runtime.Serialization.Json;
public class GameController
{
	private List<IPlayer> _players = new();
	private List<IPiece> _piece = new();
	private List<IPiece> _listOfPiece = new();
	private List<IBoard> _boardTile = new();
	private List<string> _dictionary = new();
	private Dictionary<IBoard, string> _temporaryWord = new();
	private Dictionary<int, int> _temporaryMove = new();
	private Dictionary<int, string> _pieceBag = new();
	private Dictionary<IPlayer, List<IPiece>> _playersPiece = new();
	
	private Random rand = new Random();
	int countTurn = 0;
	bool firstMove = false;
	bool stopTurn = false;
	public int sizeBoard;
	public GameController(string filename, int boardSize)
	{
		CreatePieceOfBag(filename);
		CreateBoard(boardSize);
	}
	public Dictionary<int, string> CreatePieceOfBag(string filename)
	{
		int counter = 0;
		int counter2 = 0;
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

						Piece piece = new Piece(counter2, str);
						if (!_listOfPiece.Any(x => x.pieceLetter.ToLower() == str.ToLower()))
						{
							_listOfPiece.Add(piece);
							counter2++;
						}
						counter++;
					}
				}
			}
		}
		return _pieceBag;
	}
	public List<IPiece> getPiece()
	{
		return _listOfPiece;
	}
	public Dictionary<int, string> GetPieceOfBag()
	{
		return _pieceBag;
	}
	public bool CreateBoard(int board)
	{
		sizeBoard = board;
		for (int i = 1; i <= board; i++)
		{
			for (int j = 1; j <= board; j++)
			{
				Board boardTile = new Board(i, j);
				_boardTile.Add(boardTile);
			}
		}
		return true;
	}
	public bool AddPlayer(params IPlayer[] players)
	{
		foreach (var i in players)
		{
			if (!_players.Any(x => x.id == i.id || x.name == i.name))
			{
				_players.Add(i);
				GeneratePieceOnStart(i);
			}
		}
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
	public List<IPiece> GetPiece()
	{
		return _piece;
	}

	public IPlayer GetPlayer(int index)
	{
		return _players[index];
	}
	public List<IPlayer> GetPlayerList()
	{
		return _players;
	}
	public bool SetBoardBonus(int boardX, int boardY, string bonus, int multiply)
	{
		foreach (var x in _boardTile)
		{
			if (x.boardX == boardX && x.boardY == boardY)
			{
				if (bonus == "Start")
				{
					x.boardStatus = BoardStatus.Start;
					x.bonusBoard = multiply;
				}
				else if (bonus == "DoubleLetter")
				{
					x.boardStatus = BoardStatus.DoubleLetter;
					x.bonusBoard = multiply;
				}
				else if (bonus == "TripleLetter")
				{
					x.boardStatus = BoardStatus.TripleLetter;
					x.bonusBoard = multiply;
				}
				else if (bonus == "DoubleWord")
				{
					x.boardStatus = BoardStatus.DoubleWord;
					x.bonusBoard = multiply;
				}
				else if (bonus == "TripleWord")
				{
					x.boardStatus = BoardStatus.TripleWord;
					x.bonusBoard = multiply;
				}
			}
		}
		return true;
	}
	public List<IBoard> GetBoard()
	{
		return _boardTile;
	}
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
	public bool SetScore(string letter, int skor)
	{
		letter = letter.ToLower();
		foreach (var x in _listOfPiece)
		{
			if (x.pieceLetter.ToLower() == letter)
			{
				x.pieceSkor = skor;
			}
		}
		return true;
	}
	public int GetScore()
	{
		// foreach(var s in GetDictionaries()){
		// 	Console.WriteLine(s);
		// }
		// if(words _temporaryWord.ToList().ForEach(data => Console.WriteLine(String.Concat(data.Value))) ){

		// }

		int score = 0;
		int totalscore = 0;

		foreach (var x in _temporaryWord)
		{
			x.Value.ToLower();

			foreach (var words in _listOfPiece)
			{
				if (words.pieceLetter == x.Value)
				{
					score += words.pieceSkor;
					foreach (var data in _boardTile)
					{
						if (data.boardX == x.Key.boardX && data.boardY == x.Key.boardY && (data.boardStatus.ToString() == "DoubleLetter" || data.boardStatus.ToString() == "TripleLetter"))
						{
							score = score * data.bonusBoard;
						}
					}
				}
			}
		}
		totalscore = score;

		foreach (var x in _temporaryWord)
		{
			foreach (var data in _boardTile)
			{
				if (data.boardX == x.Key.boardX && data.boardY == x.Key.boardY && (data.boardStatus.ToString() == "DoubleWord" || data.boardStatus.ToString() == "TripleWord"))
				{
					totalscore = totalscore * data.bonusBoard;
				}
			}

		}
		foreach(var player in _players){
			if (player.id==PlayerTurn()){
				player.skor=totalscore;
			}
		}
		return score;
	}

	public bool GetRandom()
	{
		List<int> keyList = new List<int>(_pieceBag.Keys);
		int randomKey = keyList[rand.Next(keyList.Count)];
		Console.WriteLine(_pieceBag[randomKey] + "," + randomKey);
		_pieceBag.Remove(randomKey);
		return true;
	}
	public List<Dictionaries> GetDictionaries()
	{
		DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(List<Dictionaries>));
		List<Dictionaries> importDictionaries;
		using (FileStream stream2 = new FileStream("Dictionaries.json", FileMode.Open, FileAccess.Read, FileShare.Read))
		{
			importDictionaries = (List<Dictionaries>)ser.ReadObject(stream2);
		}
		return importDictionaries;
	}

	// public bool Move(int player)
	// {
	// 	
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
	public bool GetInputLetter(int index)
	{
		List<IPiece> p = new();
		if (index == 200)
		{
			SwitchPlayer();
		}
		else
		{
			foreach (var x in _playersPiece)
			{
				foreach (var data in x.Value)
				{
					if (x.Key.id == PlayerTurn())
					{
						if (data.pieceID == index)
						{
							ChoosePiece(data.pieceLetter, data.pieceID);
						}
					}
				}
			}
		}
		return true;
	}
	public void ChoosePiece(string letter, int letterId)
	{
		if (firstMove == false)
		{
			foreach (var x in _boardTile)
			{
				if (x.boardStatus.ToString() == "Start")
				{
					Board b = new Board(x.boardX, x.boardY);
					_temporaryWord.Add(b, letter);
					x.letter = letter;
					x.boardStatus = BoardStatus.Filled;

					// foreach (var dataKey in _playersPiece)
					// {
					// 	foreach (var data in dataKey.Value)
					// 	{
					// 		if (dataKey.Key.id == PlayerTurn())
					// 		{
					// 			if (data.pieceID == letterId)
					// 			{
					// 				_playersPiece.Remove(letterId);
					// 			}
					// 		}
					// 	}
					// }


				}
			}
			firstMove = true;
		}
		else
		{

		}

	}

	public bool StopTurn()
	{
		return stopTurn;
	}
	public Dictionary<IBoard, string> GetTemporaryWord()
	{
		return _temporaryWord;
	}

	public void ViewBoard()
	{
		// BOARD
		foreach (var x in GetBoard())
		{
			if (x.boardStatus.ToString() == "Filled" && x.boardY == sizeBoard)
			{
				Console.ForegroundColor = ConsoleColor.White;
				Console.WriteLine("[{0} ] ", x.letter);
				Console.ResetColor();
			}
			else if (x.boardStatus.ToString() == "Filled" && x.boardY != sizeBoard)
			{
				Console.ForegroundColor = ConsoleColor.White;
				Console.Write("[{0} ] ", x.letter);
				Console.ResetColor();
			}
			else if (x.boardStatus.ToString() == "DoubleLetter" && x.boardY == sizeBoard)
			{
				Console.ForegroundColor = ConsoleColor.Cyan;
				Console.WriteLine("[DL] ");
				Console.ResetColor();
			}
			else if (x.boardStatus.ToString() == "TripleWord" && x.boardY == sizeBoard)
			{
				Console.ForegroundColor = ConsoleColor.Red;
				Console.WriteLine("[TW] ");
				Console.ResetColor();
			}
			else if (x.boardY == sizeBoard)
			{
				Console.ForegroundColor = ConsoleColor.White;
				Console.WriteLine("[  ] ");
				Console.ResetColor();
			}
			else if (x.boardStatus.ToString() == "DoubleLetter")
			{
				Console.ForegroundColor = ConsoleColor.Cyan;
				Console.Write("[DL] ");
				Console.ResetColor();
			}
			else if (x.boardStatus.ToString() == "TripleLetter")
			{
				Console.ForegroundColor = ConsoleColor.Blue;
				Console.Write("[TL] ");
				Console.ResetColor();
			}
			else if (x.boardStatus.ToString() == "DoubleWord")
			{
				Console.ForegroundColor = ConsoleColor.Magenta;
				Console.Write("[DW] ");
				Console.ResetColor();
			}
			else if (x.boardStatus.ToString() == "TripleWord")
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
