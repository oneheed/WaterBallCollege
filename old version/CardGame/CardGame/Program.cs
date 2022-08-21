// See https://aka.ms/new-console-template for more information
using CardGame.Base;
using CardGame.Models;

Console.OutputEncoding = System.Text.Encoding.UTF8;

var players = new List<Player>
{
    new RealPlayer { Name = "AI 1" },
    new AIPlayer { Name = "AI 2" },
    new AIPlayer { Name = "AI 3" },
    new AIPlayer { Name = "AI 4" },
};

var unoGame = new UnoGame(players);
unoGame.Start();

var showdownGame = new ShowdownGame(players);
showdownGame.Start();