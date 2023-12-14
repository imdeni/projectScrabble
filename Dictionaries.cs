namespace GameControllerLib;

using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Xml;

[DataContract]
public class Dictionaries
{
    [DataMember]
    private string word;

    public Dictionaries(string word)
    {
        this.word = word;
    }

    public string GetName()
    {
        return word;
    }
    
}
