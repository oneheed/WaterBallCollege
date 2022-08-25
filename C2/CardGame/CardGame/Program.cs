// See https://aka.ms/new-console-template for more information
using System.Text;
using CardGame.Models;

Console.OutputEncoding = Encoding.UTF8;

//var deck = Deck.Standard52ProkerCards();

//var players = new Player[4]
//{
//    new AIPlayer(),
//    new AIPlayer(),
//    new AIPlayer(),
//    new AIPlayer(),
//};

//var showdownGame = new ShowdownGame(deck, players);
//showdownGame.Start();


var deck = Deck.Standard40UnoCards();

var players = new Player[4]
{
    new UnoAIPlayer(),
    new UnoAIPlayer(),
    new UnoAIPlayer(),
    new UnoAIPlayer(),
};

var showdownGame = new UnoGame(deck, players);
showdownGame.Start();

