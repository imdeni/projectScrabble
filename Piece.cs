namespace GameControllerLib;
class Piece : IPiece
{
	public int pieceID { get; }
	public String? pieceLetter { get; }
	// public int PieceSkor { get; }
	public Piece(int pieceID, string pieceLetter)
	{
		this.pieceID = pieceID;
		this.pieceLetter = pieceLetter;
	}
	// public PieceStatus pieceStatus;
	// public override string ToString()
	// {
	// 	return $"{pieceID}, {pieceLetter}";
	// }
}