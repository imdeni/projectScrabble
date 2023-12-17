namespace GameControllerLib;
public interface IPiece
{
	public int pieceID {get;}
	public string? pieceLetter {get;}
	public int pieceSkor { get; set;}
	// public PieceStatus pieceStatus { get; set; }
}