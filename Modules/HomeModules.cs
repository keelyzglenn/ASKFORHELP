using Nancy;
using Games.Objects;
using System;
using System.Collections.Generic;

namespace Games
{
  public class HomeModule : NancyModule
  {
    public HomeModule()
    {
      Get["/"] = _ => {
        return View["index.cshtml"];
      };

// takes you to the add game page
      Get["/games/add"] = _ => {
        return View["games_add.cshtml"];
      };
// shows all games by title
      Get["/all_games_by_title"] = _ => {
        List<Game> allGames = Game.GetAll();
        return View["view_all_games_by_title.cshtml", allGames];
      };
// uses the form to post each new game input
      Post["/all_games_by_title"] = _ => {
        Game newGame = new Game(Request.Form["new-game"]);
        List<Game> allGames = Game.GetAll();
        return View["view_all_games_by_title.cshtml", allGames];
      };
  // displays singular game title based on game title id
      Get["/games/{id}"] = parameters => {
        Game game = Game.Find(parameters.id);
        return View["game_title.cshtml", game];
      };
    }
  }
}
