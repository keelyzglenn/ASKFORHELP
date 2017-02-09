using System.Collections.Generic;
using Games.Objects;
namespace GameConsoles.Objects
{
  public class GameConsole
  {
    private static List<GameConsole> _instances = new List<GameConsole> {};
    private string _gameConsole;
    private int _id;
    private List<Game> _gamesList;

    public GameConsole(string gameConsoleName)
    {
      _gameConsole = gameConsoleName;
      _instances.Add(this);
      _id = _instances.Count;
      _gamesList = new List<Game>{};
    }
    public string GetConsoleName()
    {
      return _gameConsole;
    }
    public int GetId()
    {
      return _id;
    }
// these are for adding gameTitles into gameList
    public List<Game> GetGames()
    {
      return _gamesList;
    }
    public void AddGame(Game game)
    {
      _gamesList.Add(game);
    }
// these are for the CATEGORY list
    public static List<GameConsole> GetAll()
    {
      return _instances;
    }
    public static void Clear()
    {
      _instances.Clear();
    }
    public static GameConsole Find(int searchId)
    {
      return _instances[searchId -1];
    }
  }
}
