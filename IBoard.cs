namespace GameControllerLib;
public interface IBoard
{
    public int boardX { get; }
    public int boardY { get; }
    public string letter {get; set;}
    public int bonusBoard {get; set;}
    public BoardStatus boardStatus { get; set; }
}