// See https://aka.ms/new-console-template for more information
using ShowdownGame.Models;

var showdown = new Showdown();
var player1 = new RealPlayer { Id = 0, Game = showdown };
player1.Namehimself("Tom");
showdown.AddPlayer(player1);
showdown.Shuffle();
showdown.DrawCard();
while (showdown.Players.First().Cards.Any())
{
    showdown.TakesATurn();
}
showdown.Finish();
