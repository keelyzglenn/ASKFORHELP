using System.Collections.Generic;

namespace Games.Objects
{
  public class Game{
    private string _title;
    private static List<Game> _instances = new List<Game>{};

    public Game(string gameName);
    {
      _name = gameName;
      _instances.Add(this);
      _id = _instances.Count;
    }

// title
    public string GetName()
    {
      return _name;
    }
    public void SetName(string gameName)
    {
      _name = gameName;
    }
// id
    public int GetId()
    {
      return _id;
    }
// instances
    public static List<Game> GetAll()
    {
      return _instances;
    }
    public static void ClearAll()
    {
      _instances.Clear();
    }
    public static Game Find(int searchId)
    {
      return _instances[searchId-1];
    }
  }
}
