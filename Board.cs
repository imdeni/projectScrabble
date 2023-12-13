namespace GameControllerLib;
public class Board : IBoard
{
	public int boardX {get;}
	public int boardY {get;}
	private string? bonus {get;}
	public Board(int boardX,int boardY) 
	{
		this.boardX = boardX;
		this.boardY = boardY;
	}
}
