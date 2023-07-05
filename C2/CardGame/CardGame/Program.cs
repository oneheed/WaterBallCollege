// See https://aka.ms/new-console-template for more information
using System.Text;
using CardGame.Models;

Console.OutputEncoding = Encoding.UTF8;

var pokerDeck = Deck.Standard52PokerCards();

var players = new Player[4]
{
    new AIPlayer(),
    new AIPlayer(new HomogeneityAIStrategy()),
    new AIPlayer(new HomogeneityAIStrategy()),
    new AIPlayer(),
};

var showdownGame = new ShowdownGame(pokerDeck, players);
showdownGame.Start();


Console.WriteLine("================================================");

var uNoDeck = Deck.Standard40UNoCards();

var uNoGame = new UNoGame(uNoDeck, players);
uNoGame.Start();

