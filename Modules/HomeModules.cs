using Nancy;
using Games.Objects;
using System;
using System.Collections.Generic;
using GameConsoles.Objects;

namespace Games
{
  public class HomeModule : NancyModule
  {
    public HomeModule()
    {
      Get["/"] = _ => {
        return View["index.cshtml"];
      };
    // this returns the list of game consoles
      Get["/console/add"] = _ => {
        var AllGameConsoles = GameConsole.GetAll();
        return View["view_all_games_by_console.cshtml", AllGameConsoles];
      };
    // shows the console add form
      Get["/console/add"] = _ => {
        return View["console_add.cshtml"];
      };
    // posts the new game console from the form onto the list
      Post["/view_all_games_by_console"] = _ => {
        var newGameConsole = new GameConsole(Request.Form["console-name"]);
        var AllGameConsoles = GameConsole.GetAll();
        return View["view_all_games_by_console.cshtml", AllGameConsoles];
      };

      Get["/gameConsoles/{id}"] = parameters => {
        Dictionary<string, object> model = new Dictionary<string, object>();
        var selectedGameConsole = GameConsole.Find(parameters.id);
        var consoleGames = selectedGameConsole.GetGames();
        model.Add("gameConsole", selectedGameConsole);
        model.Add("games", consoleGames);
        return View["console.cshtml", model];
      };
      Get["/gameconsoles/{id}/games/new"] = parameters => {
        Dictionary<string, object> model = new Dictionary<string, object>();
        GameConsole selectedGameConsole = GameConsole.Find(parameters.id);
        List<Game> allGames = selectedGameConsole.GetGames();
        model.Add("gameConsole", selectedGameConsole);
        model.Add("games", allGames);
        return View["games_add.cshtml", model];
      };
      Post["/view_all_games_by_title"] = = _ => {
        Dictionary<string, object> model = new Dictionary<string, object>();
        GameConsole selectedGameConsole = GameConsole.Find(Request.Form["consoleName-id"]);
        List<Game> consoleGames = selectedGameConsole.GetGames();
        string gameTitle = Request.Form["new-game"];
        Game newGame = new Game(gameTitle);
        consoleGames.Add(newGame);
        model.Add("games", consoleGames);
        model.Add("gameConsole", selectedGameConsole);
        return View["console.cshtml", model];
      };
    }
  }
}
