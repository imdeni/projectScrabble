namespace GameControllerLib;
public class Player : IPlayer
{
	public int id { get;}
	public string name { get; }
	public Player(int id, string name) 
	{
		this.id = id;
		this.name = name;
	}
	public override string ToString()
    {
		return $"{id}, {name}";
    }
}
