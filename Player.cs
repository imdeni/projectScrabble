namespace GameControllerLib;
public class Player : IPlayer
{
	public int id { get;}
	public string name { get; }
	public int skor {get;set;}
	public Player(int id, string name) 
	{
		this.id = id;
		this.name = name;
	}
	// public override string ToString()
    // {
	// 	return $"Player {id} : {name}";
    // }
}
