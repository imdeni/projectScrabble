namespace GameControllerLib;

public class GameController
{

    #region GAMECONTROLLER
    private List<IPlayer> _players = new();
    private List<IPiece> _piece = new();
    private List<IBoard> _boardTile = new();
    private Dictionary<int, string> _pieceBag = new();
    int countTurn = 0;
    bool firstTurn = false;
    public GameController(string filename,int sizeBoard)
    {
        CreatePieceOfBag(filename);
        CreateBoard(sizeBoard);
        GetPieceOfBag();
    }
    #endregion GAMECONTROLLER

    #region PLAYER
    public bool AddPlayer(params IPlayer[] players)
    {
        foreach (var i in players)
        {
            _players.Add(i);
        }
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
                //     Console.Write("[START] ");
                // }else if(j==board){
                //     Console.WriteLine("[ "+i+","+j+"] ");
                // }else if(i<=9){
                //     Console.Write("[ "+i+","+j+" ] ");
                // }else{
                //     Console.Write("["+i+","+j+" ] ");
                // }
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
        }

        return _pieceBag;
    }
    public Dictionary<int, string> GetPieceOfBag()
    {
        Console.Write($"{_pieceBag.Count} piece on bag : ");
        foreach (var data in _pieceBag)
        {
            Console.Write("[{0},{1}]", data.Key, data.Value);
        }
        return _pieceBag;
    }
    public bool GetRandom()
    {
        List<int> keyList = new List<int>(_pieceBag.Keys);
        Random rand = new Random();
        int randomKey = keyList[rand.Next(keyList.Count)];
        // return _pieceBag[randomKey];
        Console.WriteLine(_pieceBag[randomKey]+","+randomKey);
        _pieceBag.Remove(randomKey);
        return true;
    }
}
