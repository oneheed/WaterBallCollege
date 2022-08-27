// See https://aka.ms/new-console-template for more information
using System.Text;
using CardGame.Models;

Console.OutputEncoding = Encoding.UTF8;

var prokerDeck = Deck.Standard52ProkerCards();

var players = new Player[4]
{
    new AIPlayer(),
    new AIPlayer(new HomogeneityAIStrategy()),
    new AIPlayer(new HomogeneityAIStrategy()),
    new AIPlayer(),
};

var showdownGame = new ShowdownGame(prokerDeck, players);
showdownGame.Start();


Console.WriteLine("================================================");

var unoDeck = Deck.Standard40UnoCards();

var unoGame = new UnoGame(unoDeck, players);
unoGame.Start();

