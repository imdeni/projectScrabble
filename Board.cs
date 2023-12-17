namespace GameControllerLib;
public class Board : IBoard
{
	public int boardX {get;}
	public int boardY {get;}
	public string letter {get; set;}
	public int bonusBoard {get; set;}
	public BoardStatus boardStatus { get; set; }
	public Board(int boardX,int boardY) 
	{
		this.boardX = boardX;
		this.boardY = boardY;
		boardStatus = BoardStatus.Empty;
	}
	// public override string ToString()
    // {
	// 	return $"{boardX}, {boardY}";
    // }
}
