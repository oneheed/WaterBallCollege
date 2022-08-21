// See https://aka.ms/new-console-template for more information
using System.Text;
using Showdown.Models;

Console.OutputEncoding = Encoding.UTF8;

var deck = Deck.Standard52Cards();

var players = new Player[4]
{
    new AIPlayer(),
    new AIPlayer(),
    new AIPlayer(),
    new AIPlayer(),
};

var showdownGame = new ShowdownGame(deck, players);
showdownGame.Start();